using System.Collections.Generic;
using System.Text;

namespace ByteDev.Collections
{
    public static class EnumerableToExtensions
    {
        /// <summary>Returns the enumerable as a delimited string.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to return as a delimited string.</param>
        /// <param name="delimiter">Delimiter to use between elements.</param>
        /// <returns>The enumerable as a delimited string.</returns>
        public static string ToDelimitedString<TSource>(this IEnumerable<TSource> source, string delimiter)
        {
            if (source == null)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var element in source)
            {
                if (sb.Length == 0)
                {
                    sb.Append(element);
                }
                else
                {
                    sb.Append(delimiter);
                    sb.Append(element);
                }
            }

            return sb.ToString();
        }

        /// <summary>Returns the enumerable as a comma separated value string.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The enumerable to return as a delimited string.</param>
        /// <returns>The enumerable as a comma separated string.</returns>
        public static string ToCsv<TSource>(this IEnumerable<TSource> source)
        {
            return ToDelimitedString(source, ",");
        }         
    }
}