[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Collections?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Collections/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Collections.svg)](https://www.nuget.org/packages/ByteDev.Collections)

# ByteDev.Collections

Set of extension methods for various types of .NET collections.

## Installation

ByteDev.Collections has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Collections is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Collections`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Collections/).

## Code

The repo can be cloned from git bash:

`git clone https://github.com/ByteDev/ByteDev.Collections`

## Usage

Assembly contains extension methods:
- Dictionary: AddRange, AddOrUpdateRange.
- Enumerable: Second, Third... Tenth, NullToEmpty, ForEach, Find, IsEmpty, IsNullOrEmpty, IsSingle, IsEquivalentTo, ToDelimitedString, ToCsv.
- List: NullToEmpty, Fill, MoveToFirst.
- NameValueCollection: AddOrUpdate, ContainsKey.

To use the extension methods simply reference the ByteDev.Collections namespace.
