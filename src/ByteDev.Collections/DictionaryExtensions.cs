using System;
using System.Collections.Generic;

namespace ByteDev.Collections
{
    public static class DictionaryExtensions
    {
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var kvp in items)
            {
                if (source.ContainsKey(kvp.Key))
                {
                    throw new ArgumentException("An item with the same key has already been added.");
                }
                source.Add(kvp);
            }
        }

        public static void AddOrUpdateRange<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
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

        public static TValue GetValueIgnoreKeyCase<TValue>(this IDictionary<string, TValue> source, string key)
        {
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