using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DependencyAnalysis;
using NuGet.ProjectModel;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.VSTest;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath OutputDirectory => RootDirectory / "output";
    AbsolutePath DependencyGraphFilePath => RootDirectory / "graph.dg";
    AbsolutePath TestPath => RootDirectory / "binTest";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(OutputDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetAssemblyVersion(GitVersion.AssemblySemVer)
                .SetFileVersion(GitVersion.AssemblySemFileVer)
                .SetInformationalVersion(GitVersion.InformationalVersion)
                .EnableNoRestore()
                .EnableDeterministic()
                .SetProcessArgumentConfigurator(x =>
                    x.Add("/t:GenerateRestoreGraphFile")
                        .Add($"/p:RestoreGraphOutputPath={DependencyGraphFilePath}")
                )
            );
        });

    Target HashAllAssemblies => _ => _
        .Executes(() =>
        {
            var dependencyHashStorage = new DependencyHashStorage(RootDirectory);

            var filesToHash = new List<string>();
            
            var dllFiles = Directory.EnumerateFiles(TestPath, "*.dll");
            var exeFiles = Directory.EnumerateFiles(TestPath, "*.exe");

            filesToHash.AddRange(dllFiles);
            filesToHash.AddRange(exeFiles);

            // loop over test binaries
            foreach (var fileToHash in filesToHash)
            {
                var hash = dependencyHashStorage.GenerateHash(fileToHash);
                dependencyHashStorage.StoreHash(hash);
                Console.WriteLine($"File {fileToHash} : Hash {hash}");
            }
            dependencyHashStorage.Dispose();
        });

    Target MapDependenciesOfTestAssemblies => _ => _
        .OnlyWhenDynamic(() => File.Exists(DependencyGraphFilePath))
        .Executes(() =>
        {
            // Load graph
            var dependencyGraph = DependencyGraphSpec.Load(DependencyGraphFilePath);

            // List all test assemblies
            var testFiles = Directory.EnumerateFiles(TestPath, "*Test.dll");
            // loop over test assemblies
            foreach (var testFile in testFiles)
            {
                Console.WriteLine($"Test assembly {testFile}");
                // Determine dependencies for test assembly
                var packageSpec = dependencyGraph.Projects.Single(p => p.GetBinPath() == testFile);
                var packageSpecDependencies = packageSpec.GetAllProjectReferences(dependencyGraph);
                // loop over all dependencies
                foreach(var dependencyCSProjectPath in packageSpecDependencies)
                {
                    // get path to dependency
                    var dependencyBinPath = dependencyGraph.Projects.Single(p => p.FilePath == dependencyCSProjectPath).GetBinPath();
                    Console.WriteLine($"-> Test dependency {dependencyBinPath}");
                }
            }
        });

    Target IdentifyChangedDependenciesForTestAssemblies => _ => _
        .OnlyWhenDynamic(() => File.Exists(DependencyGraphFilePath))
        .Executes(() =>
        {
            var dependencyHashStorage = new DependencyHashStorage(RootDirectory);
            var newHashes = new HashSet<string>();
            var testsToRun = new HashSet<string>();

            // Load graph
            var dependencyGraph = DependencyGraphSpec.Load(DependencyGraphFilePath);

            // List all test assemblies
            var testFiles = Directory.EnumerateFiles(TestPath, "*Test.dll");
            // loop over test assemblies
            foreach (var testFile in testFiles)
            {
                // generate hash
                var testHash = dependencyHashStorage.GenerateHash(testFile);
                if (!dependencyHashStorage.IsHashKnown(testHash))
                {
                    // add new hash to list because it is not known
                    newHashes.Add(testHash);
                    // add test assembly to run list
                    testsToRun.Add(testFile);
                }
                // Determine dependencies for test assembly
                var packageSpec = dependencyGraph.Projects.Single(p => p.GetBinPath() == testFile);
                var packageSpecDependencies = packageSpec.GetAllProjectReferences(dependencyGraph);
                // loop over all dependencies
                foreach (var dependencyCSProjectPath in packageSpecDependencies)
                {
                    var dependencyBinPath = dependencyGraph.Projects.Single(p => p.FilePath == dependencyCSProjectPath).GetBinPath();
                    // generate hash
                    var hash = dependencyHashStorage.GenerateHash(dependencyBinPath);
                    if (!dependencyHashStorage.IsHashKnown(hash))
                    {
                        // add new hash to list because it is not known
                        newHashes.Add(hash);
                        // add test assembly to run list
                        testsToRun.Add(testFile);
                    }
                }
            }
            newHashes.ForEach(hash => dependencyHashStorage.StoreHash(hash));
            Console.WriteLine($"Added {newHashes.Count} new dependency hashes");
            testsToRun.ForEach(testAssembly => Console.WriteLine($"Test Assembly to run {testAssembly}"));

            dependencyHashStorage.Dispose();

            ExecuteTests(testsToRun);
        });

    private void ExecuteTests(IEnumerable<string> testAssemblies)
    {
        var settings = new VSTestSettings().AddTestAssemblies(testAssemblies);
        VSTestTasks.VSTest(settings);
    }
}