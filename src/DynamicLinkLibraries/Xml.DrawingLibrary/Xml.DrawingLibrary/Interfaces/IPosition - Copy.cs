using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

using Xml.Drawing.Library.Delegates;


namespace Xml.Drawing.Library.Interfaces
{
    /// <summary>
    /// Position interface
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// Gets position of element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The position</returns>
        Func<XmlElement, Point> GetPosition(XmlElement element);
    }
}
