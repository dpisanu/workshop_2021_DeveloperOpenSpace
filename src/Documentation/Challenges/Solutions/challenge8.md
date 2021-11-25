# Challenge 8 Solution

## Reacting to change.

The [Challenge 7](../challenge7.md) **Target** is now extended to also account for Test assembly changes. At the end of the **Target** execution we should have a list of Test assemblies which require test execution.

Does your solution look along these lines?

```csharp
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
    });
```

Give this **Target** a spin with the following command:
```powershell
PS > .\build.ps1 IdentifyChangedDependenciesForTestAssemblies
```

```dos
╬═════════════════════════════════════════════════
║ IdentifyChangedDependenciesForTestAssemblies
╬════════════════════════════════════════

Added 25 new dependency hashes
Test Assembly to run C:\src\devopenspace\binTest\ClickDoubleClickTest.dll
Test Assembly to run C:\src\devopenspace\binTest\CommonControlsTest.dll
Test Assembly to run C:\src\devopenspace\binTest\CommonFrameworkTest.dll
Test Assembly to run C:\src\devopenspace\binTest\ContextMenuTest.dll
Test Assembly to run C:\src\devopenspace\binTest\DragDropTest.dll
Test Assembly to run C:\src\devopenspace\binTest\DropDownTest.dll
Test Assembly to run C:\src\devopenspace\binTest\ListBoxTest.dll
Test Assembly to run C:\src\devopenspace\binTest\PopUpTest.dll
Test Assembly to run C:\src\devopenspace\binTest\SampleWpfAppTest.dll
Test Assembly to run C:\src\devopenspace\binTest\ScrollingTest.dll
Test Assembly to run C:\src\devopenspace\binTest\SelectionStateTest.dll
Test Assembly to run C:\src\devopenspace\binTest\SplitterTest.dll

════════════════════════════════════════════════════════════════════
Target                                          Status      Duration
────────────────────────────────────────────────────────────────────
IdentifyChangedDependenciesForTestAssemblies    Succeeded     < 1sec
────────────────────────────────────────────────────────────────────
Total                                                         < 1sec
════════════════════════════════════════════════════════════════════
```


---------------------------------------
[🔙 Return to challenge](../challenge8.md)

[🚦 Return to start](../start.md)