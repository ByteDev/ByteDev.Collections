using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    public static class EnumerableIsExtensions
    {
        /// <summary>
        /// Determines if the collection has zero elements.
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return !source.Any();
        }

        /// <summary>
        /// Determines if the collection is null or has zero elements.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.IsEmpty();
        }

        /// <summary>
        /// Determines if the collection has exactly one element.
        /// </summary>
        public static bool IsSingle<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Count() == 1;
        }

        /// <summary>
        /// Checks that two enumerables are equivalent
        /// (order of items does not matter).
        /// </summary>
        public static bool IsEquivalentTo<T>(this IEnumerable<T> source, IEnumerable<T> other)
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