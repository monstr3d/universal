using System;
using System.Collections.Generic;
using System.Xml;

namespace Collada
{
    public interface ICollada
    {

        /// <summary>
        /// The unique id of element
        /// </summary>
        /// <param name="xmlElement">TheElement</param>
        /// <returns>The unique id</returns>
        string UniqueId(XmlElement xmlElement);

        /// <summary>
        /// Clears itself
        /// </summary>
        void Clear();

        /// <summary>
        /// Puts Xml element
        /// </summary>
        /// <param name="xmlElement"></param>
        void Put(XmlElement xmlElement);

        /// <summary>
        /// The unknown element
        /// </summary>
        /// <param name="xmlElement">The element</param>
        /// <returns>Thue if it is unknown</returns>
        bool IsUnknown(XmlElement xmlElement);

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="xmlElement"></param>
        void Init(XmlElement xmlElement);
    }
}
