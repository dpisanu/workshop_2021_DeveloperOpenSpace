# Challenge 2 Solution

## Have there been changes?

Here again we see there are multiple ways of identifying if there has been a change to an assembly file. Be it from actual code changes or changes done during/post the compile phase.

I call this the **fingerprint step** and in powershell it would look the following example:

```powershell
Get-FileHash .\SampleWpfApp.exe | Format-List
```

This will leave you with the following output:
```dos
PS > Get-FileHash .\SampleWpfApp.exe | Format-List


Algorithm : SHA256
Hash      : 94110F14E6EE91D0F4FBC25107A9B2814A6EB8CD413CCFF539F1D18E56DC872C
Path      : C:\src\devopenspace\bin\net5.0-windows\SampleWpfApp.exe
```

There are a few algorithms we can fingerprint here. Choose to your personal liking.

Parameter: **-Algorithm**
```
SHA1
SHA256
SHA384
SHA512
MD5
```

If you just want to see the calculated hash then use the following command:

```powershell
Get-FileHash .\SampleWpfApp.exe | Select-Object -ExpandProperty Hash
```