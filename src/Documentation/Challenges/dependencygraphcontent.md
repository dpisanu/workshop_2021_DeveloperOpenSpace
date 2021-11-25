## What is inside a dependency graph?

Here is an excerpt of the Dependency Graph for this complete solution.

```xml
{
  "format": 1,
  "restore": {
    "C:\\src\\devopenspace\\src\\Common\\CommonControls\\CommonControls.csproj": {},
	...,
	...,
	...,
  },
  "projects": {
    "C:\\src\\devopenspace\\src\\Common\\CommonControls\\CommonControls.csproj": {
      "version": "1.0.0",
      "restore": {
        "projectUniqueName": "C:\\src\\devopenspace\\src\\Common\\CommonControls\\CommonControls.csproj",
        "projectName": "Common.CommonControls",
        "projectPath": "C:\\src\\devopenspace\\src\\Common\\CommonControls\\CommonControls.csproj",
        "packagesPath": "C:\\Users\\staca\\.nuget\\packages\\",
        "outputPath": "C:\\src\\devopenspace\\src\\Common\\CommonControls\\obj\\",
        "projectStyle": "PackageReference",
        "fallbackFolders": [
          "C:\\Program Files (x86)\\Microsoft Visual Studio\\Shared\\NuGetPackages"
        ],
        "configFilePaths": [
          "C:\\Users\\staca\\AppData\\Roaming\\NuGet\\NuGet.Config",
          "C:\\Program Files (x86)\\NuGet\\Config\\Microsoft.VisualStudio.FallbackLocation.config",
          "C:\\Program Files (x86)\\NuGet\\Config\\Microsoft.VisualStudio.Offline.config"
        ],
        "originalTargetFrameworks": [
          "net5.0-windows"
        ],
        "sources": {
          "C:\\Program Files (x86)\\Microsoft SDKs\\NuGetPackages\\": {},
          "https://api.nuget.org/v3/index.json": {}
        },
        "frameworks": {
          "net5.0-windows7.0": {
            "targetAlias": "net5.0-windows",
            "projectReferences": {}
          }
        },
        "warningProperties": {
          "warnAsError": [
            "NU1605"
          ]
        }
      },
      "frameworks": {
        "net5.0-windows7.0": {
          "targetAlias": "net5.0-windows",
          "dependencies": {
            "MahApps.Metro.SimpleChildWindow": {
              "target": "Package",
              "version": "[2.0.0, )"
            }
          },
          "imports": [
            "net461",
            "net462",
            "net47",
            "net471",
            "net472",
            "net48"
          ],
          "assetTargetFallback": true,
          "warn": true,
          "frameworkReferences": {
            "Microsoft.NETCore.App": {
              "privateAssets": "all"
            },
            "Microsoft.WindowsDesktop.App.WPF": {
              "privateAssets": "none"
            }
          },
          "runtimeIdentifierGraphPath": "C:\\Program Files\\dotnet\\sdk\\5.0.403\\RuntimeIdentifierGraph.json"
        }
      }
    }
  }
}
```
Clustered Under the **projects** node are all projects in the solution. One child node per project

Inside each child node is a **sources** node which lists all NuGet sources used to build the project and provides the eternal dependency and restore/update list.

The **frameworks** nodes contain all entries for each of the target frameworks of the project. Contained inside is also the **dependencies** node which lists all the package references including the version of the package.

---------------------------------------
[🔙 Return to challenge](./challenge6.md)