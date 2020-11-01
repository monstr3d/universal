using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Chart.Drawing.TextPainters
{
    public class LogarithmTextPainter : SimpleCoordTextPainter
    {

        #region Overriden Members

        public override void DrawTextX(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
            drawTextXLog(g, insets, dSize, size, scale);
        }

        public override void DrawTextY(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
            drawTextXLog(g, insets, dSize, size, scale);
        }

        #endregion


        #region Members


        protected void drawTextXLog(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
            Font font = new Font("Times", 13);
            Font fontPow = new Font("Times", 6);
            Brush brush = new SolidBrush(Color.Black);
            int h = font.Height + insets[0, 1] + size[1];
            Pen pen = new Pen(Color.Black);
            int min = (int)Math.Floor(dSize[0, 0]);
            int max = (int)Math.Ceiling(dSize[1, 0]);
            for (int j = min; j <= max; j++)
            {
                //string ss = "";
                /*for (int k = 0; k < j; k++)
                {
                    ss = ss + "0";
                }
                string sp = "";
                for (int k = 0; k > j + 1; k--)
                {
                    sp = sp + "0";
                }
                if (j < 0)
                {
                    sp = "0," + sp;
                }*/
                string sp = "1";
                if (j > 0)
                {
                    sp += "e+" + j;
                }
                if (j < 0)
                {
                    sp += "e" + j;
                }
                for (int k = 0; k < 10; k++)
                {
                    double c = j + Math.Log10(k);
                    if ((c < dSize[0, 0]) | (c > dSize[1, 0]))
                    {
                        continue;
                    }
                    performer.Transform(c, 0.0, p);
                    string s = k + "";
                    int w = (int)g.MeasureString(sp, font).Width;
                    int x = p[0] + insets[0, 0] - w / 2;
                    if (k == 1)
                    {
                        string sh = sp;// +k + ss;
                        g.DrawString(sh, font, brush, x, h);
                    }
                    /*if ((k == 0) & (j != 0))
					{
                        g.DrawString(sp + k + ss, fontPow, brush, x + w, h - font.Height + fontPow.Height);
                    }*/
                }
            }
        }

        protected void drawTextYLog(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
            Font font = new Font("Times", 13);
            Font fontPow = new Font("Times", 6);
            Brush brush = new SolidBrush(Color.Black);
            int h = font.Height + insets[0, 1] + size[1];
            Pen pen = new Pen(Color.Black);
            int min = (int)Math.Floor(dSize[0, 1]);
            int max = (int)Math.Ceiling(dSize[1, 1]);
            for (int j = min; j <= max; j++)
            {
                string ss = "";
                /*    for (int k = 0; k < j; k++)
                    {
                        ss = ss + "0";
                    }
                    string sp = "";
                    for (int k = 0; k > j; k--)
                    {
                        sp = sp + "0";
                    }
                    if (sp.Length > 0)
                    {
                        sp = "0," + sp;
                    }*/
                string sp = "1";
                if (j > 0)
                {
                    sp += "e+" + j;
                }
                if (j < 0)
                {
                    sp += "e" + j;
                }
                for (int k = 0; k < 10; k++)
                {
                    double c = j + Math.Log10(k);
                    if ((c < dSize[0, 1]) | (c > dSize[1, 1]))
                    {
                        continue;
                    }
                    performer.Transform(0.0, c, p);
                    string s = k + "";
                    int w = (int)g.MeasureString("13", font).Width;
                    int y = p[1] + insets[0, 1];
                    if (k == 1)
                    {
                        string sh = sp;// +k + ss;
                        w = (int)g.MeasureString(sh, font).Width;
                        g.DrawString(sh, font, brush, insets[0, 0] - (int)(double)(1.2 * w), y);
                    }
                    if ((k == 0) & (j != 0))
                    {
                        w = (int)g.MeasureString("7", font).Width;
                        g.DrawString(sp + k + ss, fontPow, brush, insets[0, 0] - (int)(double)(1.2 * w), y - font.Height + fontPow.Height);
                    }
                }
            }
        }

        #endregion
    }
}
