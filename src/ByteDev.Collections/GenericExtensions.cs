using System.Collections.Generic;

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
            yield return source;
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