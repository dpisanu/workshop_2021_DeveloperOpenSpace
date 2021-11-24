## Repository

This repository contains all the required content for the [Developer Open  Scpace](https://devopenspace.de/) workshop on deterministic builds in C#.

The premise of the workshop is the use, development and testing of a standard big corp. in-house WPF application.

<p align="center">
    <img alt="Big Corp Tool"  src="./src/Documentation/BigCorpTool.gif">
</p>

Goal is to find out how to analyze changes in the code base and deciding which of the tests need to be executed instead of always running the whole test scope.

For this we will probe at
- deterministic builds
- mapping the build graph
- fingerprinting assemblies

## Tech stack & Tools

For the workshop we will be using 
- .NET 5.0
- WPF
- C#
- Powershell
- [/njuːk/](https://nuke.build/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)

## Let's get started

- [Project Setup](./src/Documentation/projectsetup.md) the solution
- [Building & Running](./src/Documentation/build_run.md) the solution
- [Challenges](./src/Documentation/Challenges/start.md) of a deterministic build

## Get in touch

[![Follow @d_pisanu](https://img.shields.io/badge/Twitter-Follow%20%40d_pisanu-blue.svg?style=flat-square)](https://twitter.com/intent/follow?screen_name=d_pisanu)

## License

Copyright © Daniel Pisanu and contributors.

The workshop content is provided as-is under the MIT license. For more information see [LICENSE](./LICENSE).
