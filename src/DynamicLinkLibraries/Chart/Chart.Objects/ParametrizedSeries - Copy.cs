using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Chart.Drawing.Interfaces;
using DataPerformer;
using BaseTypes.Utils;
using Chart.Drawing.Points;

namespace Chart.Objects
{
    [DynamicSeries()]
    public class ParametrizedSeries : 
        DataPerformer.SeriesTypes.ParametrizedSeries, ISeries
    {

        private List<IPoint> pointList = new List<IPoint>();

        public ParametrizedSeries(Func<Func<object>> x, Func<Func<object>> y)
            : base(x, y)
        {
        }

        public override void Step()
        {
            double xp = Converter.ToDouble(x()());
            double yp = Converter.ToDouble(y()());
            AddXY(xp, yp);
            pointList.Add(new PointBase(xp, yp));
        }

        public override void Clear()
        {
            base.Clear();
            pointList.Clear();
        }

        public override void Add(DataPerformer.Portable.Basic.Series series)
        {
            base.Add(series);
            List<double[]> l = series.Points;
            foreach (double[] d in l)
            {
                pointList.Add(new PointBase(d[0], d[1]));
            }
        }

        #region ISeries Members

        double[,] ISeries.Size
        {
            get
            {
                DataPerformer.SeriesTypes.ParametrizedSeries p = this;
                return p.Size;
            }
        }

        IList<IPoint> ISeries.Points
        {
            get
            {
                // DataPerformer.ParametrizedSeries p = this;
                // return p.Points;
                return pointList;

            }
        }

        #endregion

        #region Members


        #endregion
    }
}