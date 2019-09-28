using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ByteDev.Collections
{
    public static class EnumerableToExtensions
    {
        public static string ToDelimitedString(this IEnumerable<object> source, string delimiter)
        {
            if (source == null || !source.Any())
            {
                return string.Empty;
            }
            return source.Aggregate((a, b) => string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", a, delimiter, b)).ToString();
        }

        public static string ToCsv(this IEnumerable<object> source)
        {
            return ToDelimitedString(source, ",");
        }         
    }
}