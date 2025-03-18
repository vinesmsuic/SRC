# SRC (Simulation RPG Construction)

SRC# (Simulation RPG Construction Sharp) is a C# .NET port of SRC (Simulation RPG Construction).

## SRC Derivative Software

When using the software developed and distributed in this repository, please comply with the basic rules for using SRC derivative software.

Basic rules for using SRC derivative software on the SRC official site [Derivative Version Explanation Page](http://www.src-srpg.jpn.org/development_hasei.shtml)
- [Terms (Format 1)](http://www.src-srpg.jpn.org/hasei_kiyaku1.html)
- [Terms (Format 2)](http://www.src-srpg.jpn.org/hasei_kiyaku2.html)

Transcription to this repository
- [Terms (Format 1)](src_hasei_kiyaku1.md)
- [Terms (Format 2)](src_hasei_kiyaku2.md)

## Original

- http://www.src-srpg.jpn.org/
- http://www.src-srpg.jpn.org/development_beta.shtml

## Solution/Project

- [SRC](./SRC)
    - [SRC_20121125](./SRC/SRC_20121125)
        - Copy of the original SRC used as a base
        - Character encoding changed to UTF-8 for reference
    - [Help](./SRC/Help)
        - Copy of the SRC Ver2.2.33 help project
    - [HelpChm](./SRC/HelpChm)
        - Help converted to CHM format
- [SRC.NET](./SRC.NET)
    - SRC_20121125 converted to .NET using tools
- [SRC.Sharp](./SRC.Sharp)
    - Partial C# implementation of SRC, SRC#
    - [SRCCore](./SRC.Sharp/SRCCore)
        - Core part of SRC
        - .NET Standard 2.1
    - [SRCDataLinter](SRC.Sharp/SRCDataLinter)
        - Validator for SRC data
        - .NET 6
        - GitHub Action: https://github.com/7474/SRC-DataLinter
        - Docker Image: https://hub.docker.com/r/koudenpa/srcdatalinter
            - ![Docker Cloud Build Status](https://img.shields.io/docker/cloud/build/koudenpa/srcdatalinter)
    - [SRCSharpForm](./SRC.Sharp/SRCSharpForm)
        - Windows Forms implementation of SRC#Form
        - Allows provisional execution of SRC#Form
        - .NET 6
        - For convenience of distinction from the original SRC, the version is set as `3.x.x`
            - Major version is +3 compared to SRCCore
        - HelpURL: https://srch.7474.jp/
    - [SRCTestForm](./SRC.Sharp/SRCTestForm)
        - Test form for operation verification
        - Allows viewing of data
        - .NET 6
    - [SRCTestBlazor](./SRC.Sharp/SRCTestBlazor)
        - Blazor WebAssembly application for operation verification
        - Allows viewing of data
        - .NET 6
        - URLs:
            - https://7474.github.io/SRC/
            - https://srcv.7474.jp/

### SRC#Form Simple Execution Procedure

1. Install [.NET 6 runtime](https://docs.microsoft.com/en-us/dotnet/core/install/windows) on Windows 10 64-bit
2. Download SRCSharpForm.zip from [Release](https://github.com/7474/SRC/releases), or build SRCSharpForm to obtain the executable file (SRCSharpForm.exe and accompanying DLLs if built)
3. Copy the executable file into a pre-built SRC folder
4. Run SRCSharpForm.exe


### Build

```
dotnet restore

dotnet build
```

```
dotnet run -p SRC.Sharp/SRCSharpForm
```


We are developing this while testing with the sample scenarios included with SRC and https://github.com/7474/SRC-SharpTestScenario.
