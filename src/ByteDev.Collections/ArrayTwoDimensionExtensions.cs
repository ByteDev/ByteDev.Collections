using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for two dimension <see cref="T:System.Array" />.
    /// </summary>
    public static class ArrayTwoDimensionExtensions
    {
        /// <summary>
        /// Populates every element of the two dimension array with <paramref name="value" />.
        /// </summary>
        /// <typeparam name="TSource">Array element type.</typeparam>
        /// <param name="source">The array to populate.</param>
        /// <param name="value">The value to populate the array with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void Populate<TSource>(this TSource[,] source, TSource value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            for (var i = 0; i < source.GetLength(0); i++)
            {
                for (var j = 0; j < source.GetLength(1); j++)
                {
                    source[i, j] = value;
                }
            }
        }

        /// <summary>
        /// Retrieves a particular column by <paramref name="columnNumber" />.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The two dimension array to retrieve the column from.</param>
        /// <param name="columnNumber">Number of column to retrieve. First column is zero.</param>
        /// <returns>Column at number <paramref name="columnNumber" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource[] GetColumn<TSource>(this TSource[,] source, int columnNumber)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            return Enumerable.Range(0, source.GetRowCount())
                .Select(e => source[columnNumber, e])
                .ToArray();
        }

        /// <summary>
        /// Retrieves a particular row by <paramref name="rowNumber" />.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The two dimension array to retrieve the row from.</param>
        /// <param name="rowNumber">Number of row to retrieve. First row is zero.</param>
        /// <returns>Row at number <paramref name="rowNumber" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource[] GetRow<TSource>(this TSource[,] source, int rowNumber)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            return Enumerable.Range(0, source.GetColumnCount())
                .Select(e => source[e, rowNumber])
                .ToArray();
        }

        /// <summary>
        /// Gets the number of columns in <paramref name="source" />.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The two dimension array to get the column count on.</param>
        /// <returns>The number of columns in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static int GetColumnCount<TSource>(this TSource[,] source)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            return source.GetLength(0);
        }

        /// <summary>
        /// Gets the number of rows in <paramref name="source" />.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The two dimension array to get the row count on.</param>
        /// <returns>The number of rows in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static int GetRowCount<TSource>(this TSource[,] source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.GetLength(1);
        }

        /// <summary>
        /// Returns the two dimension array as a single dimension array. The returned array will contain
        /// a concatenation of each row. 
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The two dimension array to get the row count on.</param>
        /// <returns>Single dimension array.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static TSource[] ToSingleDimension<TSource>(this TSource[,] source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var array = new TSource[source.Length];
            var i = 0;

            for (var rowIndex = 0; rowIndex < source.GetRowCount(); rowIndex++)
            {
                for (var colIndex = 0; colIndex < source.GetColumnCount(); colIndex++)
                {
                    array[i] = source[colIndex, rowIndex];
                    i++;
                }
            }

            return array;
        }
    }
}