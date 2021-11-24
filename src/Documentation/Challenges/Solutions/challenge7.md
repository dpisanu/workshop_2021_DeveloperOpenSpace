# Challenge 7 Solution

## How to pinpoint a change on my map?

The new mapping **Target** is a combination of [Challenge 5](../challenge5.md) [Challenge 6](../challenge6.md) and can look like the following:

```csharp
Target IdentifyChangedDependenciesForTestAssemblies => _ => _
    .OnlyWhenDynamic(() => File.Exists(DependencyGraphFilePath))
    .Executes(() =>
    {
        var dependencyHashStorage = new DependencyHashStorage(RootDirectory);
        var newHashes = new HashSet<string>();
        // Load graph
        var dependencyGraph = DependencyGraphSpec.Load(DependencyGraphFilePath);

        // List all test assemblies
        var testFiles = Directory.EnumerateFiles(TestPath, "*Test.dll");
        // loop over test assemblies
        foreach (var testFile in testFiles)
        {
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
                }
            }
        }
        newHashes.ForEach(hash => dependencyHashStorage.StoreHash(hash));
        Console.WriteLine($"Added {newHashes.Count} new hashes");
        dependencyHashStorage.Dispose();
    });
```

The reason why we add the new Fingerprints at the end is to avoid not noticing a dependency change in another Test assembly by prematurely adding the Fingerprint too early in the loop stages.

Give this **Target** a spin with the following command:

```powershell
PS > .\build.ps1 IdentifyChangedDependenciesForTestAssemblies
```

What did you notice while solving this Challenge?  
Did you run into **any** issues?

---------------------------------------
[Return to challenge](../challenge7.md)

[🚦 Return to start](../start.md)