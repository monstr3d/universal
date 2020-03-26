using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


using System.Drawing;

namespace Xml.Drawing.Library.Interfaces
{
    /// <summary>
    /// Drawing interface
    /// </summary>
    public interface IDrawingInterface
    {
        /// <summary>
        /// Gets font from element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The font</returns>
        Font GetFont(XElement element);

        /// <summary>
        /// Gets foreground brush from element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The brush</returns>
        Brush GetForegroundBrush(XElement element);


        /// <summary>
        /// Gets background brush from element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The brush</returns>
        Brush GetBackgroundBrush(XElement element);

        /// <summary>
        /// Gets pen from element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The pen</returns>
        Pen GetPen(XElement element);

        /// <summary>
        /// Gets font from element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The interface</returns>
        IDrawingInterface GetDrawing(XElement element);
    }
}
