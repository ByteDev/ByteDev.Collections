[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Collections?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Collections/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Collections.svg)](https://www.nuget.org/packages/ByteDev.Collections)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/030a2d92bb2d4099962084f90dacfed0)](https://www.codacy.com/manual/ByteDev/ByteDev.Collections?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=ByteDev/ByteDev.Collections&amp;utm_campaign=Badge_Grade)

# ByteDev.Collections

Set of extension methods for various types of .NET collections.

## Installation

ByteDev.Collections has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Collections is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Collections`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Collections/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Collections/blob/master/docs/RELEASE-NOTES.md).

## Usage

To use any extension methods simply reference the `ByteDev.Collections` namespace.

Assembly contains extension methods:
- Array []:
  - Populate
- Array [,]:
  - GetColumn
  - GetColumnCount
  - GetRow
  - GetRowCount
  - Populate
- IDictionary<TKey, TValue>:
  - AddOrUpdate
  - AddRange
  - AddOrUpdateRange
  - AddIfNotContainsKey
  - GetValuesIgnoreKeyCase
  - GetFirstValueIgnoreKeyCase
- IEnumerable<T>:
  - Second
  - SecondOrDefault
  - Third
  - ThirdOrDefault
  - Fourth
  - FourthOrDefault
  - Fifth
  - FifthOrDefault
  - Sixth
  - SixthOrDefault
  - Seventh
  - SeventhOrDefault
  - Eigth
  - EigthOrDefault
  - Ninth
  - NinthOrDefault
  - Tenth
  - TenthOrDefault
  - ContainsAll
  - ContainsAny
  - NullToEmpty
  - ForEach
  - Find
  - IsEmpty
  - IsNullOrEmpty
  - IsSingle
  - IsEquivalentTo
  - ToDelimitedString
  - ToCsv
- IEnumerable<string>:
  - GetLongest
  - GetShortest 
- ICollection<T>
  - Fill
  - RemoveWhere
- IList<T>: 
  - NullToEmpty
  - MoveToFirst
  - MoveToLast
  - ReplaceAt
  - ReplaceAll
- NameValueCollection: 
  - AddOrUpdate
  - AddIfNotContainsKey
  - ContainsKey


