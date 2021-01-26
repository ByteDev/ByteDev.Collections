# Release Notes

## 2.6.0 - ?

Breaking changes:
- (None)

New features:
- Added `IEnumerable<T>.Last(int count)` overload.
- Added `IEnumerable<T>.MaxBy`.
- Added `IEnumerable<T>.MinBy`.
- Added `T[,].ToSingleDimension`.

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
