using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Drawing.TextPainters
{
    public class DataTimeFromOATextPainter : SimpleCoordTextPainter
    {

        public DataTimeFromOATextPainter()
        {
        }

        protected override void drawTextX(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
            double sc = scale[0];
            if (sc == 0)
            {
                return;
            }
            double k = Math.Floor(dSize[0, 0] / sc);
            double c = k * sc;
            Font font = new Font("Times", 13);
            Brush brush = new SolidBrush(Color.Black);
            int h = font.Height + insets[0, 1] + size[1];
            while (c < dSize[1, 0])
            {
                if (c > dSize[0, 0])
                {
                    performer.Transform(c, 0.0, p);
                    var s = "";
                    if (c < 0)
                    {
                        s = transformString(c, sc);
                    }
                    else
                    {
                        s = DateTime.FromOADate(c).ToString();
                    }
                    int w = (int)g.MeasureString(s, font).Width;
                    g.DrawString(s, font, brush, p[0] + insets[0, 0] - w / 2, h);
                }
                c += sc;
            }
        }
    }
}
