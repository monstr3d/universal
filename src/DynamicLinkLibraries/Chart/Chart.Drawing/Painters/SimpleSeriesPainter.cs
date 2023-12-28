using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Chart.Drawing.Interfaces;


namespace Chart.Drawing.Painters
{
    public class SimpleSeriesPainter : ISeriesPainter
    {

        #region Fields

        protected Color[] colors;

        protected ChartPerformer performer;

        protected double[,] dSize = new double[2, 2];

        protected int[] pointStart = new int[2];

        protected int[] pointFinish = new int[2];

        protected Pen[] pens;// = new Pen(Color.Black);


        #endregion

        #region Constructors

        public SimpleSeriesPainter(Color[] colors)
        {
            this.colors = colors;
            List<Pen> l = new List<Pen>();
            foreach (Color c in colors)
            {
                l.Add(new Pen(c));
            }
            pens = l.ToArray();
        }

        #endregion

        #region ISeriesPainter Members

        public virtual void Draw(ISeries series, Graphics g)
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
                int x1 = pointStart[0];
                int y1 = pointStart[1];
                int x2 = pointFinish[0];
                int y2 = pointFinish[1];
                for (int k = 0; k < pens.Length; ++k)
                {
                    g.DrawLine(pens[k], x1, y1 + 2 * k, x2, y2 + 2 * k);
                }
                pointStart[0] = pointFinish[0];
                pointStart[1] = pointFinish[1];
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

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>The clone</returns>
        public virtual object Clone()
        {
            return new SimpleSeriesPainter(colors);
        }

        #endregion

        public Color[] Color
        {
            set
            {
                colors = value;
                List<Pen> l = new List<Pen>();
                foreach (Color c in colors)
                {
                    l.Add(new Pen(c));
                }
                pens = l.ToArray();
            }
        }

        /*
        #region Overriden Members

        public override int GetHashCode()
        {
            return (int)PainterType.Simple;
        }

        public override bool Equals(object obj)
        {
            SimpleSeriesPainter p = obj as SimpleSeriesPainter;
            if (p == null)
            {
                return false;
            }
            return color == p.color;
        }

        #endregion
*/

    }
}
