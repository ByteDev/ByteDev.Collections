using System;
using System.Collections.Generic;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.IList`1" />. 
    /// </summary>
    public static class ListReplaceExtensions
    {
        /// <summary>
        /// Replaces the item at the specified index with the new value.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to perform the operation on.</param>
        /// <param name="index">The element index position to replace.</param>
        /// <param name="newValue">The new value to replace with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index" /> is less than zero or greater than number of elements in the sequence.</exception>
        public static void ReplaceAt<TSource>(this IList<TSource> source, int index, TSource newValue)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (!source.IsIndexValid(index))
                throw new ArgumentOutOfRangeException(nameof(index), "Index is less than zero or greater than the number of elements in the sequence.");

            ReplaceAtUnsafe(source, index, newValue);
        }

        /// <summary>
        /// Replaces all elements with <paramref name="originalValue" /> with <paramref name="newValue" />.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to perform the operation on.</param>
        /// <param name="originalValue">The element value to replace.</param>
        /// <param name="newValue">The new value to replace with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void ReplaceAll<TSource>(this IList<TSource> source, TSource originalValue, TSource newValue)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            for (var i = 0; i < source.Count; i++)
            {
                if (source[i].Equals(originalValue))
                    source.ReplaceAtUnsafe(i, newValue);
            }
        }

        /// <summary>
        /// Replaces all elements where the predicate is true with <paramref name="newValue" />.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to perform the operation on.</param>
        /// <param name="predicate">Predicate used on each element value to determine if should do a replace.</param>
        /// <param name="newValue">The new value to replace with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> is null.</exception>
        public static void ReplaceAll<TSource>(this IList<TSource> source, Predicate<TSource> predicate, TSource newValue)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                    source.ReplaceAtUnsafe(i, newValue);
            }
        }

        private static void ReplaceAtUnsafe<TSource>(this IList<TSource> source, int index, TSource newValue)
        {
            source.RemoveAt(index);
            source.Insert(index, newValue);
        }
    }
}