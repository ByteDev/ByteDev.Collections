﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.ICollection`1" />. 
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Fills an empty collection's given number of elements with a item.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to perform the operation on.</param>
        /// <param name="size">Number of elements to fill.</param>
        /// <param name="item">The item to fill with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source" /> is not empty.</exception>
        public static void Fill<TSource>(this ICollection<TSource> source, int size, TSource item)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Count > 0)
                throw new InvalidOperationException("Collection is not empty. Cannot fill non-empty collections.");

            for (var i = 0; i < size; i++)
                source.Add(item);
        }

        /// <summary>
        /// Determines if a index is valid (in range) for the collection.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to perform the operation on.</param>
        /// <param name="index">Index to check if valid.</param>
        /// <returns>True the index is valid; otherwise index is invalid.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool IsIndexValid<TSource>(this ICollection<TSource> source, int index)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return index >= 0 && index < source.Count;
        }

        /// <summary>
        /// Adds the elements of the provided sequence to the end of the items.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The items to perform the operation on.</param>
        /// <param name="items">The items whose elements will be added to the end.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="items" /> is null.</exception>
        /// <exception cref="T:System.NotSupportedException"><paramref name="source" /> is not writable.</exception>
        public static void AddRange<TSource>(this ICollection<TSource> source, IEnumerable<TSource> items)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (source is List<TSource> list)
            {
                list.AddRange(items);
            }
            else
            {
                foreach (var item in items)
                    source.Add(item);
            }
        }

        /// <summary>
        /// Add an item to the collection if the collection does not already contain it.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to perform the operation on.</param>
        /// <param name="item">Item to add to the collection.</param>
        /// <returns>True the item was added; otherwise false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool AddIfNotContains<TSource>(this ICollection<TSource> source, TSource item)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Contains(item))
                return false;

            source.Add(item);

            return true;
        }

        /// <summary>
        /// Removes all elements where the predicate is true.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to perform the operation on.</param>
        /// <param name="predicate">The predicate to evaluate against each element.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> is null.</exception>
        public static void RemoveWhere<TSource>(this ICollection<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            source.Where(predicate)
                .ToArray()
                .ForEach(element => source.Remove(element));
        }

        /// <summary>
        /// Adds the given item if it is not null.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to perform the operation on.</param>
        /// <param name="item">Item to add.</param>
        /// <returns>True if the item was added to the collection; otherwise false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool AddIfNotNull<TSource>(this ICollection<TSource> source, TSource item)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (item == null)
                return false;

            source.Add(item);

            return true;
        }
    }
}