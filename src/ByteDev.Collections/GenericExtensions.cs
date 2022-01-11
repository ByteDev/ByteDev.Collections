using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for generic types.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Returns a value as a single element enumerable sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the source to perform the operation on.</typeparam>
        /// <param name="source">The value to return in a single element sequence.</param>
        /// <returns>Sequence with the value as the only element.</returns>
        public static IEnumerable<TSource> AsEnumerable<TSource>(this TSource source)
        {
            return Enumerable.Repeat(source, 1);
        }

        /// <summary>
        /// Returns a enumerable sequence containing <paramref name="source" /> as the first element and
        /// the provided params as the subsequent elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the source to perform the operation on.</typeparam>
        /// <param name="source">The value to return in a single element sequence.</param>
        /// <param name="items">Items for the second, third etc. elements.</param>
        /// <returns>Sequence containing <paramref name="source" /> and <paramref name="items" /> as elements.</returns>
        public static IEnumerable<TSource> AsEnumerable<TSource>(this TSource source, params TSource[] items)
        {
            yield return source;

            foreach (var item in items)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Returns a value as a single element list.
        /// </summary>
        /// <typeparam name="TSource">The type of the source to perform the operation on.</typeparam>
        /// <param name="source">The value to return in a single element list.</param>
        /// <returns>List with the value as the only element.</returns>
        public static IList<TSource> AsList<TSource>(this TSource source)
        {
            return new List<TSource> { source };
        }
    }
}