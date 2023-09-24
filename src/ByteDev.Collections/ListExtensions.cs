using System;
using System.Collections.Generic;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.IList`1" />. 
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Returns new empty list when null.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to perform the operation on.</param>
        /// <returns>Empty list if null; otherwise returns the list.</returns>
        public static IList<TSource> NullToEmpty<TSource>(this IList<TSource> source)
        {
            return source ?? new List<TSource>();
        }

        /// <summary>
        /// Moves the first occurence of <paramref name="item" /> to first position.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to perform the operation on.</param>
        /// <param name="item">The item to move to first position.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> is null.</exception>
        public static void MoveToFirst<TSource>(this IList<TSource> source, TSource item) where TSource : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!source.Contains(item))
                return;
            
            source.Remove(item);
            source.Insert(0, item);
        }

        /// <summary>
        /// Moves the first occurence of <paramref name="item" /> to last position.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to perform the operation on.</param>
        /// <param name="item">The item to move to last position.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> is null.</exception>
        public static void MoveToLast<TSource>(this IList<TSource> source, TSource item) where TSource : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!source.Contains(item))
                return;

            source.Remove(item);
            source.Insert(source.Count, item);
        }

        /// <summary>
        /// Swaps the item at one index for the item at another index.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to perform the operation on.</param>
        /// <param name="originalIndex">Index of original element to swap.</param>
        /// <param name="targetIndex">Index of target element to swap.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="originalIndex" /> is out of range.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="targetIndex" /> is out of range.</exception>
        public static void Swap<TSource>(this IList<TSource> source, int originalIndex, int targetIndex)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (!source.IsIndexValid(originalIndex))
                throw new ArgumentOutOfRangeException(nameof(originalIndex));

            if (!source.IsIndexValid(targetIndex))
                throw new ArgumentOutOfRangeException(nameof(targetIndex));

            if (targetIndex == originalIndex)
                return;

            var item = source[targetIndex];

            source[targetIndex] = source[originalIndex];
            source[originalIndex] = item;
        }

        /// <summary>
        /// Returns the element at the provided index using the indexer. If the index is invalid (out of range)
        /// then <paramref name="defaultValue" /> will be returned.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to perform the operation on.</param>
        /// <param name="index">Index of the object to return.</param>
        /// <param name="defaultValue">Default value to return if the index is out of range.</param>
        /// <returns>Object at the provided index position.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource SafeGet<TSource>(this IList<TSource> source, int index, TSource defaultValue = default)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.IsIndexValid(index) ? source[index] : defaultValue;
        }
    }
}
