using System;
using System.Collections.Generic;

namespace ByteDev.Collections
{
    public static class EnumeratorExtensions
    {
        /// <summary>
        /// Advances the enumerator to the next element in the sequence based on the provided move count.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The instance to perform the operation on.</param>
        /// <param name="moveCount">The number of moves forward the enumerator should perform. Value should be 1 or more.</param>
        /// <returns>True if the enumerator was successfully advanced to the required element; false if the enumerator has passed the end of the sequence.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool MoveNext<TSource>(this IEnumerator<TSource> source, int moveCount)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (moveCount < 1)
                throw new ArgumentOutOfRangeException(nameof(moveCount), "Move count must be 1 or greater.");

            for (var i = 0; i < moveCount; i++)
            {
                if (source.MoveNext() == false)
                    return false;
            }

            return true;
        }
    }
}