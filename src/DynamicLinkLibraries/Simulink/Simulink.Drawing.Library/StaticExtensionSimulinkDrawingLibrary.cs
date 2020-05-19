using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulink.Drawing.Library
{
    internal static class StaticExtensionSimulinkDrawingLibrary
    {
        /// <summary>
        /// Gets attribute
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="name">Name</param>
        /// <returns>Attribute</returns>
        internal static string GetAttributeLocal(this XElement element, string name)
        {
            return element.Attribute(System.Xml.Linq.XName.Get(name)).Value;
        }

        /// <summary>
        /// Gets child nodes
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>Child nodes</returns>
        internal static IEnumerable<XElement> GetChildNodesLocal(this XElement element)
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
        internal static IEnumerable<XElement> GetElementsByTagNameLocal(this XElement element, string tag)
        {
            return element.Elements(XName.Get(tag));
        }

        /// Gets First element by tag name
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="tag">Tag</param>
        /// <returns>Elementa</returns>
        internal static IEnumerable<XElement> GetFirstLocal(this XElement element, string tag)
        {
            IEnumerable<XElement> c = element.GetElementsByTagNameLocal(tag);
            foreach (XElement e in c)
            {
                return c;
            }
            return null;
        }

    }
}
