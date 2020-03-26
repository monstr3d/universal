using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


using Xml.Drawing.Library.Classes;

namespace Xml.Drawing.Library.Interfaces
{
    /// <summary>
    /// Gets structue
    /// </summary>
    public interface IDrawingStructure
    {
        /// <summary>
        /// Gets structu
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        GraphicsStructure GetStructure(XElement element);
    }
}
