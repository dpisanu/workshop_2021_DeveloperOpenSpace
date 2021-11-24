# Challenge 3 Solution

## Are builds consistent?

You might have noticed that sometimes during recompile on the same code base, the hashes might vary.
This is due to slight variations of the assembly content caused by the [msbuild](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild?view=vs-2022) tooling. 
To navigate around this fact we not only need to change the fingerprinting approach but also force the [msbuild](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild?view=vs-2022) tooling to create consistent builds.

### Fingerprinting

The **byte-for-byte** comparison done by the hashing is error prone to slight variations on the source material.
The great thing about .NET assemblies is that they are IL code and even if the assembly as a whole might show slight variations, the IL tree inside it can ALSO be put under a fingerprint.

# TODO :: ADD IL CODE FINGERPRINTING ::


### Consistent builds

Consistent builds are also called **Deterministic Builds** and for exactly this use case the following [compiler option](hhttps://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/code-generation) comes into play.
This flag causes the compiler to produce an assembly whose **byte-for-byte output is identical across compilations for identical inputs**.

It's _as simple_ as that. No need for elaborate tooling in shape of [Source Link](https://github.com/clairernovotny/DeterministicBuilds) or such.  
The paradigm is becoming the de facto norm and if you want to know more, read up on this article from the Conan community for [Deterministic builds in C/C++](https://blog.conan.io/2019/09/02/Deterministic-builds-with-C-C++.html)

---------------------------------------
[Return to challenge](../challenge3.md)

[🚦 Return to start](../start.md)