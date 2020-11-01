using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Drawing;




using Xml.Drawing.Library.Interfaces;
using Xml.Drawing.Library.Delegates;

namespace Xml.Drawing.Library.Static
{
    /// <summary>
    /// Performer of static operations
    /// </summary>
    public static class StaticPerformer
    {

        /// <summary>
        /// Gets interface from node
        /// </summary>
        /// <param name="node">The node</param>
        /// <param name="inter">Prototype</param>
        /// <returns>The interface</returns>
        public static IDrawingInterface GetInterface(XElement node, IDrawingInterface inter)
        {
            if (node is XElement)
            {
                XElement el = node as XElement;
                IDrawingInterface id = inter.GetDrawing(el);
                if (id != null)
                {
                    return id;
                }
            }
            XElement parent = node.Parent;
            if (parent == null)
            {
                return inter;
            }
            IDrawingInterface ind = GetInterface(parent, inter);
            if (ind != null)
            {
                return ind;
            }
            return inter;
        }

        /// <summary>
        /// Draws element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="drawing">The interface</param>
        /// <param name="graphics">The graphics</param>
        static public void Draw(XElement element, IDrawing drawing, Graphics graphics)
        {
            bool rec = false;
            Action<XElement, Graphics> draw = drawing.GetDrawing(element, out rec);
            if (draw != null)
            {
                draw(element, graphics);
            }
            if (rec)
            {
                IEnumerable<XElement> nl = element.GetChildNodes();
                foreach (XElement node in nl)
                {
                    if (node is XElement)
                    {
                        Draw(node as XElement, drawing, graphics);
                    }
                }
            }
        }

        /// <summary>
        /// Gets font from Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="inter">Interface</param>
        /// <returns>The font</returns>
        public static Font GetFont(XElement element, IDrawingInterface inter)
        {
            IDrawingInterface id = inter.GetDrawing(element);
            return id.GetFont(element);
        }

        /// <summary>
        /// Gets brush from Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="inter">Interface</param>
        /// <returns>The brush</returns>
        public static Brush GetBrush(XElement element, IDrawingInterface inter)
        {
            IDrawingInterface id = inter.GetDrawing(element);
            return id.GetForegroundBrush(element);
        }

        /// <summary>
        /// Gets pen from Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="inter">Interface</param>
        /// <returns>The pen</returns>
        public static Pen GetPen(XElement element, IDrawingInterface inter)
        {
            IDrawingInterface id = inter.GetDrawing(element);
            return id.GetPen(element);
        }

        /// <summary>
        /// Gets size of element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="isize">Interface</param>
        /// <param name="size">The size</param>
        static public void GetSize(XElement element, ISize isize, int[] size)
        {
            size[0] = 0;
            size[1] = 0;
            GetSizePrivate(element, isize, size);
        }



        static private void GetSizePrivate(XElement element, ISize isize, int[] size)
        {
            IEnumerable<XElement> nl = element.GetChildNodes();
            foreach (XElement n in nl)
            {
                if (!(n is XElement))
                {
                    continue;
                }
                XElement e = n as XElement;
                bool rec = false;
                Action<XElement, int[]> gs = isize.GetSize(e, out rec);
                int x = size[0];
                int y = size[1];
                gs(e, size);
                if (x > size[0])
                {
                    size[0] = x;
                }
                if (y > size[1])
                {
                    size[1] = y;
                }
                if (rec)
                {
                    GetSizePrivate(e, isize, size);
                }
            }
        }
    }
}
