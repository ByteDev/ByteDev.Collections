using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                return Enumerable.Empty<T>();
            }
            return source;
        }

        /// <summary>
        /// Apply the action to each element in the source
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Returns the first element that matches the given predicate
        /// </summary>
        public static T Find<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if(predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }
            return default(T);
        }
    }
}
