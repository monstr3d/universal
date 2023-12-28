using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Chart.Drawing.Interfaces;

namespace Chart.Drawing.Painters
{
    public class FiguresSeriesPainter : ISeriesPainter
    {
        #region Fields


        private ChartPerformer performer;

        protected double[,] dSize = new double[2, 2];

        protected int[] pointStart = new int[2];
        protected int[] pointFinish = new int[2];


        #endregion


        public FiguresSeriesPainter()
        {
            //         this.performer = performer;
        }




        #region ISeriesPainter Members

        void ISeriesPainter.Draw(ISeries series, System.Drawing.Graphics g)
        {
            IList<IPoint> points = series.Points;
            if (points.Count < 2)
            {
                return;
            }
            IPoint xx = points[0];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dSize[i, j] = performer[i, j];
                }
            }
            if ((dSize[0, 1] == dSize[1, 1]) | (dSize[0, 0] == dSize[1, 0]))
            {
                return;
            }
            int[] size = performer.CanvasSize;
            for (int i = 0; i < points.Count; i++)
            {
                xx = points[i];
                object o = xx.Properties;
                if (o == null)
                {
                    continue;
                }
                if (!(o is IDrawablePoint))
                {
                    continue;
                }
                IDrawablePoint dp = o as IDrawablePoint;
                performer.Transform(xx.X, xx.Y[0], pointFinish);
                dp.Draw(g, pointFinish[0], pointFinish[1]);
            }
        }

        ChartPerformer ISeriesPainter.Performer
        {
            get
            {
                return performer;
            }
            set
            {
                performer = value;
            }
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return new FiguresSeriesPainter();
        }

        #endregion
    }
}
