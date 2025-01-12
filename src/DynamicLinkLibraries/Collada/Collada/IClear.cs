using System;
using System.Collections.Generic;

namespace Collada
{
    /// <summary>
    /// Clear interface
    /// </summary>
    public interface IClear
    {
        /// <summary>
        /// Clear
        /// </summary>
        void Clear();

        void PutObject(string key, object value);
    }

    public class DictionayClear<T> : Dictionary<string, T>, IClear where T : class
    {
        public DictionayClear() { }

        public void Put(string key, T value)
        {
            if (this.ContainsKey(key))
            {
                throw new InvalidOperationException();
            }
            this[key] = value;
        }

        public void Put(string key, object value)
        {
            if (this.ContainsKey(key))
            {
                throw new InvalidOperationException();
            }
            if (value is T t)
            {
                this[key] = t;
            }
        }


        public T Get(string key)
        {
            if (!ContainsKey(key))
            {
                return null;
            }
            return this[key];
        }

        void IClear.Clear()
        {
            base.Clear();
        }

        void IClear.PutObject(string key, object value)
        {
            if (value is T t)
            { 
                this[key] = t;
            }
        }
    }
}