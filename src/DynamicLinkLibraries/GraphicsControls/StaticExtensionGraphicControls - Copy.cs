using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsControls
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionGraphicControls
    {
        /// <summary>
        /// Draws image on control
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="image">Image</param>
        /// <param name="graphics">Graphics</param>
        public static void DrawImage(this Control control, Image image, Graphics graphics)
        {
            float bw = (float)image.Width;
            float bh = (float)image.Height;
            float cw = (float)control.Width;
            float ch = (float)control.Height;
            float rw = cw / bw;
            float rh = ch / bh;
            float delta = 0;

            RectangleF srcRect = new RectangleF(0, 0, image.Width, image.Height);
            if (rw > rh)
            {
                delta = rw - rh;
                float dx = (delta * cw / 2);
                RectangleF destRect = new RectangleF(dx, 0, control.Width - 2 * dx, control.Height);
                if ((destRect.Width > 0) & (destRect.Height > 0))
                {
                    graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
                }
                return;
            }
            delta = rh - rw;
            float dy = (delta * cw / 2);
            RectangleF destRectY = new RectangleF(0, dy, control.Width, control.Height - 2 * dy);
            graphics.DrawImage(image, destRectY, srcRect, GraphicsUnit.Pixel);
        }
    }
}
