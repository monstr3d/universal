using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


using Chart.Drawing.Interfaces;

namespace Chart.Drawing.Painters
{
    public class StepSeriesPainter : SimpleSeriesPainter
    {

 
        #region Constructors

        public StepSeriesPainter(Color[] color)
            : base(color)
        {
        }

        #endregion

        #region ISeriesPainter Members

        /// <summary>
        /// Draws series
        /// </summary>
        /// <param name="series">Series to draw</param>
        /// <param name="g">Graphics to draw</param>
        public override void Draw(ISeries series, Graphics g)
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
            performer.Transform(xx.X, xx.Y[0], pointStart);
            for (int i = 1; i < points.Count; i++)
            {
                xx = points[i];
                performer.Transform(xx.X, xx.Y[0], pointFinish);
                int dx = Math.Abs(pointStart[0] - pointFinish[0]);
                int dy = Math.Abs(pointStart[1] - pointFinish[1]);
                if ((dx < performer.StepX) | (dy < performer.StepY))
                {
                    continue;
                }
                g.DrawLine(pens[0], pointStart[0], pointStart[1], pointFinish[0], pointStart[1]);
                g.DrawLine(pens[0], pointFinish[0], pointStart[1], pointFinish[0], pointFinish[1]);
                pointStart[0] = pointFinish[0];
                pointStart[1] = pointFinish[1];
            }
        }

        #endregion

        #region ICloneable Members


        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>The clone</returns>
        public override object Clone()
        {
            return new StepSeriesPainter(colors);
        }

 
   
        #endregion
 

    }
}
