[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Collections?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Collections/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Collections.svg)](https://www.nuget.org/packages/ByteDev.Collections)
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
  - SafeLength
- Array [,]:
  - GetColumn
  - GetColumnCount
  - GetRow
  - GetRowCount
  - Populate
  - SafeLength
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
  - ToReadOnlyDictionary
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
  - Concat (params overloads)
  - ContainsAll
  - ContainsAny
  - Last(int)
  - MaxBy
  - MinBy
  - NullToEmpty
  - ForEach
  - Find
  - IsEmpty
  - IsNullOrEmpty
  - IsSingle
  - IsEquivalentTo
  - ToCsv  
  - ToDelimitedString
  - ToWrappedString
- IEnumerable<string>:
  - FirstLongest
  - FirstShortest 
- ICollection<T>:
  - AddIfNotContains
  - AddIfNotNull
  - AddRange
  - Fill
  - IsIndexValid
  - RemoveRandom
  - RemoveWhere
  - TakeRandom
- IList<T>:
  - NullToEmpty
  - MoveToFirst
  - MoveToLast
  - ReplaceAt
  - ReplaceAll
  - SafeGet
  - Shuffle
  - Swap
- NameValueCollection: 
  - AddOrUpdate
  - AddIfNotContainsKey
  - ContainsKey
  - ToDictionary
- GenericExtensions:
  - AsEnumerable
  - AsList
- IEnumerator<T>:
  - MoveNext(int) 

---

### Sequences

The `Sequencer` class can be used to quickly create different sequences of numbers.

```csharp
// Create different number sequences

using ByteDev.Collections.Sequences;

// ...

const int size = 8;

// 1, 1, 1, 1, 1, 1, 1, 1
IEnumberable<int> r = Sequencer.Repeating(size, 1);

// 1, 2, 3, 4, 5, 6, 7, 8
IEnumberable<int> n = Sequencer.Natural(size);

// 0, 1, 2, 3, 4, 5, 6, 7
IEnumberable<int> w = Sequencer.Whole(size);

// -2, -1, 0, 1, 2, 3, 4, 5
IEnumberable<int> i2 = Sequencer.Integers(size, -2);

// 1, 3, 5, 7, 9, 11, 13, 15
IEnumberable<int> a = Sequencer.Arithmetic(size, 1, 2);

// 1, 2, 4, 8, 16, 32, 64, 128
IEnumberable<int> g = Sequencer.Geometric(size, 1, 2);

// 0, 1, 1, 2, 3, 5, 8, 13
IEnumberable<int> f = Sequencer.Fibonacci(size);

// 2, 3, 5, 7, 11, 13, 17, 19
IEnumberable<int> p = Sequencer.Primes(size);

// 10, 5, 16, 8, 4, 2, 1
IEnumberable<int> c = Sequencer.Collatz(10);

// 1, 3, 6, 10, 15, 21, 28, 36
IEnumberable<int> t = Sequencer.Triangular(size);

// 1, 4, 9, 16, 25, 36, 49, 64
IEnumberable<int> s = Sequencer.Square(size);

// 1, 8, 27, 64, 125, 216, 343, 512
IEnumberable<int> s = Sequencer.Cube(size);

// 2, 4, 8, 16, 32, 64, 128, 256
IEnumberable<int> p2 = Sequencer.PowerOfTwo(size);

// 0, 2, 4, 6, 8, 10, 12, 14
IEnumberable<int> e1 = Sequencer.Even(size);

// 4, 6, 8, 10, 12, 14, 16, 18
IEnumberable<int> e2 = Sequencer.Even(size, 4);

// 1, 3, 5, 7, 9, 11, 13, 15
IEnumberable<int> o1 = Sequencer.Odd(size);

// 3, 5, 7, 9, 11, 13, 15, 17
IEnumberable<int> o2 = Sequencer.Odd(size, 3);

// 1, 4, 10, 20, 35, 56, 84, 120
IEnumberable<int> tet = Sequencer.Tetrahedral(size, 3);
```
