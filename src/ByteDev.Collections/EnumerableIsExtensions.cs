using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    public static class EnumerableIsExtensions
    {
        /// <summary>Determines if the enumerable has zero elements.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to check if is empty.</param>
        /// <returns>True if empty; otherwise returns false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool IsEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return !source.Any();
        }

        /// <summary>Determines if the enumerable is null or is empty.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to check if is null or empty.</param>
        /// <returns>True if null or empty; otherwise returns false.</returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return source == null || source.IsEmpty();
        }

        /// <summary>Determines if the enumerable has exactly one element.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to check if contains exactly one element.</param>
        /// <returns>True if contains one element; otherwise returns false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool IsSingle<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Count() == 1;
        }

        /// <summary>Determines if two enumerables are equivalent. The order of items does not matter.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The original enumerable to check against.</param>
        /// <param name="other">The other enumerable to check against.</param>
        /// <returns>True if both enumerables are equivalent; otherwise returns false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool IsEquivalentTo<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (other == null)
                return false;

            if (source.Count() != other.Count())
                return false;

            return source.Except(other).IsEmpty();
        }
    }
}