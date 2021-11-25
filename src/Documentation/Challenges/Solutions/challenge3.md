# Challenge 3 Solution

## Are builds consistent?

To verify consistency we will need to build and fingerprint in a tight loop.

```powershell
$hashes = @()
for ($counter = 1; $counter -le 10; $counter++ )
{
	dotnet clean 
	dotnet build
	# in case the build command fails, try again till success
	while($LASTEXITCODE -ne 0)
	{
		dotnet build
	}
	$hash = Get-FileHash binTest\SampleWpfApp.exe | Select-Object -ExpandProperty Hash
	$hashes = $hashes + $hash
}

foreach ($h in $hashes){
   Write-Host -ForegroundColor Green $h
}
```

In some rare cases you might notice that during recompile on the same code base, the hashes differ.
This is due to slight variations of the assembly content caused by the [msbuild](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild?view=vs-2022) tooling, compile environment and gravitational anomalies. :)

There are two solutions to this that can be used together.

_Optional_ : Change the way we create the fingerprint

**Must** : Configure the [msbuild](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild?view=vs-2022) tooling to create consistent builds.

### Fingerprinting

The **byte-for-byte** comparison done by the hashing is error prone to slight variations on the source material.
The great thing about .NET assemblies is that they are IL code and even if the assembly as a whole might show slight variations, the IL tree inside can ALSO be put under a fingerprint.

**Why is this important?**

Think about the situation that you use different build machines, you are bound to receive binaries containing certain variable content such as:
- contained checksum value
- Time-Date stamps
- Image base information

For this, we can use the [IL Disassembler](https://docs.microsoft.com/en-us/dotnet/framework/tools/ildasm-exe-il-disassembler) to:
- load the assembly
- create a flat document style structure of the IL code
- remove the variable sections which foil the fingerprinting
- hash the sanitized structure **or** write the IL back to file and hash the file

```csharp
public string SanitizeAssemblyIL(string filePath)
{
    var ildasm = @"C:\Program Files\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\ildasm.exe";
    
    var processStartInf = new ProcessStartInfo(ildasm, $"/all /text {filePath}")
    {
        CreateNowWindow = true,
        WindowStyle = ProcessWindowStyle.Hidden,
        RedirectStandardOutput = true
    }
    using var process = Process.Start(processStartInf);
    string document = process.StandardOutput.ReadToEnd();
    proecess.WaitForExit();
    
    // Sanitize
    document = Regex.Replace(document, "// Time-date stamo:.", string.Empty, RegexOptions.Compiled);
    document = Regex.Replace(document, "// Image base:.", string.Empty, RegexOptions.Compiled);
    document = Regex.Replace(document, "// Checksum:.", string.Empty, RegexOptions.Compiled);
    
    return document;
}
```

### Consistent builds

Consistent builds are also called **Deterministic Builds** and for exactly this use case the following [compiler option](hhttps://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/code-generation) comes into play.
This flag causes the compiler to produce an assembly whose **byte-for-byte output is identical across compilations for identical inputs**.

It's _as simple_ as that. No need for elaborate tooling in shape of [Source Link](https://github.com/clairernovotny/DeterministicBuilds) or such.  
The paradigm is becoming the de facto norm and if you want to know more, read up on this article from the Conan community for [Deterministic builds in C/C++](https://blog.conan.io/2019/09/02/Deterministic-builds-with-C-C++.html)

---------------------------------------
[🔙 Return to challenge](../challenge3.md)

[🚦 Return to start](../start.md)