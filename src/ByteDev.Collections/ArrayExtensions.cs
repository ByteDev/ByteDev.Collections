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
                    source[i] = default(TSource);
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
    }
}