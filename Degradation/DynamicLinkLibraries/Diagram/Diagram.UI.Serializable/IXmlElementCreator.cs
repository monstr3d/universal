using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Diagram.UI
{
    /// <summary>
    /// The object that can create xml element
    /// </summary>
    public interface IXmlElementCreator
    {
        /// <summary>
        /// Creates corresponding xml
        /// </summary>
        /// <param name="doc">document to create element</param>
        /// <returns>The created element</returns>
        XmlElement CreateXml(XmlDocument doc);
    }
}
