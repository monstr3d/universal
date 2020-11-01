using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using BitmapIndicator.Inerfaces;

namespace BitmapIndicator.Indicators
{
    public class LabelIndicator : IBitmapIndicator
    {
        #region Fields

        Control[] coord;

        Control[] color;

        List<Label> all = new List<Label>();

        private bool enabled;

        private static readonly string[] texts = { "R = ", "G = ", "B = " };

        private int[] ci = new int[3];

        #endregion

        #region Ctor

        private LabelIndicator(Label[] coord, Label[] color)
        {
            this.coord = coord;
            this.color = color;
            all.AddRange(coord);
            all.AddRange(color);
        }

        #endregion

        #region IBitmapIndicator Members

        void IBitmapIndicator.Show(int x, int y, Color color)
        {
            coord[0].Text = "X = " + x;
            coord[1].Text = "Y = " + y;
            ci[0] = color.R;
            ci[1] = color.G;
            ci[2] = color.B;
            for (int i = 0; i < ci.Length; i++)
            {
                int c = ci[i];
                string s = texts[i] + c + "(";
                double a = (double)c / 255;
                s += a + ")";
                this.color[i].Text = s;
            }
        }

        bool IBitmapIndicator.Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
                all.ForEach(enable);
            }
        }

        #endregion

        #region Members

        public static BitmapIndicatorPerformer Create(Label[] coord, Label[] color, Bitmap bmp, Control control)
        {
            LabelIndicator ind = new LabelIndicator(coord, color);
            return new BitmapIndicatorPerformer(ind, bmp, control);
        }
        

        void enable(Label l)
        {
            l.Visible = enabled;
        }

        #endregion

    }
}