using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ByteDev.Collections
{
    /// <summary>
    /// Extension methods for <see cref="T:System.Collections.Generic.IDictionary`1" />.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adds a key value pair if the key does not already exist in the source dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of <paramref name="source" />.</typeparam>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to perform the operation on.</param>
        /// <param name="key">The object to use as the key of the element to check if exists and add.</param>
        /// <param name="value">The object to use as the value of the element to check if exists and add.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key">key</paramref> is null.</exception>
        public static void AddIfNotContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            if (!source.ContainsKey(key))
            {
                source.Add(key, value);
            }
        }

        /// <summary>
        /// Add a key value to the source dictionary. If a key already exists its value will be updated.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of <paramref name="source" />.</typeparam>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to perform the operation on.</param>
        /// <param name="key">The object to use as the key of the element to add or update.</param>
        /// <param name="value">The object to use as the value of the element to add or update.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key">key</paramref> is null.</exception>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
            
            if (source.ContainsKey(key))
            {
                source[key] = value;
            }
            else
            {
                source.Add(key, value);
            }
        }

        /// <summary>
        /// Add a key value to the source dictionary. If a key already exists its value will be updated if <paramref name="predicate"/> evaluates to true.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of <paramref name="source" />.</typeparam>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to perform the operation on.</param>
        /// <param name="key">The object to use as the key of the element to add or update.</param>
        /// <param name="value">The object to use as the value of the element to add or update.</param>
        /// <param name="predicate">Predicate to evaluate if the key exists.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key">key</paramref> is null.</exception>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value, Predicate<TValue> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if (source.ContainsKey(key))
            {
                if (predicate(source[key]))
                    source[key] = value;
            }
            else
            {
                source.Add(key, value);
            }
        }

        /// <summary>
        /// Add a range of items to the source dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of <paramref name="source" />.</typeparam>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to perform the operation on.</param>
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

        /// <summary>
        /// Add a range of items to the source dictionary. If a key already exists its value will be updated.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of <paramref name="source" />.</typeparam>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to perform the operation on.</param>
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

        /// <summary>
        /// Retrieves a list of values from the dictionary using a key in a case insensitive manner.
        /// </summary>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to perform the operation on.</param>
        /// <param name="key">Key to use in retrieving the value.</param>
        /// <returns>List of values based on the key provided.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="key" /> is null or empty.</exception>
        public static IList<TValue> GetValuesIgnoreKeyCase<TValue>(this IDictionary<string, TValue> source, string key)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(nameof(key));

            var values = new List<TValue>();

            foreach (var keyValuePair in source)
            {
                if (string.Equals(keyValuePair.Key, key, StringComparison.OrdinalIgnoreCase))
                    values.Add(keyValuePair.Value);
            }

            return values;
        }

        /// <summary>
        /// Retrieves the first value from the dictionary using a key in a case insensitive manner.
        /// </summary>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to perform the operation on.</param>
        /// <param name="key">Key to use in retrieving the value.</param>
        /// <returns>First value based on the key provided. If key does not exist then default is returned.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="key" /> is null or empty.</exception>
        public static TValue GetFirstValueIgnoreKeyCase<TValue>(this IDictionary<string, TValue> source, string key)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(nameof(key));

            foreach (var keyValuePair in source)
            {
                if (string.Equals(keyValuePair.Key, key, StringComparison.OrdinalIgnoreCase))
                    return keyValuePair.Value;
            }

            return default;
        }

        /// <summary>
        /// Determines whether a dictionary contains all of the keys in a sequence.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of <paramref name="source" />.</typeparam>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to perform the operation on.</param>
        /// <param name="keys">Sequence of keys.</param>
        /// <returns>True if the dictionary contains all the keys in the sequence; otherwise false.</returns>
        public static bool ContainsAllKey<TKey, TValue>(this IDictionary<TKey, TValue> source, params TKey[] keys)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (keys == null)
                throw new ArgumentNullException(nameof(keys));
            
            foreach (var key in keys)
            {
                if (!source.ContainsKey(key))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether a dictionary contains any of the keys in a sequence.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of <paramref name="source" />.</typeparam>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to perform the operation on.</param>
        /// <param name="keys">Sequence of keys.</param>
        /// <returns>True if the dictionary contains any of the keys in the sequence; otherwise false.</returns>
        public static bool ContainsAnyKey<TKey, TValue>(this IDictionary<TKey, TValue> source, params TKey[] keys)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            foreach (var key in keys)
            {
                if (source.ContainsKey(key))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Converts the dictionary to a NameValueCollection.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of <paramref name="source" />.</typeparam>
        /// <typeparam name="TValue">The type of the values of <paramref name="source" />.</typeparam>
        /// <param name="source">The dictionary to perform the operation on.</param>
        /// <returns>NameValueCollection representation of the dictionary.</returns>
        public static NameValueCollection ToNameValueCollection<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var nameValues = new NameValueCollection(source.Count);

            foreach (var item in source) 
            {
                nameValues.Add(item.Key.ToString(), item.Value.ToString());
            }

            return nameValues;
        }
    }
}