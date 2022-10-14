using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Chart.Drawing.Interfaces;
using Chart.Drawing.Interfaces.Points;

namespace Chart.Drawing.Series
{
    /// Simple implementation of series
    /// </summary>
    public class SimpleSeries : ISeries
    {

        #region Fields

        List<IPoint> points = new List<IPoint>();

        double[,] size = new double[2, 2];

        bool isChanged = true;

        #endregion

        #region ISeries Members

        double[,] ISeries.Size
        {
            get
            {
                if (isChanged)
                {
                    GetSize(this, size);
                }
                return size;
            }
        }

        IList<IPoint> ISeries.Points
        {
            get { return points; }
        }

        #endregion

        #region Members


        /// <summary>
        /// Adds x and y
        /// </summary>
        /// <param name="x">The x</param>
        /// <param name="y">The y</param>
        public void AddXY(double x, double y)
        {
            isChanged = true;
            points.Add(new PointBase(x, y));
        }

        /// <summary>
        /// Gets size
        /// </summary>
        /// <param name="series">Series</param>
        /// <param name="size">Size</param>
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
