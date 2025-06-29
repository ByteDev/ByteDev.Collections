# Release Notes

## 6.0.0 - ?

Breaking changes:
- `Sequencer` public methods now use `yield` and return `IEnumerable<int>`.
- Removed `Sequencer.Integers()` overload that takes optional `start` param (now mandatory).

New features:
- Added `CollectionExtensions.AddIfNotNull` method.
- Added `DictionaryExtensions.ToReadOnlyDictionary` method.

Bug fixes / internal changes:
- (None)

## 5.0.0 - 25 September 2023

Breaking changes:
- Removed `GenericExtensions.AsEnumerable` method overload that takes other items.
- Renamed `EnumerableStringExtensions.GetLongest` method to `FirstLongest`.
- Renamed `EnumerableStringExtensions.GetShortest` method to `FirstShortest`.

New features:
- Added `EnumeratorExtensions.MoveNext(count)` method.
- Added `EnumerableFactory` class.

Bug fixes / internal changes:
- `ListReplaceExtensions.ReplaceAt` now throws exception on index less than zero.

## 4.0.0 - 14 June 2022

Breaking changes:
- Removed `ListExtensions.GetNext` method.

New features:
- Added `ListExtensions.SafeGet` method.
- Added `EnumerableToExtensions.ToWrappedString` method.

Bug fixes / internal changes:
- (None)

## 3.4.0 - 12 January 2022

Breaking changes:
- (None)

New features:
- Added `GenericExtensions.AsList` method.
- Added `GenericExtensions.AsEnumerable` method overload for `params`.
- Added `ArrayExtensions.SafeLength` method.
- Added `ArrayTwoDimensionExtensions.SafeLength` method.
- Added `CollectionExtensions.AddIfNotContains` method.

Bug fixes / internal changes:
- (None)

## 3.3.0 - 19 August 2021

Breaking changes:
- (None)

New features:
- Added `GenericExtensions.AsEnumerable` method.
- Added `EnumerableExtensions.Concat` overload that takes params array of `TSource`.
- Added `EnumerableExtensions.Concat` overload that takes params array of `IEnumerable<TSource>`.
- Added `Sequencer.Repeating` method.
- Added `Sequencer.Triangular` method.
- Added `Sequencer.Square` method.
- Added `Sequencer.Cube` method.
- Added `Sequencer.PowerOfTwo` method.
- Added `Sequencer.Even` method.
- Added `Sequencer.Odd` method.
- Added `Sequencer.Tetrahedral` method.

Bug fixes / internal changes:
- (None)

## 3.2.0 - 13 August 2021

Breaking changes:
- (None)

New features:
- Added `Sequencer.Collatz` method.

Bug fixes / internal changes:
- (None)

## 3.1.0 - 23 June 2021

Breaking changes:
- (None)

New features:
- Added `Sequencer.Whole` method.

Bug fixes / internal changes:
- (None)

## 3.0.0 - 17 March 2021

Breaking changes:
- Removed `CollectionRandomExtensions.GetRandomOrDefault`.
- Renamed `CollectionRandomExtensions.GetRandom` to `TakeRandom`.
- `TakeRandom` now works more like `Take` method.

New features:
- Added `CollectionRandomExtensions.RemoveRandom`.
- Added `CollectionRandomExtensions.TakeRandom` with count.

Bug fixes / internal changes:
- (None)

## 2.7.0 - 12 March 2021

Breaking changes:
- (None)

New features:
- Added `ListExtensions.GetNext`.

Bug fixes / internal changes:
- (None)

## 2.6.0 - 28 January 2021

Breaking changes:
- (None)

New features:
- Added `IEnumerable<T>.Last(int count)` overload.
- Added `IEnumerable<T>.MaxBy`.
- Added `IEnumerable<T>.MinBy`.
- Added `IEnumerable<T>.AllUnique`.
- Added `T[,].ToSingleDimension`.
- Added `ICollection<T>.AddRange`.
- Added `ICollection<T>.GetRandom`.
- Added `ICollection<T>.GetRandomOrDefault`.
- Added `IList<T>.Shuffle`.

Bug fixes / internal changes:
- (None)

## 2.5.0 - 05 November 2020

Breaking changes:
- (None)

New features:
- Added `DictionaryExtensions.GetValueOrDefault`
- Added `DictionaryExtensions.RenameKey`
- Added `CollectionExtensions.IsIndexValid`
- Added `ListExtensions.Swap`

Bug fixes / internal changes:
- (None)

## 2.4.0 - 14 October 2020

Breaking changes:
- (None)

New features:
- Added `DictionaryExtensions.ToNameValueCollection`
- Added `NameValueCollectionExtensions.ToDictionary`

Bug fixes / internal changes:
- (None)

## 2.3.0 - 29 September 2020

Breaking changes:
- (None)

New features:
- Added `DictionaryExtensions.ContainsAllKey`
- Added `DictionaryExtensions.ContainsAnyKey`
- Added `Sequencer` type

Bug fixes / internal changes:
- (None)

## 2.2.0 - 13 July 2020

Breaking changes:
- (None)

New features:
- Added `NameValueCollection.AddIfNotContainsKey`
- Added `DictionaryExtensions.AddIfNotContainsKey`
- Added `EnumerableExtensions.ContainsAll`
- Added `EnumerableExtensions.ContainsAny`
- Added `ListExtensions.ReplaceAt`
- Added `ListExtensions.ReplaceAll`

Bug fixes / internal changes:
- Moved `IList.Fill` to `ICollection.Fill`
- Moved `IList.RemoveWhere` to `ICollection.RemoveWhere`

## 2.1.1 - 13 February 2020

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Added .NET Standard 2.0 dependency group for package

## 2.1.0 - 18 January 2020

Breaking changes:
- (None)

New features:
- Added `DictionaryExtensions.AddOrUpdate` (with predicate overload)

Bug fixes / internal changes:
- (None)

## 2.0.0 - 16 December 2019

Breaking changes:
- Removed `DictionaryExtensions.GetValueIgnoreKeyCase`

New features:
- `ArrayExtensions.Populate` now takes params array of values instead of single value
- Added `ListExtensions.MoveToLast`
- Added `DictionaryExtensions.GetValuesIgnoreKeyCase`
- Added `DictionaryExtensions.GetFirstValueIgnoreKeyCase`

Bug fixes / internal changes:
- (None)

## 1.4.0 - 05 November 2019

Breaking changes:
- (None)

New features:
- Added two dimension array extension method `GetRow`
- Added two dimension array extension method `GetColumn`
- Added two dimension array extension method `GetRowCount`
- Added two dimension array extension method `GetColumnCount`

Bug fixes / internal changes:
- (None)

## 1.3.1 - 03 November 2019

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- `EnumerableStringExtensions.GetLongest` and `GetShortest` bug fix to now handle null elements

## 1.3.0 - 02 November 2019

Breaking changes:
- (None)

New features:
- Added `IEnumerable<string>.GetLongest` and `GetShortest`

Bug fixes / internal changes:
- (None)

## 1.2.0 - 02 November 2019

Breaking changes:
- (None)

New features:
- Added `Populate` methods for one and two dimension arrays

Bug fixes / internal changes:
- (None)

## 1.1.0 - 08 October 2019

Breaking changes:
- (None)

New features:
- Added `IEnumerable` extension methods for element selection or default

Bug fixes / internal changes:
- (None)

## 1.0.1 - 30 September 2019

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- XML documentation now output on build and included in nuget package

## 1.0.0 - 28 September 2019

Initial version.
