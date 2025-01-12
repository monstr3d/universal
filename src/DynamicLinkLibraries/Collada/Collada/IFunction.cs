using System;
using System.Xml;

namespace Collada
{
    /// <summary>
    /// Function
    /// </summary>
    public interface IFunction
    {
        /// <summary>
        /// Function for objects
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <returns>Function</returns>
        Func<XmlElement, object> this[XmlElement xmlElement] { get; }

        /// <summary>
        /// Combine
        /// </summary>
        /// <param name="xmlElement">Xml element</param>
        /// <param name="object"></param>
        /// <returns>Function</returns>
        Func<XmlElement, object, object> Combine(XmlElement xmlElement, object obj);

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

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="xmlElement"></param>
        void Init(XmlElement xmlElement);

        /// <summary>
        /// File name
        /// </summary>
        string Filename { get; set; }


    }
}
