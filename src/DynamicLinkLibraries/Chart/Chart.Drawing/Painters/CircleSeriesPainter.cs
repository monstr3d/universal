using Chart.Drawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Drawing.Painters
{
    public class CircleSeriesPainter(int radius, Brush brush) : SimpleSeriesPainter([])
    {
        int radius = radius;

        Brush brush = brush;

        public override void Draw(ISeries series, Graphics g)
        {
            IList<IPoint> points = series.Points;
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
                var xx = points[i];
                performer.Transform(xx.X, xx.Y[0], pointStart);
                g.FillEllipse(brush, pointStart[0] - radius, pointStart[1] - radius, 2 * radius, 2 * radius);
            }

        }
    }
}
