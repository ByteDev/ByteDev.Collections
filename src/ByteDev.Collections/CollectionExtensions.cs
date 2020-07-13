using System;
using System.Collections.Generic;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.ICollection`1" />. 
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Fills an empty list's given number of elements with a value.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to perform the operation on.</param>
        /// <param name="numberToFill">Number of elements to fill.</param>
        /// <param name="value">The value to fill with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source" /> is not empty.</exception>
        public static void Fill<TSource>(this ICollection<TSource> source, int numberToFill, TSource value)
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
    }
}