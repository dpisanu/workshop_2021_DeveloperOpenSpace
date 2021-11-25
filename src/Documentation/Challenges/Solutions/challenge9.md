# Challenge 9 Solution

## Running the new test scope.

The [Challenge 8](../challenge8.md) **Target** receives the final part where there is a reaction to the list of Test assemblies which are affected by the changes.

Extending the existing code by using the [VSTestTasks](https://nuke.build/api/Nuke.Common/Nuke.Common.Tools.VSTest.VSTestTasks.html) from NUKE.

In order to use the **vstest** wrapper of NUKe we need to install a required NUKE package to proceed.

```dos
PS > nuke :add-package Microsoft.TestPlatform --version 17.0.0

Installing Microsoft.TestPlatform/17.0.0 to ...
Done installing Microsoft.TestPlatform/17.0.0 to C:\src\devopenspace\build\_build.csproj.
```

Once that is done we can add the following function in our NUKE script and call it from the [Challenge 8](../challenge8.md) **Target**.

```csharp
private void ExecuteTests(IEnumerable<string> testAssemblies)
{
     var settings = new VSTestSettings().AddTestAssemblies(testAssemblies);
     VSTestTasks.VSTest(settings);
}
```

Try it out:
```powershell
PS > .\build.ps1 IdentifyChangedDependenciesForTestAssemblies
```

```dos
╬═════════════════════════════════════════════════
║ IdentifyChangedDependenciesForTestAssemblies
╬════════════════════════════════════════
...
...
...
NUnit Adapter 3.17.0.0: Test execution started
...
...
...

Test execution successful.
Total Tests: 49
     Passed: 49
   Duration: 16,9441 seconds
════════════════════════════════════════════════════════════════════
Target                                          Status      Duration
────────────────────────────────────────────────────────────────────
IdentifyChangedDependenciesForTestAssemblies    Succeeded       0:20
────────────────────────────────────────────────────────────────────
Total                                                           0:20
════════════════════════════════════════════════════════════════════
```

---------------------------------------
[🔙 Return to challenge](../challenge9.md)

[🚦 Return to start](../start.md)