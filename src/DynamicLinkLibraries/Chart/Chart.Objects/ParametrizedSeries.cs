using System;
using System.Collections.Generic;

using BaseTypes.Utils;


using Chart.Drawing.Interfaces;
using Chart.Drawing.Interfaces.Points;

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
            double xp = x()().ToDouble();
            double yp = y()().ToDouble();
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
                pointList.Add(d.ToPoint()); ;
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

        int ISeries.YCount => 1;

        void ISeries.Add(IPoint point)
        {
            pointList.Add(point);
        }



        #endregion

        #region Members


        #endregion
    }
}