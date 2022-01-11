using System;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for single dimension <see cref="T:System.Array" />.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Populates every element of the array with <paramref name="values" />.
        /// </summary>
        /// <typeparam name="TSource">Array element type.</typeparam>
        /// <param name="source">The array to populate.</param>
        /// <param name="values">The set of values to populate the array with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void Populate<TSource>(this TSource[] source, params TSource[] values)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var valuesIndex = 0;

            for (var i = 0; i < source.Length; i++)
            {
                if (values == null)
                {
                    source[i] = default;
                }
                else
                {
                    if (valuesIndex >= values.Length)
                        valuesIndex = 0;

                    source[i] = values[valuesIndex];
                    valuesIndex++;
                }
            }
        }

        /// <summary>
        /// Gets the total number of elements in the array. If the array is null then zero is returned.
        /// </summary>
        /// <typeparam name="TSource">Array element type.</typeparam>
        /// <param name="source">The array to perform the operation on.</param>
        /// <returns>Zero if the array is null; otherwise the array length.</returns>
        public static int SafeLength<TSource>(this TSource[] source)
        {
            return source?.Length ?? 0;
        }
    }
}