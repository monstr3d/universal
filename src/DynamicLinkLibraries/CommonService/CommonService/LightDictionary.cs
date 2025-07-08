using System;
using System.Collections.Generic;
using System.Linq;

using ErrorHandler;


namespace CommonService
{
    /// <summary>
    /// Light weight dictionary with ordered keys
    /// </summary>
    /// <typeparam name="TKey">Type of key</typeparam>
    /// <typeparam name="TValue">Type of value</typeparam>
    public class LightDictionary<TKey, TValue>
    {
        #region Fields

        List<TKey> l = new List<TKey>();

        Dictionary<TKey, TValue> d = new Dictionary<TKey, TValue>();

        #endregion


        #region Members

        /// <summary>
        /// Access to element
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public TValue this[TKey key]
        {
            set
            {
                if (l.Contains<TKey>(key))
                {
                    throw new ErrorHandler.OwnException("Key already exists");
                }
                l.Add(key);
                d[key] = value;
            }
            get
            {
                return d[key];
            }
        }

        /// <summary>
        /// Keys
        /// </summary>
        public IList<TKey> Keys
        {
            get
            {
                return l;
            }
        }

        /// <summary>
        /// Performs foreach ordered action
        /// </summary>
        /// <param name="action">The action</param>
        public void ForEach(Action<TValue> action)
        {
            foreach (TKey key in l)
            {
                action(d[key]);
            }
        }

        /// <summary>
        /// Performs foreach parametrized ordered action
        /// </summary>
        /// <typeparam name="TParameter">Type of parameter</typeparam>
        /// <param name="action">The action</param>
        /// <param name="parameter">The parameter</param>
        public void ForEach<TParameter>(Action<TValue, TParameter> action, TParameter parameter)
        {
            foreach (TKey key in l)
            {
                action(d[key], parameter);
            }
        }

        /// <summary>
        /// Performs foreach parametrized ordered action
        /// </summary>
        /// <typeparam name="P1">Type of 1 - st parameter</typeparam>
        /// <typeparam name="P2">Type of 2 - d parameter</typeparam>
        /// <param name="action">The action</param>
        /// <param name="p1">1 - st parameter</param>
        /// <param name="p2">2 - d parameter</param>
        public void ForEach<P1, P2>(Action<TValue, P1, P2> action, P1 p1, P2 p2)
        {
            foreach (TKey key in l)
            {
                action(d[key], p1, p2);
            }
        }

        /// <summary>
        /// Performs foreach parametrized ordered action
        /// </summary>
        /// <typeparam name="P1">Type of 1 - st parameter</typeparam>
        /// <typeparam name="P2">Type of 2 - d parameter</typeparam>
        /// <typeparam name="P3">Type of 3 - d parameter</typeparam>
        /// <param name="action">The action</param>
        /// <param name="p1">1 - st parameter</param>
        /// <param name="p2">2 - d parameter</param>
        /// <param name="p3">3 - d parameter</param>
        public void ForEach<P1, P2, P3>(Action<TValue, P1, P2, P3> action, P1 p1, P2 p2, P3 p3)
        {
            foreach (TKey key in l)
            {
                action(d[key], p1, p2, p3);
            }
        }

 

/*
        /// <summary>
        /// Performs foreach parametrized ordered action
        /// </summary>
        /// <typeparam name="P1">Type of 1 - st parameter</typeparam>
        /// <typeparam name="P2">Type of 2 - d parameter</typeparam>
        /// <typeparam name="P3">Type of 3 - d parameter</typeparam>
        /// <typeparam name="P4">Type of 4 -th parameter</typeparam>
        /// <param name="action">The action</param>
        /// <param name="p1">1 - st parameter</param>
        /// <param name="p2">2 - d parameter</param>
        /// <param name="p3">3 - d parameter</param>
        /// <param name="p4">4 -th parameter</param>
    /*    public void ForEach<P1, P2, P3, P4>(Action<TValue, P1, P2, P3, P4> action, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            foreach (TKey key in l)
            {
                action(d[key], p1, p2, p3, p4);
            }
        }*/

        /// <summary>
        /// Adds dictionary seetings
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        public void Add(LightDictionary<TKey, TValue> dictionary)
        {
            foreach (TKey key in dictionary.l)
            {
                this[key] = dictionary.d[key];
            }
        }

        /// <summary>
        /// Adds arrays
        /// </summary>
        /// <param name="keys">Array of keys</param>
        /// <param name="values">Array of values</param>
        public void Add(TKey[] keys, TValue[] values)
        {
            if (keys.Length != values.Length)
            {
                throw new OwnException("Lendth are not equal");
            }
            for (int i = 0; i < keys.Length; i++)
            {
                this[keys[i]] = values[i];
            }
        }

        /// <summary>
        /// Adds arrays
        /// </summary>
        /// <param name="keys">Array of keys</param>
        /// <param name="values">Array of values</param>
        public void Add(IList<TKey> keys, IList<TValue> values)
        {
            Add(keys.ToArray<TKey>(), values.ToArray<TValue>());
        }


        #endregion
    }
}
