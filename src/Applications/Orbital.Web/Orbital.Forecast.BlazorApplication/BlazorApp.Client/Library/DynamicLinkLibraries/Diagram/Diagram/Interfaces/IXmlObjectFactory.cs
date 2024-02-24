using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


using CategoryTheory;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Factory of objects from xml
    /// </summary>
    public interface IXmlObjectFactory
    {
        /// <summary>
        /// Creates objects
        /// </summary>
        /// <param name="element">XmlElement</param>
        /// <param name="categoryObject">Object</param>
        void Create(XElement element, ref ICategoryObject categoryObject);

        /// <summary>
        /// Objects of factrory
        /// </summary>
        IDictionary<string, ICategoryObject> Dictionary
        {
            get;
        }

        /// <summary>
        /// Desktop
        /// </summary>
        IDesktop Desktop
        {
            get;
        }

        /// <summary>
        /// List of objects
        /// </summary>
        IList<string> List
        {
            get;
        }
    }
}
