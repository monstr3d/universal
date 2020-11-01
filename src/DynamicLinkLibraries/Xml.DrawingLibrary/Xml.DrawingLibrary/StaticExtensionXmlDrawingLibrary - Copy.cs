using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xml.Drawing.Library
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionXmlDrawingLibrary
    {

        #region Public XML Members

        /// <summary>
        /// Gets child nodes
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>Child nodes</returns>
        public static IEnumerable<XElement> GetChildNodes(this XElement element)
        {
            IEnumerable<XElement> c = element.Elements();
            return c;
        }

        /// <summary>
        /// Gets elements by tag name
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="tag">Tag</param>
        /// <returns>Elementa</returns>
        public static IEnumerable<XElement> GetElementsByTagName(this XElement element, string tag)
        {
            return element.Elements(XName.Get(tag));
        }

        /// <summary>
        /// Gets attribute
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="name">Name</param>
        /// <returns>Attribute</returns>
        public static string GetAttribute(this XElement element, string name)
        {
            return element.Attribute(System.Xml.Linq.XName.Get(name)).Value;
        }

        /// <summary>
        /// Creates XElement
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The element</returns>
        public static XElement CreateXElement(string tag)
        {
            return XElement.Parse("<" + tag + "/>");
        }

        /// <summary>
        /// Creates XElement
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <param name="obj">The object</param>
        /// <returns>The element</returns>
        public static XElement CreateXElement(this object obj, string tag)
        {
            XElement e = CreateXElement(tag);
            if (obj is XElement)
            {
                (obj as XElement).Add(e);
            }
            return e;
        }

        #endregion

    }
}
