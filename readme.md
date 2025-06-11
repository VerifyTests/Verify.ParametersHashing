# <img src="/src/icon.png" height="30px"> Verify.ParametersHashing

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://ci.appveyor.com/api/projects/status/25dkrl8wdgqkk0p6?svg=true)](https://ci.appveyor.com/project/SimonCropp/Verify-ParametersHashing)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.ParametersHashing.svg)](https://www.nuget.org/packages/Verify.ParametersHashing/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow hashing of parameters to mitigate long file names.

**See [Milestones](../../milestones?state=closed) for release notes.**


## Sponsors

include: zzz


## NuGet

 * https://nuget.org/packages/Verify.ParametersHashing


## Usage

Parameters can be hashed as an alternative to being stringified. This is useful when the parameters are large and could potentially generate file names that exceed allowances of the OS.

[XxHash64](https://learn.microsoft.com/en-us/dotnet/api/system.io.hashing.xxhash64) is used to perform the hash.

Hashing parameters is achieved by using `HashParameters()`:


### Instance

<!-- snippet: HashParameters -->
<a id='snippet-HashParameters'></a>
```cs
[TestCase("Value1")]
[TestCase("Value2")]
public Task HashParametersUsage(string arg)
{
    var settings = new VerifySettings();
    settings.HashParameters();
    return Verify(arg, settings);
}
```
<sup><a href='/src/Tests/Tests.cs#L4-L15' title='Snippet source file'>snippet source</a> | <a href='#snippet-HashParameters' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Fluent

<!-- snippet: HashParametersFluent -->
<a id='snippet-HashParametersFluent'></a>
```cs
[TestCase("Value1")]
[TestCase("Value2")]
public Task HashParametersUsageFluent(string arg) =>
    Verify(arg)
        .HashParameters();
```
<sup><a href='/src/Tests/Tests.cs#L17-L25' title='Snippet source file'>snippet source</a> | <a href='#snippet-HashParametersFluent' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

[Hash](https://thenounproject.com/icon/hash-7416693/) designed by [Hide Maru](https://thenounproject.com/creator/hiddemaru/) from [The Noun Project](https://thenounproject.com).
