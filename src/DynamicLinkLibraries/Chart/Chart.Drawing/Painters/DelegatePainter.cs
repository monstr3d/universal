using Chart.Drawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Drawing.Painters
{
    public class DelegatePainter : SimpleSeriesPainter
    {
        private DelegatePainter(Color[] colors) : base(colors)
        {
            Paint += ( obj, g) => { };
            PaintPoint += (a, b, c) => { };
        }
  
        public DelegatePainter() : this([])
        {
        }

        public event Action<int[], Graphics> Paint;

        public event Action<int[], Graphics, IPoint> PaintPoint;

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
                Paint(pointStart, g);
                PaintPoint(pointStart, g, xx);
            }
        }

    }
}
