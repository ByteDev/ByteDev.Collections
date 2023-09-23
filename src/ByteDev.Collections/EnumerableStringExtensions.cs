using System;
using System.Collections.Generic;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.IEnumerable`1" />
    /// with elements of type <see cref="T:System.String" />.
    /// </summary>
    public static class EnumerableStringExtensions
    {
        /// <summary>
        /// Returns the first longest string in <paramref name="source" />; otherwise null if <paramref name="source" /> is empty.
        /// </summary>
        /// <param name="source"><see cref="T:System.Collections.Generic.IEnumerable`1" /> to search for the longest string in.</param>
        /// <returns>Longest string in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static string FirstLongest(this IEnumerable<string> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            string longest = null;

            foreach (var element in source)
            {
                if (element == null)
                    continue;

                if (longest == null || element.Length > longest.Length)
                    longest = element;
            }

            return longest;
        }
        
        /// <summary>
        /// Returns the first shortest string in <paramref name="source" />; otherwise null if <paramref name="source" /> is empty.
        /// </summary>
        /// <param name="source"><see cref="T:System.Collections.Generic.IEnumerable`1" /> to search for the shortest string in.</param>
        /// <returns>Shortest string in <paramref name="source" />.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static string FirstShortest(this IEnumerable<string> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            string shortest = null;

            foreach (var element in source)
            {
                if (element == null)
                    continue;

                if (shortest == null || element.Length < shortest.Length)
                    shortest = element;
            }

            return shortest;
        }
    }
}