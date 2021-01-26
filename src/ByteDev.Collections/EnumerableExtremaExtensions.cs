using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.IEnumerable`1" /> concerning the
    /// maximum and minimum. 
    /// </summary>
    public static class EnumerableExtremaExtensions
    {
        /// <summary>
        /// Returns all elements from a sequence with the maximum value.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <typeparam name="TKey">Type of key value.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the elements from.</param>
        /// <param name="selector">Func to describe what property to select.</param>
        /// <param name="comparer">Comparer to use. If null then default will be used for <typeparamref name="TKey" />.</param>
        /// <returns>All elements with the maximum value.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static IList<TSource> MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer = null) where TKey : IComparable<TKey> 
        {
            if (source == null) 
                throw new ArgumentNullException(nameof(source));

            comparer = comparer ?? Comparer<TKey>.Default;

            using (var enumerator = source.GetEnumerator())
            {
                var list = new List<TSource>();

                if (!enumerator.MoveNext())
                    return list;
                
                list.Add(enumerator.Current);
                TKey maxKey = selector(list.First());
                
                while (enumerator.MoveNext())
                {
                    TKey key = selector(enumerator.Current);

                    if (comparer.Compare(key, maxKey) > 0)
                    {
                        list.Clear();
                        list.Add(enumerator.Current);
                        maxKey = key;
                    }
                    else if (comparer.Compare(key, maxKey) == 0)
                    {
                        list.Add(enumerator.Current);
                    }
                }
                
                return list;
            }
        }

        /// <summary>
        /// Returns all elements from a sequence with the minimum value.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <typeparam name="TKey">Type of key value.</typeparam>
        /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to return the elements from.</param>
        /// <param name="selector">Func to describe what property to select.</param>
        /// <param name="comparer">Comparer to use. If null then default will be used for <typeparamref name="TKey" />.</param>
        /// <returns>All elements with the minimum value.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static IList<TSource> MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer = null) where TKey : IComparable<TKey> 
        {
            if (source == null) 
                throw new ArgumentNullException(nameof(source));

            comparer = comparer ?? Comparer<TKey>.Default;

            using (var enumerator = source.GetEnumerator())
            {
                var list = new List<TSource>();

                if (!enumerator.MoveNext())
                    return list;
                
                list.Add(enumerator.Current);
                TKey minKey = selector(list.First());
                
                while (enumerator.MoveNext())
                {
                    TKey key = selector(enumerator.Current);

                    if (comparer.Compare(key, minKey) < 0)
                    {
                        list.Clear();
                        list.Add(enumerator.Current);
                        minKey = key;
                    }
                    else if (comparer.Compare(key, minKey) == 0)
                    {
                        list.Add(enumerator.Current);
                    }
                }
                
                return list;
            }
        }
    }
}