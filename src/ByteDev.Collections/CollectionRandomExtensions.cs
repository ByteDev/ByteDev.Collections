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
        /// <param name="source">The collection to return a random element from.</param>
        /// <returns>A randomly selected element.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source" /> is empty.</exception>
        public static TSource TakeRandom<TSource>(this ICollection<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Count == 0)
                throw new InvalidOperationException("Collection is empty.");
    
            var index = source.GetRandomIndex();

            return source.ElementAt(index);
        }

        /// <summary>
        /// Returns a specified number of elements selected randomly from the collection.
        /// Similar to Take method except elements are selected randomly not sequentially.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to return a random element from.</param>
        /// <param name="count">The number of elements to return.</param>
        /// <returns>Sequence of elements randomly selected.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static IEnumerable<TSource> TakeRandom<TSource>(this ICollection<TSource> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            return TakeRandomYield(source, count);
        }

        /// <summary>
        /// Takes a random element from the collection, removes it from the collection, then returns it.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The collection to return a random element from.</param>
        /// <returns>A randomly selected element.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source" /> is empty.</exception>
        public static TSource RemoveRandom<TSource>(this ICollection<TSource> source)
        {
            var item = TakeRandom(source);
            
            source.Remove(item);

            return item;
        }

        internal static int GetRandomIndex<TSource>(this ICollection<TSource> source)
        {
            lock (_lock)
            {
                return _random.Next(source.Count);
            }
        }

        private static IEnumerable<TSource> TakeRandomYield<TSource>(this ICollection<TSource> source, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var index = source.GetRandomIndex();

                var value = source.ElementAt(index);
                
                yield return value;
            }
        }
    }
}