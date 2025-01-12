using Chart.Drawing.Interfaces.Points;

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
        /// Creator of coordinare functions
        /// </summary>
        static public ICoordinateFunctionsCreator CoordinateFunctionsCreator
        { get; set; }

        /// <summary>
        /// Coodinate functions from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The functions</returns>
        public static Func<object, object>[] CreateCoordinateFunctions(this object obj)
        {
            if (CoordinateFunctionsCreator == null)
            {
                return null;
            }
            if (obj == null)
            {
                return null;
            }
            return CoordinateFunctionsCreator[obj];
        }

        /// <summary>
        /// Creates a point from array
        /// </summary>
        /// <param name="x">The array</param>
        /// <returns>The point</returns>
        static public IPoint ToPoint(this double[] x)
        {
            if (x.Length == 2) return new PointBase(x[0], x[1]);
            double[] y = new double[x.Length - 1];
            Array.Copy(x, 1, y, 0, y.Length);
            return new MultiPoint(x[0], y);
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
                    size[0, 1] = x;
                    size[1, 0] = y.Min();
                    size[1, 1] = y.Max();
                    b = false;
                    continue;
                }
                if (size[0, 0] > x)
                {
                    size[0, 0] = x;
                }
                if (size[0, 1] < x)
                {
                    size[0, 1] = x;
                }
                if (size[1, 0] > y.Min())
                {
                    size[1, 0] = y.Min();
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
