using Chart.Drawing.Interfaces;
using Chart.Drawing.Painters;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Trading.Charts
{
    /// <summary>
    /// Candle series painter
    /// </summary>
    public class CandleSeriesPainter : SimpleSeriesPainter
    {

        Color up;

        Color down;

        Queue<int[]> queue = new Queue<int[]>();

        Brush[] brushes;
        public CandleSeriesPainter(Color up, Color down) : base([up, down])
        {
            this.up = up;
            this.down = down;
            pointFinish = new int[5];
            brushes = [new SolidBrush(up), new SolidBrush(down)];
        }

        public override object Clone()
        {
            var c = new CandleSeriesPainter(up, down);
            c.performer = this.performer;
            return c;
        }


        public override void Draw(ISeries series, Graphics g)
        {
            queue.Clear();
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
                var pp = new int[5];
                performer.Transform(xx.X, xx.Y, pp);
                queue.Enqueue(pp);
                if (queue.Count == 3)
                {
                    var arr = queue.ToArray();
                    var ar = arr[1];
                    int n = xx.Y[2] > xx.Y[3] ? 0 : 1;
                    var pen = pens[n];
                    var brush = brushes[n];
                    int dxl = (arr[1][0] - arr[0][0]) / 3;
                    int dxr = (arr[2][0] - arr[1][0]) / 3;
                    var xp = ar[0] - dxl;
                    var wp = dxl + dxr;
                    if (wp < 5)
                    {
                        g.DrawLine(pen, ar[0], ar[1], ar[0], ar[2]);
                    }
                    else
                    {
                        g.FillRectangle(brush, ar[0] - 1, ar[1], 3, ar[2] - ar[1]);
                    }
                    int[] cc = [ar[3], ar[4]];
                    var yp = cc.Min();
                    var hp = cc.Max() - cc.Min();
                    g.FillRectangle(brush, xp, yp, wp, hp);
                    queue.Dequeue();
                }
            }
        }
    }
}