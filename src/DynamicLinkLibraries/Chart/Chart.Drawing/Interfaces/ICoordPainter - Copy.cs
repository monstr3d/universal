using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Painter of coordinates
    /// </summary>
    public interface ICoordPainter
    {
        /// <summary>
        /// Clears insets
        /// </summary>
        /// <param name="component">Chart component</param>
        /// <param name="insets">Insets</param>
        void ClearInsets(IControl component, int[,] insets);

        /// <summary>
        /// Draws coordinates lines
        /// </summary>
        /// <param name="g">Graphics to draw</param>
        /// <param name="dSize">Physical size</param>
        /// <param name="size">Pixel size</param>
        void DrawCoord(Graphics g, double[,] dSize, int[] size);

        /// <summary>
        /// Draws coordinates text
        /// </summary>
        /// <param name="g">Graphics to draw</param>
        /// <param name="insets">Insets</param>
        /// <param name="dSize">Physical size</param>
        /// <param name="size">Pixel size</param>
        void DrawCoord(Graphics g, int[,] insets, double[,] dSize, int[] size);

        /// <summary>
        /// X coordinate string converter
        /// </summary>
        ICoordTextPainter X
        {
            get;
            set;
        }

        /// <summary>
        /// Y - coordinate string converter
        /// </summary>
        ICoordTextPainter Y
        {
            get;
            set;
        }

    }
}
