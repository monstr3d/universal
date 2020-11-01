using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using System.Reflection;

using BitmapIndicator.Inerfaces;

namespace BitmapIndicator.Indicators
{
    public class ObjectIndicator : IBitmapIndicator
    {

        #region Fields

        object control;

        private bool enabled;

        private static readonly string[] texts = { "X = ", " Y = ", " R = ", " G = ", " B = " };

        private int[] ci = new int[3];

        private PropertyInfo pi;

        #endregion

        #region Ctor

        private ObjectIndicator(object control)
        {
            this.control = control;
            pi = control.GetType().GetProperty("Text");
        }

        #endregion

        #region IBitmapIndicator Members

        void IBitmapIndicator.Show(int x, int y, Color color)
        {
            string s = texts[0] + x;
            s += texts[1] + y;
            ci[0] = color.R;
            ci[1] = color.G;
            ci[2] = color.B;
            for (int i = 0; i < ci.Length; i++)
            {
                int c = ci[i];
                s += texts[i + 2] + c + "(";
                double a = (double)c / 255;
                s += a + ")";
            }
            pi.SetValue(control, s, null);
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
                if (!value)
                {
                    pi.SetValue(control, "", null);
                }
            }
        }

        #endregion

        #region Members

        public static BitmapIndicatorPerformer Create(object indicator, Bitmap bmp, Control control)
        {
            ObjectIndicator ind = new ObjectIndicator(indicator);
            return new BitmapIndicatorPerformer(ind, bmp, control);
        }
        


        #endregion

    }
}
