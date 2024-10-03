using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Chart.Drawing.Interfaces;


namespace Chart.Drawing.TextPainters
{
    /// <summary>
    /// Simple text coodinate painter
    /// </summary>
    public class SimpleCoordTextPainter : ICoordTextPainter
    {
        #region Fields

        protected ChartPerformer performer;

        protected int[] p = new int[2];


        #endregion


        #region ICoordTextPainter Members

        public virtual void DrawTextX(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
            drawTextX(g, insets, dSize, size, scale);
        }

        public virtual void DrawTextY(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
            drawTextY(g, insets, dSize, size, scale);
        }

        ChartPerformer ICoordTextPainter.Performer
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


        #region Members


        protected virtual void drawTextX(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
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
                    string s = transformString(c, sc);
                    int w = (int)g.MeasureString(s, font).Width;
                    g.DrawString(s, font, brush, p[0] + insets[0, 0] - w / 2, h);
                }
                c += sc;
            }
        }

        protected virtual void drawTextY(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Times", 13);
            Coordinators.SimpleCoordinator.DrawCoord(size, dSize, scale, 1, delegate(double c, double sc)
            {
                performer.Transform(0.0, c, p);
                string s = transformString(c, sc);
                int w = (int)g.MeasureString(s, font).Width;
                g.DrawString(s, font, brush, insets[0, 0] - (int)(double)(1.2 * w), p[1] + insets[0, 1]);
            });
        }

        protected virtual string transformString(double d, double sc)
        {
            Double a = d;
            String s = a.ToString();
            while (true)
            {
                if (s.Length > 3 & s.IndexOf('E') < 0 & s.IndexOf('e') < 0)
                {
                    String s1 = s.Substring(0, s.Length - 1);
                    double d1 = Double.Parse(s1);
                    if (Math.Abs(d - d1) < 0.5 * sc)
                    {
                        s = s1;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            return s;
        }




        #endregion

    }
}
