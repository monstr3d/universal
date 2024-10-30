using System;
using System.Collections.Generic;
using System.Xml;

namespace Collada
{
    public interface ICollada
    {
        /// <summary>
        /// Creation functions
        /// </summary>
        Dictionary<string, Func<XmlElement, object>> Functions { get; }

        /// <summary>
        /// Combination function
        /// </summary>
        Dictionary<Type, Func<XmlElement, object, object>> Combined { get; }

        /// <summary>
        /// Clones object
        /// </summary>
        /// <param name="obj">The object to clone</param>
        /// <returns>CCloned object</returns>
        object Clone(object obj);

        /// <summary>
        /// Clears itself
        /// </summary>
        void Clear();

    }
}
