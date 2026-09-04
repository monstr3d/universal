using System;
using System.Collections.Generic;
using System.Text;

using ErrorHandler;

using NamedTree.Interfaces;

namespace NamedTree
{
    /// <summary>
    /// Universal factory implemebtation
    /// </summary>
    public class UniversalFactory : IFactory
    {

        Dictionary<Type, object> dict = new();

        /// <summary>
        /// Gets a facrory
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <returns>The factory</returns>
        protected virtual T Get<T>() where T : class
        {
            var type = typeof(T);
            if (!dict.ContainsKey(type))
            {
                string err = "The type \"" + type + "\" is abscent";
                throw new OwnException(err);
            }
            return dict[type] as T;
        }

        /// <summary>
        /// Sets the factory
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="t">The factory</param>
        protected virtual void Set<T>(T t)
        {
            var type = typeof(T);
            if (dict.ContainsKey(type))
            {
                throw new OwnException("The type \"" + type.ToString() + "\" already exists");
            }
            dict[type] = t;
        }


        /// <summary>
        /// Gets a facrory
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="name">The name</param>
        /// <returns>The factory</returns>
        T IFactory.Get<T>()
        {
            return Get<T>();
        }

        /// <summary>
        /// Sets the factory
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="name">The name</param>
        /// <param name="t">The factory</param>
        void IFactory.Set<T>(T t)
        {
            Set<T>(t);
        }
    }
}
