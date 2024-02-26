using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Chart.Drawing.Interfaces;
using Chart.Drawing.TextPainters;

namespace Chart.Drawing.Coordinators
{
    public class SimpleCoordinator : ICoordPainter
    {

        private static double[] scd = { 0.01, 0.02, 0.05, .1, .2, .5, 1.0, 2.0, 5.0, 10, 20, 50 };
        private static  double[] sct = { 1.0 / (24 * 3600), 2.0 / (24 * 3600), 5.0 / (24 * 3600),
            10.0 / (24 * 3600), 30.0 / (24 * 3600), 
            1.0 / (24 * 60), 2.0 / (24 * 60), 5.0 / (24 * 60),
            10.0 / (24 * 60), 30.0 / (24 * 60),
             1.0 / (24), 2.0 / (24), 6.0 / (24),
            12.0 / (24),  1.0, 2.0, 5.0, 10, 20, 50 };
        protected int[] n = new int[2];
        protected double[] scale = new double[2];
        protected int[] p = new int[2];
        private double[][] sc = new double[2][];

        protected ICoordPainter coordPainter;
        
        private ChartPerformer performer;


        protected ICoordTextPainter xText = new SimpleCoordTextPainter();
        protected ICoordTextPainter yText = new SimpleCoordTextPainter();

        public SimpleCoordinator(int nx, int ny)
        {
            coordPainter = this;
            n[0] = nx;
            n[1] = ny;
            sc[0] = scd;
            sc[1] = scd;
        }

        static SimpleCoordinator()
        {
            double[] k = { 2, 5 };
            List<double> ld = new List<double>(scd);
            double a = 100;
            double max = double.MaxValue / 10;
            do
            {
                ld.Add(a);
                foreach (double kk in k)
                {
                    ld.Add(kk * a);
                }
                a *= 10;
            }
            while (a < max);
            scd = ld.ToArray();
        }


        /// <summary>
        /// Draws coordinates lines
        /// </summary>
        /// <param name="g">Graphics to draw</param>
        /// <param name="dSize">Physical size</param>
        /// <param name="size">Pixel size</param>
        public virtual void DrawCoord(Graphics g, double[,] dSize, int[] size)
        {
            calculateScale(dSize);
            DrawCoord(g, size, dSize, 0);
            DrawCoord(g, size, dSize, 1);
        }

        /// <summary>
        /// Draws coordinates text
        /// </summary>
        /// <param name="g">Graphics to draw</param>
        /// <param name="insets">Insets</param>
        /// <param name="dSize">Physical size</param>
        /// <param name="size">Pixel size</param>
        public virtual void DrawCoord(Graphics g, int[,] insets, double[,] dSize, int[] size)
        {
            calculateScale(dSize);
            Pen pen = new Pen(Color.Black);
            g.DrawRectangle(pen, insets[0, 0] - 1, insets[0, 1] - 1, size[0] + 2, size[1] + 2);
            xText.Performer = performer;
            yText.Performer = performer;
            xText.DrawTextX(g, insets, dSize, size, scale);
            yText.DrawTextY(g, insets, dSize, size, scale);
        }



        protected void calculateScale(double[,] dSize, int i)
        {
            double a = (dSize[1, i] - dSize[0, i]) / n[i];
         /*   if (a == 0)
            {
                return;
            }*/
            double[] k = sc[i];
            if (k[0] <= a & k[k.Length - 1] > a)
            {
                double be = k[0];
                for (int ind = 1; ind < k.Length; ind++)
                {
                    double en = k[ind];
                    if (a > en)
                    {
                        be = en;
                        continue;
                    }
                    if (Math.Abs(be - a) < Math.Abs(en - a))
                    {
                        scale[i] = be;
                        return;
                    }
                    else
                    {
                        scale[i] = en;
                        return;
                    }
                }
            }

            double log = Math.Log(a) / Math.Log(10.0);
            int lg = (int)Math.Ceiling(log);
            double c = 1;
            if (lg > 0)
            {
                for (int j = 0; j < lg; j++)
                {
                    c *= 10;
                }
            }
            else
            {
                for (int j = 0; j > lg; j--)
                {
                    c /= 10;
                }
            }
            double ss = c * sc[i][0];
            double acc = Math.Abs(ss - a);
            for (int j = 1; j < sc[i].Length; j++)
            {
                double sss = c * sc[i][j];
                double d = Math.Abs(sss - a);
                if (d < acc)
                {
                    ss = sss;
                    acc = d;
                }
            }
            scale[i] = ss;
        }

        protected void calculateScale(double[,] dSize)
        {
            calculateScale(dSize, 0);
            calculateScale(dSize, 1);
        }

        static public void DrawCoord(int[] size, double[,] dSize, double[] scale, int i, Action<double, double> action)
        {
            double sc = scale[i];
            if (sc == 0)
            {
                return;
            }
            double x = Math.Truncate(dSize[0, i] / sc) * sc;
            while (x < dSize[1, i])
            {
                if (x > dSize[0, i])
                {
                    action(x, sc);
                }
                x += sc;
            }
        }



        protected void DrawCoord(Graphics g, int[] size, double[,] dSize, int i)
        {
            Pen pen = new Pen(Color.Black);
            DrawCoord(size, dSize, scale, i, delegate(double x, double sc)
            {
                    if (i == 0)
                    {
                        performer.Transform(x, 0.0, p);
                        g.DrawLine(pen, p[0], 0, p[0], size[1]);
                    }
                    else
                    {
                        performer.Transform(0, x, p);
                        g.DrawLine(pen, 0, p[1], size[0], p[1]);
                    }
            });
        }

        #region ICoordPainter Members

        ICoordTextPainter ICoordPainter.X
        {
            get
            {
                return xText;
            }
            set
            {
                xText = value;
                if (value.GetType().Equals(typeof(SimpleCoordinator)))
                {
                    sc[0] = scd;
                }
                else
                {
                    sc[0] = sct;
                }
            }
        }

        ICoordTextPainter ICoordPainter.Y
        {
            get
            {
                return yText;
            }
            set
            {
                yText = value;
                if (value.GetType().Equals(typeof(SimpleCoordinator)))
                {
                    sc[1] = scd;
                }
                else
                {
                    sc[1] = sct;
                }
            }
        }


        ChartPerformer ICoordPainter.Performer
        {
            get => performer;
            set => performer = value;
        }


        /// <summary>
        /// Clears insets
        /// </summary>
        /// <param name="component">Chart component</param>
        /// <param name="insets">Insets</param>
        public virtual void ClearInsets(IControl component, int[,] insets)
        {
        }

    

        #endregion
    }
}
