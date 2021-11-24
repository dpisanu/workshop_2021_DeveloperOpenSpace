## Building

The project can be build using the [.NET CLI tooling](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build) from the root directory of the project.
```powershell
dotnet build
```
or 
```powershell
dotnet build --configuration Release
```

The output of the build process will be located in the **./bin/** Folder.
Start **SampleWpfApp.exe** application for a look and feel of the Big Corp. App.

## Running tests

In order to execute the tests we also rely on the [.NET CLI tooling](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet).
Head over to the **./binTest/** directory and execute the following command.
```powershell
dotnet.exe vstest *test.dll
```

You will see the following output. (Shown output is in german)

```dos
Microsoft (R) Testausführungs-Befehlszeilentool Version 16.11.0
Copyright (c) Microsoft Corporation. Alle Rechte vorbehalten.

Die Testausführung wird gestartet, bitte warten...
Insgesamt 12 Testdateien stimmten mit dem angegebenen Muster überein.

Bestanden!   : Fehler:     0, erfolgreich:     1, übersprungen:     0, gesamt:     1, Dauer: 235 ms - SampleWpfAppTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     3, übersprungen:     0, gesamt:     3, Dauer: 317 ms - SelectionStateTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     2, übersprungen:     0, gesamt:     2, Dauer: 285 ms - ScrollingTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     2, übersprungen:     0, gesamt:     2, Dauer: 273 ms - DragDropTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     3, übersprungen:     0, gesamt:     3, Dauer: 342 ms - DropDownTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     2, übersprungen:     0, gesamt:     2, Dauer: 270 ms - SplitterTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     1, übersprungen:     0, gesamt:     1, Dauer: 28 ms - CommonFrameworkTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     3, übersprungen:     0, gesamt:     3, Dauer: 297 ms - PopUpTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     1, übersprungen:     0, gesamt:     1, Dauer: 32 ms - CommonControlsTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     3, übersprungen:     0, gesamt:     3, Dauer: 323 ms - ListBoxTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     3, übersprungen:     0, gesamt:     3, Dauer: 351 ms - ClickDoubleClickTest.dll (net5.0)
Bestanden!   : Fehler:     0, erfolgreich:     3, übersprungen:     0, gesamt:     3, Dauer: 325 ms - ContextMenuTest.dll (net5.0)
```
