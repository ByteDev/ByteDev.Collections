using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    public static class EnumerableExtensions
    {
        /// <summary>Returns empty enumerable when null.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to return empty on if null.</param>
        /// <returns>Empty enumerable if null; otherwise the enumerable.</returns>
        public static IEnumerable<TSource> NullToEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return source ?? Enumerable.Empty<TSource>();
        }

        /// <summary>Apply the action to each element in the source.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to apply the action on.</param>
        /// <param name="action">The action to apply for each element.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> is null.</exception>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
                action(item);
        }

        /// <summary>Returns the first element that matches the given predicate.</summary>
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

            return default(TSource);
        }
    }
}
