using System;
using System.Text;

namespace ByteDev.Collections
{
    internal static class StringBuilderExtensions
    {
        public static void AppendIfNotEmpty(this StringBuilder source, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Length > 0)
                source.Append(value);
        }
    }
}