# Release Notes

## 2.2.0 - ?? July 2020

Breaking changes:
- (None)

New features:
- Added NameValueCollection.AddIfNotContainsKey
- Added DictionaryExtensions.AddIfNotContainsKey
- Added EnumerableExtensions.ContainsAll
- Added EnumerableExtensions.ContainsAny

Bug fixes:
- (None)

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
- Added DictionaryExtensions.AddOrUpdate (with predicate overload).

Bug fixes / internal changes:
- (None)

## 2.0.0 - 16 December 2019

Breaking changes:
- Removed DictionaryExtensions.GetValueIgnoreKeyCase

New features:
- ArrayExtensions.Populate now takes params array of values instead of single value.
- Added ListExtensions.MoveToLast.
- Added DictionaryExtensions.GetValuesIgnoreKeyCase.
- Added DictionaryExtensions.GetFirstValueIgnoreKeyCase.

Bug fixes / internal changes:
- (None)

## 1.4.0 - 05 November 2019

Breaking changes:
- (None)

New features:
- Added two dimension array extension method GetRow.
- Added two dimension array extension method GetColumn.
- Added two dimension array extension method GetRowCount.
- Added two dimension array extension method GetColumnCount.

Bug fixes / internal changes:
- (None)

## 1.3.1 - 03 November 2019

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- EnumerableStringExtensions GetLongest and GetShortest bug fix to now handle null elements.

## 1.3.0 - 02 November 2019

Breaking changes:
- (None)

New features:
- Added IEnumerable<string> extension methods GetLongest and GetShortest.

Bug fixes / internal changes:
- (None)

## 1.2.0 - 02 November 2019

Breaking changes:
- (None)

New features:
- Added Populate methods for one and two dimension arrays.

Bug fixes / internal changes:
- (None)

## 1.1.0 - 08 October 2019

Breaking changes:
- (None)

New features:
- Added IEnumerable extension methods for element selection or default.

Bug fixes / internal changes:
- (None)

## 1.0.1 - 30 September 2019

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- XML documentation now output on build and included in nuget package.

## 1.0.0 - 28 September 2019

Initial version.
