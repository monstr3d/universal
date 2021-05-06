using System;
using System.Collections.Generic;
using System.Text;

namespace Chart.Interfaces
{
    /// <summary>
    /// Resizer of chart
    /// </summary>
    public interface IChartResizer
    {
        /// <summary>
        /// Resize
        /// </summary>
        /// <param name="xold">Old mouse position X coordinate</param>
        /// <param name="yold">Old mouse position Y coordinate</param>
        /// <param name="xnew">New mouse position X coordinate</param>
        /// <param name="ynew">New mouse position Y coordinate</param>
        void Resize(int xold, int yold, int xnew, int ynew);
    }
}
