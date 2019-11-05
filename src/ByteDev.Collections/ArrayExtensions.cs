using System;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for single dimension <see cref="T:System.Array" />.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Populates every element of the array with <paramref name="value" />.
        /// </summary>
        /// <typeparam name="TSource">Array element type.</typeparam>
        /// <param name="source">The array to populate.</param>
        /// <param name="value">The value to populate the array with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void Populate<TSource>(this TSource[] source, TSource value)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            for (var i = 0; i < source.Length; i++)
            {
                source[i] = value;
            }
        }
    }
}