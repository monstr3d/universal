using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Xml.Drawing.Library.Delegates;


namespace Xml.Drawing.Library.Interfaces
{
    /// <summary>
    /// Calculator of size
    /// </summary>
    public interface ISize
    {
        /// <summary>
        /// Gets size from Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="recursive">The "recursive" sign</param>
        /// <returns>Get size delegate</returns>
        Action<XElement, int[]> GetSize(XElement element, out bool recursive);
    }
}
