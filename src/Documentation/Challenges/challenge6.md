# Challenge 6

## Mapping my Dependency Graph!

Before we figure out if a changed Fingerprint is relevant for a specific Test assembly, we need to figure out how to map the dependency chain of that assembly.

For this we will rely on another [msbuild](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild?view=vs-2022) feature that allows us to create a Dependency Graph for a solution or an individual project.

Give it a try and run the following command from the root folder.

```powershell
dotnet msbuild /t:GenerateRestoreGraphFile /p:RestoreGraphOutputPath=graph.dg
```

This dependency graph stored in **graph.dg** will list all the dependencies for a project that need to be restored. Besides containing information such as the target framework it will also contain the complete output information of all projects in a solution.

This part is tricky a bit tricky but there is an entry point to the topic via the NuGet.ProjectModel package which provides us with a DepencencyGraphSpec.

#### Task: Add the flag to generate the graph to the Build **Target**
#### Task: Create a new Target that handles mapping out the project references of each Test assembly.

_Hint: For this an extension method is provided to make the traversal easier._

[🕵️‍♀ Possible solution](./Solutions/challenge6.md)

---------------------------------------
[⏭ Next challenge](./challenge7.md)

[🚦 Return to start](./start.md)