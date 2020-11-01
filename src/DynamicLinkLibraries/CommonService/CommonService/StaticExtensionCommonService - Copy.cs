using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonService
{
    /// <summary>
    /// Static extensions
    /// </summary>
    public static class StaticExtensionCommonService
    {
        /// <summary>
        /// Inverts dictionary
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="dictionary">Souce dictionary</param>
        /// <returns>Inversion result</returns>
        public static Dictionary<TValue, TKey>
            Invert<TKey, TValue>(this Dictionary<TKey, TValue>
            dictionary)
        {
            Dictionary<TValue, TKey> d =
                new Dictionary<TValue, TKey>();
            foreach (TKey key in dictionary.Keys)
            {
                d[dictionary[key]] = key;
            }
            return d;
        }

        /// <summary>
        /// Gets Nullabe value
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="dictionary">Souce dictionary</param>
        /// <param name="key">Key</param>
        /// <returns>Nullable value</returns>
        public static TValue GetNullableValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            TKey key) where TValue : class
        {
            if (!dictionary.ContainsKey(key))
            {
                return null;
            }
            return dictionary[key];
        }
    }
}