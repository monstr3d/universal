using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Base interface for all points
    /// </summary>
    public interface IPoint
    {
        /// <summary>
        /// The x - coordinate
        /// </summary>
        double X
        {
            get;
        }

        /// <summary>
        /// The y - coorditate
        /// </summary>
        double[] Y
        {
            get;
        }

        /// <summary>
        /// Properties
        /// </summary>
        object Properties
        {
            get;
            set;
        }

        /// <summary>
        /// Count of ordinates
        /// </summary>
        int YCount
        { get; }
    }
}
