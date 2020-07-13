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
    }
}
