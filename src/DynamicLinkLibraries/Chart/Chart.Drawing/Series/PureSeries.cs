using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


using Chart.Drawing.Interfaces;
using Chart.Drawing.Points;


namespace Chart.Drawing.Series
{
    /// <summary>
    /// Pure series
    /// </summary>
    [Serializable()]
    public class PureSeries : ISeries, ISerializable
    {
        #region Fields

        /// <summary>
        /// List of points
        /// </summary>
        private List<IPoint> pointList = new List<IPoint>();


        #endregion

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public PureSeries()
        {
        }

        /// <summary>
        /// Deserialization construcror
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected PureSeries(SerializationInfo info, StreamingContext context)
        {
            pointList = info.GetValue("Points", typeof(List<IPoint>)) as List<IPoint>;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Points", pointList, typeof(List<IPoint>));
        }

        #endregion

        #region ISeries Members

        double[,] ISeries.Size
        {
            get
            {
                double[,] size = new double[2, 2];
                for (int i = 0; i < pointList.Count; i++)
                {
                    IPoint p = pointList[i];
                    if (i == 0)
                    {
                        size[0, 0] = p.X;
                        size[0, 1] = p.Y;
                        size[1, 0] = p.X;
                        size[1, 1] = p.Y;
                        continue;
                    }
                    double[] x = new double[] { p.X, p.Y };
                    for (int j = 0; j < 2; j++)
                    {
                        if (x[j] < size[0, j])
                        {
                            size[0, j] = x[j];
                        }
                        if (x[j] > size[1, j])
                        {
                            size[1, j] = x[j];
                        }
                    }
                }
                return size;
            }
        }

        IList<IPoint> ISeries.Points
        {
            get
            {
                return pointList;
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Copies series
        /// </summary>
        /// <param name="series">Series</param>
        public void Copy(ISeries series)
        {
            IList<IPoint> l = series.Points;
            for (int i = 0; i < l.Count; i++)
            {
                IPoint p = l[i];
                AddXY(p.X, p.Y);
            }
        }

        /// <summary>
        /// Adds new point
        /// </summary>
        /// <param name="x">X - coordinate</param>
        /// <param name="y">Y - coordinate</param>
        public void AddXY(double x, double y)
        {
            IPoint p = new PointBase(x, y);
            pointList.Add(p);
        }

        #endregion
   }
}
