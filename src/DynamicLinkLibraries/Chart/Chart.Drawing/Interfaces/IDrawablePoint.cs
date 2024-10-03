using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Point for drawing
    /// </summary>
    public interface IDrawablePoint
    {
        /// <summary>
        /// Draws itself
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="x">X - coordinate</param>
        /// <param name="y">Y - coordinate</param>
        void Draw(Graphics g, int x, int y);
    }
}
