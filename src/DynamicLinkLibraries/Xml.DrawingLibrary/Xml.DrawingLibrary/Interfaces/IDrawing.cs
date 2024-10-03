using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Drawing;


using Xml.Drawing.Library.Delegates;

namespace Xml.Drawing.Library.Interfaces
{
    /// <summary>
    /// Drawing interface
    /// </summary>
    public interface IDrawing
    {
        /// <summary>
        /// Gets drawing from Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="recursive">The "recursive" sign</param>
        /// <returns>Drawing delegate</returns>
        Action<XElement, Graphics> GetDrawing(XElement element, out bool recursive);
    }
}
