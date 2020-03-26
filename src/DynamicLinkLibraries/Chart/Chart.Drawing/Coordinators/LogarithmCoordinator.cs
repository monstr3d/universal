using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Chart.Drawing.Interfaces;
using Chart.Drawing.TextPainters;

namespace Chart.Drawing.Coordinators
{
    public class LogarithmCoordinator : SimpleCoordinator
    {

        #region Fields
        protected bool logX = false;
        protected bool logY = false;

        protected ICoordTextPainter xLog = new LogarithmTextPainter();
        protected ICoordTextPainter yLog = new LogarithmTextPainter();
        #endregion

        #region Constructors
        public LogarithmCoordinator(ChartPerformer performer)
            : base(5, 5, performer)
        {

        }

        #endregion

        #region ICoordPainter Members


        /// <summary>
        /// Draws coordinates lines
        /// </summary>
        /// <param name="g">Graphics to draw</param>
        /// <param name="dSize">Physical size</param>
        /// <param name="size">Pixel size</param>
        public override void DrawCoord(Graphics g, double[,] dSize, int[] size)
        {
            calculateScale(dSize);
            if (logX)
            {
                drawCoordLog(g, size, dSize, 0);
            }
            else
            {
                DrawCoord(g, size, dSize, 0);
            }
            if (logY)
            {
                drawCoordLog(g, size, dSize, 1);
            }
            else
            {
                DrawCoord(g, size, dSize, 1);
            }

        }

        public override void DrawCoord(Graphics g, int[,] insets, double[,] dSize, int[] size)
        {
            xLog.Performer = performer;
            yLog.Performer = performer;
            xText.Performer = performer;
            yText.Performer = performer;
            calculateScale(dSize);
            Pen pen = new Pen(Color.Black);
            g.DrawRectangle(pen, insets[0, 0] - 1, insets[0, 1] - 1, size[0] + 2, size[1] + 2);
            if (logX)
            {
                xLog.DrawTextX(g, insets, dSize, size, scale);
            }
            else
            {
                xText.DrawTextX(g, insets, dSize, size, scale);
            }
            if (logY)
            {
                yLog.DrawTextY(g, insets, dSize, size, scale);
            }
            else
            {
                yText.DrawTextY(g, insets, dSize, size, scale);
            }
        }

        #endregion

        #region Specific Members


        public bool LogX
        {
            set
            {
                logX = value;
            }
        }

        public bool LogY
        {
            set
            {
                logY = value;
            }
        }

        protected void drawCoordLog(Graphics g, int[] size, double[,] dSize, int i)
        {
            Pen pen = new Pen(Color.Black);
            int min = (int)Math.Floor(dSize[0, i]);
            int max = (int)Math.Ceiling(dSize[1, i]);
            for (int j = min; j <= max; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    double c = j + Math.Log10(k);
                    if ((c < dSize[0, i]) | (c > dSize[1, i]))
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        performer.Transform(c, 0.0, p);
                        g.DrawLine(pen, p[0], 0, p[0], size[1]);
                    }
                    else
                    {
                        performer.Transform(0, c, p);
                        g.DrawLine(pen, 0, p[1], size[0], p[1]);
                    }
                }
            }
        }



        #endregion
    }
}
