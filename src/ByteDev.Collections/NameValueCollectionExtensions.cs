using System;
using System.Collections.Specialized;
using System.Linq;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for NameValueCollection.
    /// </summary>
    public static class NameValueCollectionExtensions
    {
        /// <summary>Add or update the key value pair.</summary>
        /// <param name="source">The name value collection to add or update the key value pair on.</param>
        /// <param name="key">The key to use when adding or updating the name value collection.</param>
        /// <param name="value">The value to use when adding or updating the name value collection.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AddOrUpdate(this NameValueCollection source, string key, string value)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.ContainsKey(key))
                source[key] = value;
            else
                source.Add(key, value);
        }

        /// <summary>Check if the name value collection contains a key.</summary>
        /// <param name="source">The name value collection to check if key exists.</param>
        /// <param name="key">The key to check if is being used or not.</param>
        /// <returns>True if the name value collection contains the key; otherwise false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool ContainsKey(this NameValueCollection source, string key)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Get(key) == null)
            {
                return source.AllKeys.Contains(key);
            }

            return true;
        }
    }
}
