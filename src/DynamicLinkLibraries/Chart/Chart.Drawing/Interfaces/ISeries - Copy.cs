using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Common interfase of all series
    /// </summary>
    public interface ISeries
    {
        /// <summary>
        /// Size of series
        /// </summary>
        double[,] Size
        {
            get;
        }

        /// <summary>
        /// Points of series
        /// </summary>
        IList<IPoint> Points
        {
            get;
        }
    }
}
