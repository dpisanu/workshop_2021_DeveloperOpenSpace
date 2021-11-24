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
        var testAssemblies = new HashSet<Tuple<string, string>>();

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
                testAssemblies.Add(new Tuple<string, string>(testFile, testHash));
            }
            // Determine dependencies for test assembly
            var packageSpec = dependencyGraph.Projects.Single(p => p.GetBinPath() == testFile);
            var packageSpecDependencies = packageSpec.GetAllProjectReferences(dependencyGraph);
            // loop over all dependencies
            foreach (var dependencyCSProjectPath in packageSpecDependencies)
            { 
                // get path to dependency
                var dependencyBinPath = dependencyGraph.Projects.Single(p => p.FilePath == dependencyCSProjectPath).GetBinPath();
                // generate hash
                var hash = dependencyHashStorage.GenerateHash(dependencyBinPath);
                if (!dependencyHashStorage.IsHashKnown(hash))
                {
                    // add new hash to list because it is not known
                    newHashes.Add(hash);
                    testAssemblies.Add(new Tuple<string, string>(testFile, testHash));
                }
            }
        }
        newHashes.ForEach(hash => dependencyHashStorage.StoreHash(hash));
        testAssemblies.ForEach(hashTuple => dependencyHashStorage.StoreHash(hashTuple.Item2));
        Console.WriteLine($"Added {newHashes.Count} new dependency hashes");
        Console.WriteLine($"testAssemblies {testAssemblies.Count} new test hashes");

        dependencyHashStorage.Dispose();
    });
```

Give this **Target** a spin with the following command:
```powershell
PS > .\build.ps1 IdentifyChangedDependenciesForTestAssemblies
```

---------------------------------------
[🔙 Return to challenge](../challenge8.md)

[🚦 Return to start](../start.md)
