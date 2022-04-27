using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.IEnumerable`1" />. 
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns empty enumerable when null.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to return empty on if null.</param>
        /// <returns>Empty enumerable if null; otherwise the enumerable.</returns>
        public static IEnumerable<TSource> NullToEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return source ?? Enumerable.Empty<TSource>();
        }

        /// <summary>
        /// Apply the action to each element in the source.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to apply the action on.</param>
        /// <param name="action">The action to apply for each element.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> is null.</exception>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Returns the first element that matches the given predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to apply the predicate to.</param>
        /// <param name="predicate">Predicate to match on.</param>
        /// <returns>Element that matches the predicate; otherwise the default.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> is null.</exception>
        public static TSource Find<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }
            
            return default;
        }

        /// <summary>
        /// Determines whether all elements in a sequence are unique. Uniqueness of an 
        /// element is based on it's hash.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The sequence to check if all elements are unique.</param>
        /// <returns>True all elements are unique; otherwise false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool AllUnique<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var hashSet = new HashSet<TSource>();
            
            foreach (var item in source)
            {
                if (!hashSet.Add(item))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Concatenates the params to the sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The sequence to contatenate to.</param>
        /// <param name="values">Values to concatenate to the original sequence.</param>
        /// <returns>Sequence that contains both the original sequence and <paramref name="values" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="values" /> is null.</exception>
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> source, params TSource[] values)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return source.Concat(values as IEnumerable<TSource>);
        }

        /// <summary>
        /// Concatenates the elements of each sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The sequence to contatenate to.</param>
        /// <param name="sequences">The sequences to concatenate to the original sequence.</param>
        /// <returns>Sequence that contains both the original sequence and <paramref name="sequences" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="sequences" /> is null.</exception>
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> source, params IEnumerable<TSource>[] sequences)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (sequences == null)
                throw new ArgumentNullException(nameof(sequences));

            return ConcatAllElements(source, sequences);
        }

        private static IEnumerable<TSource> ConcatAllElements<TSource>(IEnumerable<TSource> source, params IEnumerable<TSource>[] sequences)
        {
            foreach (var value in source)
            {
                yield return value;
            }

            foreach (var sequence in sequences)
            {
                foreach (var value in sequence)
                {
                    yield return value;
                }
            }
        }
    }
}
