using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Drawing;



using Xml.Drawing.Library.Delegates;
using Xml.Drawing.Library.Interfaces;

namespace Xml.Drawing.Library.Classes
{
    /// <summary>
    /// Drawing from structure
    /// </summary>
    public class StrucureDrawingInterface : IDrawingInterface
    {
        #region Members

        Func<XElement, GraphicsStructure> getStructure;

        #endregion


        #region Ctor
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="getStructure">Fuction which sets drawing structure to Xml element</param>
        public StrucureDrawingInterface(Func<XElement, GraphicsStructure> getStructure)
        {
            this.getStructure = getStructure;
        }

        #endregion

        #region IDrawingInterface Members

        Font IDrawingInterface.GetFont(XElement element)
        {
            return getStructure(element).Font;
        }

        Brush IDrawingInterface.GetForegroundBrush(XElement element)
        {
            return getStructure(element).ForegroundBrush;
        }

        Brush IDrawingInterface.GetBackgroundBrush(XElement element)
        {
            return getStructure(element).BackgroundBrush;
        }


        Pen IDrawingInterface.GetPen(XElement element)
        {
            return getStructure(element).Pen;
        }

        IDrawingInterface IDrawingInterface.GetDrawing(XElement element)
        {
            return null;
        }

        #endregion

    }
}
