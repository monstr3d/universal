using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionChartInterfaces
    {
        /// <summary>
        /// Factory of points
        /// </summary>
        static public IPointFactory PointFactory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets size of a series
        /// </summary>
        /// <param name="series">The series</param>
        /// <param name="size">The size</param>
        public static void GetSize(this ISeries series, double[,] size)
        {
            IList<IPoint> points = series.Points;
            bool b = true;
            foreach (IPoint p in points)
            {
                double x = p.X;
                var y = p.Y;
                if (b)
                {
                    size[0, 0] = x;
                    size[1, 0] = x;
                    size[0, 1] = y.Min();
                    size[1, 1] = y.Max();
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
                if (size[0, 1] > y.Min())
                {
                    size[0, 1] = y.Min();
                }
                if (size[1, 1] < y.Max())
                {
                    size[1, 1] = y.Max();
                }
            }
        }

        /// <summary>
        /// Gets argument position
        /// </summary>
        /// <param name="series">The series</param>
        /// <param name="argument">The argument</param>
        /// <returns>The position</returns>
        public static int GetArgumentPosition(this ISeries series, double argument)
        {
            int i = 0;
            foreach (var point in series.Points)
            {
                if (point.X > argument)
                {
                    break;
                }
                ++i;
            }
            return i;
        }

    }
}
