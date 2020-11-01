using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Chart.Drawing.Interfaces;

namespace Chart.Drawing.Painters
{
    public class CrossSeriesPainter : SimpleSeriesPainter
    {

        public CrossSeriesPainter(Color[] color)
            : base(color)
        {
        }

        #region Overriden Members

        public override void Draw(ISeries series, Graphics g)
        {
            IList<IPoint> points = series.Points;
            if (points.Count < 1)
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
                performer.Transform(xx.X, xx.Y, pointFinish);
                g.DrawLine(pens[0], pointFinish[0] - 1, pointFinish[1], pointFinish[0] + 1, pointFinish[1]);
                g.DrawLine(pens[0], pointFinish[0], pointFinish[1] - 1, pointFinish[0], pointFinish[1] + 1);
            }
        }

        #endregion

    }
}
