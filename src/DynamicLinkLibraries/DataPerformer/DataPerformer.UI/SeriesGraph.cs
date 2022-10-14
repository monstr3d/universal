using System;
using System.Collections.Generic;
using System.Text;


using DataPerformer;
using Chart;
using Chart.Interfaces;
using Chart.Drawing.Interfaces;
using Chart.Drawing.Interfaces.Points;

namespace DataPerformer.UI
{
    /// <summary>
    /// Series obtained from graph
    /// </summary>
    public class SeriesGraph : ISeries
    {
        /// <summary>
        /// Prototype series
        /// </summary>
        protected SeriesBase series;

        /// <summary>
        /// Points
        /// </summary>
        protected List<IPoint> points = new List<IPoint>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="series">Base series</param>
        public SeriesGraph(SeriesBase series)
        {
            this.series = series;
            points.Clear();
            for (int i = 0; i < series.Count; i++)
            {
                IPoint p = new PointBase(series[i, 0], series[i, 1]);
                points.Add(p);
            }
        }

        #region ISeries Members

        double[,] ISeries.Size
        {
            get { return series.Size; }
        }

        IList<IPoint> ISeries.Points
        {
            get { return points; }
        }

        #endregion


        #region Specific Members

        /// <summary>
        /// Gets size of series
        /// </summary>
        /// <param name="series">The series</param>
        /// <param name="size">The size</param>
        public static void GetSize(ISeries series, double[,] size)
        {
            IList<IPoint> points = series.Points;
            bool b = true;
            foreach (IPoint p in points)
            {
                double x = p.X;
                double y = p.Y;
                if (b)
                {
                    size[0, 0] = x;
                    size[1, 0] = x;
                    size[0, 1] = y;
                    size[1, 1] = y;
                    b = false;
                }
                if (size[0, 0] > x)
                {
                    size[0, 0] = x;
                }
                if (size[1, 0] < x)
                {
                    size[1, 0] = x;
                }
                if (size[0, 1] > y)
                {
                    size[0, 1] = y;
                }
                if (size[1, 1] < y)
                {
                    size[1, 1] = y;
                }
            }
        }

        #endregion
    }
}
