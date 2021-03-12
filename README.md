[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Collections?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Collections/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Collections.svg)](https://www.nuget.org/packages/ByteDev.Collections)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/030a2d92bb2d4099962084f90dacfed0)](https://www.codacy.com/manual/ByteDev/ByteDev.Collections?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=ByteDev/ByteDev.Collections&amp;utm_campaign=Badge_Grade)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Collections/blob/master/LICENSE)

# ByteDev.Collections

Set of extended collections related functionality.

## Installation

ByteDev.Collections has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Collections is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Collections`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Collections/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Collections/blob/master/docs/RELEASE-NOTES.md).

## Usage

### Extension methods

To use any extension methods simply reference the `ByteDev.Collections` namespace.

- Array []:
  - Populate
- Array [,]:
  - GetColumn
  - GetColumnCount
  - GetRow
  - GetRowCount
  - Populate
  - ToSingleDimension
- IDictionary<TKey, TValue>:
  - AddOrUpdate
  - AddRange
  - AddOrUpdateRange
  - AddIfNotContainsKey
  - ContainsAllKey
  - ContainsAnyKey
  - GetFirstValueIgnoreKeyCase  
  - GetValueOrDefault
  - GetValuesIgnoreKeyCase
  - RenameKey
  - ToNameValueCollection
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
  - AllUnique
  - ContainsAll
  - ContainsAny
  - Last(count)
  - MaxBy
  - MinBy
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
- ICollection<T>:
  - AddRange
  - GetRandom
  - GetRandomOrDefault
  - Fill
  - IsIndexValid
  - RemoveWhere
- IList<T>:
  - GetNext
  - NullToEmpty
  - MoveToFirst
  - MoveToLast
  - ReplaceAt
  - ReplaceAll
  - Shuffle
  - Swap
- NameValueCollection: 
  - AddOrUpdate
  - AddIfNotContainsKey
  - ContainsKey
  - ToDictionary

---

### Sequences

The `Sequencer` class can be used to quickly create different sets of number sequences.

```csharp
// Create different number sequences

using ByteDev.Collections.Sequences;

// ...

const int size = 8;

// 1, 2, 3, 4, 5, 6, 7, 8
IList<int> n = Sequencer.Natural(size);   

// 0, 1, 2, 3, 4, 5, 6, 7
IList<int> i1 = Sequencer.Integers(size);  

// -2, -1, 0, 1, 2, 3, 4, 5
IList<int> i2 = Sequencer.Integers(size, -2);

// 1, 3, 5, 7, 9, 11, 13, 15
IList<int> a = Sequencer.Arithmetic(size, 1, 2);

// 1, 2, 4, 8, 16, 32, 64, 128
IList<int> g = Sequencer.Geometric(size, 1, 2);

// 0, 1, 1, 2, 3, 5, 8, 13
IList<int> f = Sequencer.Fibonacci(size);

// 2, 3, 5, 7, 11, 13, 17, 19
IList<int> p = Sequencer.Primes(size);
```
