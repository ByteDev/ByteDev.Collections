using System.Collections.Generic;

namespace ByteDev.Collections
{
    /// <summary>
    /// Represents a simple factory for creating enumerable types.
    /// </summary>
    public static class EnumerableFactory
    {
        /// <summary>
        /// Create a enumerable sequence from the provided items.
        /// </summary>
        /// <typeparam name="T">Type of enumerable elements.</typeparam>
        /// <param name="items">Items to add as elements to the enumerable type.</param>
        /// <returns>Enumerable containing the provided items.</returns>
        public static IEnumerable<T> CreateFrom<T>(params T[] items)
        {
            foreach (var element in items)
            {
                yield return element;
            }
        }
    }
}