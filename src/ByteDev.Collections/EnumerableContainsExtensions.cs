using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.IEnumerable`1" />. 
    /// </summary>
    public static class EnumerableContainsExtensions
    {
        /// <summary>
        /// Determines whether a collection contains all the values in a sequence by
        /// using the default equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to check.</param>
        /// <param name="values">Sequence of values to check are contained.</param>
        /// <returns>True if all values in the sequence are contained in the collection; otherwise false.</returns>
        public static bool ContainsAll<TSource>(this IEnumerable<TSource> source, params TSource[] values)
        {
            return ContainsAll(source, values, default);
        }

        /// <summary>
        /// Determines whether a collection contains all the values in a sequence by
        /// using the default equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to check.</param>
        /// <param name="values">Sequence of values to check are contained.</param>
        /// <returns>True if all values in the sequence are contained in the collection; otherwise false.</returns>
        public static bool ContainsAll<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> values)
        {
            return ContainsAll(source, values, default);
        }

        /// <summary>
        /// Determines whether a collection contains all the values in a sequence by
        /// using the specified equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to check.</param>
        /// <param name="values">Sequence of values to check are contained.</param>
        /// <param name="comparer">Comparer to use when performing the contains operation.</param>
        /// <returns>True if all values in the sequence are contained in the collection; otherwise false.</returns>
        public static bool ContainsAll<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> values, IEqualityComparer<TSource> comparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (values == null)
                throw new ArgumentNullException(nameof(values));

            foreach (var value in values)
            {
                if (!source.Contains(value, comparer))
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Determines whether a collection contains any of the values in a sequence by
        /// using the default equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to check.</param>
        /// <param name="values">Sequence of values to check if any are contained.</param>
        /// <returns>True if any values in the sequence are contained in the collection; otherwise false.</returns>
        public static bool ContainsAny<TSource>(this IEnumerable<TSource> source, params TSource[] values)
        {
            return ContainsAny(source, values, default);
        }

        /// <summary>
        /// Determines whether a collection contains any of the values in a sequence by
        /// using the default equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to check.</param>
        /// <param name="values">Sequence of values to check if any are contained.</param>
        /// <returns>True if any values in the sequence are contained in the collection; otherwise false.</returns>
        public static bool ContainsAny<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> values)
        {
            return ContainsAny(source, values, default);
        }

        /// <summary>
        /// Determines whether a collection contains any of the values in a sequence by
        /// using the specified equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to check.</param>
        /// <param name="values">Sequence of values to check if any are contained.</param>
        /// <param name="comparer">Comparer to use when performing the contains operation.</param>
        /// <returns>True if all values in the sequence are contained in the collection; otherwise false.</returns>
        public static bool ContainsAny<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> values, IEqualityComparer<TSource> comparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (values == null)
                throw new ArgumentNullException(nameof(values));

            foreach (var value in values)
            {
                if (source.Contains(value, comparer))
                    return true;
            }

            return false;
        }
    }
}