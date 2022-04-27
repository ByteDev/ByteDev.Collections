using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Specialized.NameValueCollection" />.
    /// </summary>
    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Add or update the key value pair.
        /// </summary>
        /// <param name="source">The name value collection to perform the operation on.</param>
        /// <param name="key">The key to use when adding or updating the name value collection.</param>
        /// <param name="value">The value to use when adding or updating the name value collection.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AddOrUpdate(this NameValueCollection source, string key, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.ContainsKey(key))
                source[key] = value;
            else
                source.Add(key, value);
        }

        /// <summary>
        /// Adds a key value pair if the key does not already exist.
        /// </summary>
        /// <param name="source">The name value collection to perform the operation on.</param>
        /// <param name="key">The key to use when checking if exists and adding if it does not.</param>
        /// <param name="value">The value to add to the name value collection.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static void AddIfNotContainsKey(this NameValueCollection source, string key, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (!source.ContainsKey(key))
                source.Add(key, value);
        }

        /// <summary>
        /// Check if <paramref name="source" /> contains a key.
        /// </summary>
        /// <param name="source">The name value collection to perform the operation on.</param>
        /// <param name="key">The key to check if is being used or not.</param>
        /// <returns>True if the name value collection contains the key; otherwise returns false.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static bool ContainsKey(this NameValueCollection source, string key)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            if (source.Get(key) == null)
                return source.AllKeys.Contains(key);
            
            return true;
        }

        /// <summary>
        /// Converts <paramref name="source" /> to dictionary.
        /// </summary>
        /// <param name="source">The name value collection to perform the operation on.</param>
        /// <returns>Dictionary with string keys and string values.</returns>
        public static IDictionary<string, string> ToDictionary(this NameValueCollection source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.AllKeys.ToDictionary(key => key, key => source[key]);
        }
    }
}
