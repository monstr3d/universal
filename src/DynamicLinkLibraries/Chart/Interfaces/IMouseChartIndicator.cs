using System;
using System.Collections.Generic;
using System.Text;

namespace Chart.Interfaces
{
    /// <summary>
    /// Indicator of mouse
    /// </summary>
    public interface IMouseChartIndicator
    {
        /// <summary>
        /// Indication of chart mouse position
        /// </summary>
        /// <param name="x">x - coordinate</param>
        /// <param name="y">y - coordinate</param>
        void Indicate(double x, double y);


        /// <summary>
        /// Is enabled flag
        /// </summary>
        bool IsEnabled
        {
            get;
            set;
        }
    }
}
