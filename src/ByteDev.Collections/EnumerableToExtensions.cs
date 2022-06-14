using System.Collections.Generic;
using System.Text;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.IEnumerable`1" />.
    /// </summary>
    public static class EnumerableToExtensions
    {
        /// <summary>
        /// Returns the sequence as a delimited string.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to return as a delimited string.</param>
        /// <param name="delimiter">Delimiter to use between elements.</param>
        /// <returns>The sequence as a delimited string.</returns>
        public static string ToDelimitedString<TSource>(this IEnumerable<TSource> source, string delimiter)
        {
            if (source == null)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var element in source)
            {
                sb.AppendIfNotEmpty(delimiter);
                sb.Append(element);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns the sequence as a string with each element wrapped in the left and right string.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to return as a delimited string.</param>
        /// <param name="left">String to wrap each element on the left with.</param>
        /// <param name="right">String to wrap each element on the right with.</param>
        /// <returns>The sequence as a string with each element wrapped.</returns>
        public static string ToWrappedString<TSource>(this IEnumerable<TSource> source, string left, string right)
        {
            if (source == null)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var element in source)
            {
                sb.Append(left);
                sb.Append(element);
                sb.Append(right);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns the enumerable as a comma separated value string.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to return as a delimited string.</param>
        /// <returns>The enumerable as a comma separated string.</returns>
        public static string ToCsv<TSource>(this IEnumerable<TSource> source)
        {
            return ToDelimitedString(source, ",");
        }
    }
}