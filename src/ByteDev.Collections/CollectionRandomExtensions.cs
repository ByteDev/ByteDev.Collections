using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.ICollection`1" />. 
    /// </summary>
    public static class CollectionRandomExtensions
    {
        private static readonly Random _random = new Random();

        private static readonly object _lock = new object();

        /// <summary>
        /// Returns a random element from the collection.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to return a random element from.</param>
        /// <returns>A randomly selected element.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="source" /> is empty.</exception>
        public static TSource GetRandom<TSource>(this ICollection<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var value = GetRandomOrDefault(source);

            if (value.Equals(default(TSource)))
                throw new ArgumentException("Collection is empty.", nameof(source));
            
            return value;
        }

        /// <summary>
        /// Returns a random element from the collection. If the collection is null or empty
        /// the default value will be returned.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to return a random element from.</param>
        /// <param name="default">Default value to return if collection is null or empty.</param>
        /// <returns>A randomly selected element or default.</returns>
        public static TSource GetRandomOrDefault<TSource>(this ICollection<TSource> source, TSource @default = default)
        {
            if (source == null || source.Count < 1)
                return @default;

            var index = source.GetRandomIndex();

            return source.ElementAt(index);
        }

        internal static int GetRandomIndex<TSource>(this ICollection<TSource> source)
        {
            lock (_lock)
            {
                return _random.Next(source.Count);
            }
        }
    }
}