using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Drawing;

using Xml.Drawing.Library.Interfaces;

namespace Xml.Drawing.Library.Classes
{
    /// <summary>
    /// List of drawind interfaces
    /// </summary>
    public class DrawingInterfaceList : IDrawingInterface
    {

        #region Fields

        IList<IDrawingInterface> list;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">List of interfaces</param>
        public DrawingInterfaceList(IList<IDrawingInterface> list)
        {
            this.list = list;
        }


        #endregion

        #region IDrawingInterface Members

        Font IDrawingInterface.GetFont(XElement element)
        {
            foreach (IDrawingInterface id in list)
            {
                Font f = id.GetFont(element);
                if (f != null)
                {
                    return f;
                }
            }
            return null;
        }

        Brush IDrawingInterface.GetForegroundBrush(XElement element)
        {
            foreach (IDrawingInterface id in list)
            {
                Brush f = id.GetForegroundBrush(element);
                if (f != null)
                {
                    return f;
                }
            }
            return null;
        }

        Brush IDrawingInterface.GetBackgroundBrush(XElement element)
        {
            foreach (IDrawingInterface id in list)
            {
                Brush f = id.GetBackgroundBrush(element);
                if (f != null)
                {
                    return f;
                }
            }
            return null;
        }
        
        Pen IDrawingInterface.GetPen(XElement element)
        {
            foreach (IDrawingInterface id in list)
            {
                Pen f = id.GetPen(element);
                if (f != null)
                {
                    return f;
                }
            }
            return null;
        }

        IDrawingInterface IDrawingInterface.GetDrawing(XElement element)
        {
            foreach (IDrawingInterface id in list)
            {
                IDrawingInterface f = id.GetDrawing(element);
                if (f != null)
                {
                    return f;
                }
            }
            return null;
        }
        #endregion
    }
}
