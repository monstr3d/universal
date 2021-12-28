using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BitmapConsumer
{
    /// <summary>
    /// Draws bitmap
    /// </summary>
    public interface IBitmapDrawing
    {
        /// <summary>
        /// Draws bitmap
        /// </summary>
        /// <param name="bmp"></param>
        void Draw(Bitmap bmp);
    }
}
