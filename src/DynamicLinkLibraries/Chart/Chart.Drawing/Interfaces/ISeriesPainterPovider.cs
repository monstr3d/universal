using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Provider of series painter
    /// </summary>
    public interface ISeriesPainterPovider
    {
        /// <summary>
        /// The painter
        /// </summary>
        ISeriesPainter Painter
        {
            get;
        }
    }
}
