using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Painter of series
    /// </summary>
    public interface ISeriesPainter : ICloneable
    {
        /// <summary>
        /// Draws series
        /// </summary>
        /// <param name="series">Series to draw</param>
        /// <param name="g">Graphics to draw</param>
        void Draw(ISeries series, Graphics g);

        /// <summary>
        /// Performer
        /// </summary>
        ChartPerformer Performer
        {
            get;
            set;
        }

    }

    /// <summary>
    /// Type of painter
    /// </summary>
    internal enum PainterType
    {
        /// <summary>
        /// Simple painter with approximation
        /// </summary>
        Simple,
        /// <summary>
        /// Step painter
        /// </summary>
        Step
    }
}
