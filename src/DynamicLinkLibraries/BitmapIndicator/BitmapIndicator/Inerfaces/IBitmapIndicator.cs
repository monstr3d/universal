using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BitmapIndicator.Inerfaces
{
    /// <summary>
    /// Indicator of bitmap
    /// </summary>
    public interface IBitmapIndicator
    {
        /// <summary>
        /// Shows coordinates & colors
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y - coordinate</param>
        /// <param name="color">Color</param>
        void Show(int x, int y, Color color);

        /// <summary>
        /// The enabled sign
        /// </summary>
        bool Enabled
        {
            get;
            set;
        }
    }
}
