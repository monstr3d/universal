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
    public interface ICoordTextPainter
    {
        /// <summary>
        /// Draws X coordinates
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="insets">Insets</param>
        /// <param name="dSize">Physical size</param>
        /// <param name="size">Window size</param>
        /// <param name="scale">Scale</param>
        void DrawTextX(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale);

        /// <summary>
        /// Draws Y coordinates
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="insets">Insets</param>
        /// <param name="dSize">Physical size</param>
        /// <param name="size">Window size</param>
        /// <param name="scale">Scale</param>
        void DrawTextY(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale);

        /// <summary>
        /// Performer
        /// </summary>
        ChartPerformer Performer
        {
            get;
            set;
        }

    }
}