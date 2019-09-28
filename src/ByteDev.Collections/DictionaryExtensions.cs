using System;
using System.Collections.Generic;

namespace ByteDev.Collections
{
    public static class DictionaryExtensions
    {
        /// <summary>Add a range of items to the source dictionary.</summary>
        /// <typeparam name="TKey">The type of the keys of <paramref name="source" />.</typeparam>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to add the range of items to.</param>
        /// <param name="items">The items to add to the dictionary.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="items" /> is null.</exception>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var kvp in items)
            {
                source.Add(kvp);
            }
        }

        /// <summary>Add a range of items to the source dictionary. If a key already exists its value will be updated.</summary>
        /// <typeparam name="TKey">The type of the keys of <paramref name="source" />.</typeparam>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to add or update the range of items to.</param>
        /// <param name="items">The items to add or update to the dictionary.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="items" /> is null.</exception>
        public static void AddOrUpdateRange<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var kvp in items)
            {
                if (source.ContainsKey(kvp.Key))
                {
                    source[kvp.Key] = kvp.Value;
                }
                else
                {
                    source.Add(kvp);
                }
            }
        }

        /// <summary>Gets a value from the dictionary using a key in a case insensitive manner.</summary>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to add or update the range of items to.</param>
        /// <param name="key">Key to use in retrieving the value.</param>
        /// <returns>Value based on the key provided. If key does not exist then default is returned.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="key" /> is null or empty.</exception>
        public static TValue GetValueIgnoreKeyCase<TValue>(this IDictionary<string, TValue> source, string key)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(nameof(key));

            foreach (var element in source)
            {
                if (string.Equals(element.Key, key, StringComparison.OrdinalIgnoreCase))
                {
                    return element.Value;
                }
            }

            return default(TValue);
        }
    }
}