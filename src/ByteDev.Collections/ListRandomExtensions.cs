using System;
using System.Collections.Generic;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.IList`1" />. 
    /// </summary>
    public static class ListRandomExtensions
    {
        /// <summary>
        /// Randomly shuffles all the elements in the list.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The list to perform the operation on.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void Shuffle<TSource>(this IList<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            for (int i = 0; i < source.Count; i++)
            {
                var targetIndex = source.GetRandomIndex();

                source.Swap(i, targetIndex);
            }
        }
    }
}