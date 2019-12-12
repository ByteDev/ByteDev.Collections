﻿using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <param name="source">The list to return empty on if null.</param>
        /// <returns>Empty list if null; otherwise returns the list.</returns>
        public static IList<TSource> NullToEmpty<TSource>(this IList<TSource> source)
        {
            return source ?? new List<TSource>();
        }

        /// <summary>
        /// Fills an empty list's given number of elements with a value.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to fill.</param>
        /// <param name="numberToFill">Number of elements to fill.</param>
        /// <param name="value">The value to fill with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source" /> is not empty.</exception>
        public static void Fill<TSource>(this IList<TSource> source, int numberToFill, TSource value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Count > 0)
                throw new InvalidOperationException("List is not empty. Cannot fill non-empty list.");

            for (var i = 0; i < numberToFill; i++)
            {
                source.Add(value);
            }
        }

        /// <summary>
        /// Moves the first occurence of <paramref name="item" /> to first position.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to move to first on.</param>
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
        /// <param name="source">The list to move to last on.</param>
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
        /// Removes all elements where the predicate is true.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to remove on.</param>
        /// <param name="predicate">The predicate to evaluate against each element.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> is null.</exception>
        public static void RemoveWhere<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if(predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            source.Where(predicate)
                .ToArray()
                .ForEach(element => source.Remove(element));
        }
    }
}
