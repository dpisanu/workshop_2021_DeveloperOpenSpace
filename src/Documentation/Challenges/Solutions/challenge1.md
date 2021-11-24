# Challenge 1 Solution

## What is my test run time?

There are multiple ways of timing your test execution.  
You can use a dedicated test runner such as NUnit which provides a detailed run time log OR you wrap your dotnet CLI call in some powershell.  
  
```powershell
Measure-Command { dotnet.exe vstest *test.dll }
```

This will leave you with the following output:
```dos
PS > Measure-Command { dotnet.exe vstest *test.dll }


Days              : 0
Hours             : 0
Minutes           : 0
Seconds           : 18
Milliseconds      : 500
Ticks             : 185001539
TotalDays         : 0,00021412215162037
TotalHours        : 0,00513893163888889
TotalMinutes      : 0,308335898333333
TotalSeconds      : 18,5001539
TotalMilliseconds : 18500,1539
```

Looking back at the **stdout** we know from our usual test execution, we are missing critical execution information.
Try piping your **stdout** on the powershell call instead.

```powershell
Measure-Command { dotnet.exe VSTest *test.dll | Out-Default }
```

---------------------------------------
[🔙 Return to challenge](../challenge1.md)

[🚦 Return to start](../start.md)