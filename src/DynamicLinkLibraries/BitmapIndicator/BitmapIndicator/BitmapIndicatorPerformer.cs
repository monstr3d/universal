using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


using BitmapIndicator.Inerfaces;

namespace BitmapIndicator
{
    public class BitmapIndicatorPerformer
    {

        #region Fields

        private IBitmapIndicator indicator;

        private Bitmap bmp;

        private Control control;

        private bool isEnabled = false;

        #endregion

        #region Ctor

        public BitmapIndicatorPerformer(IBitmapIndicator indicator, Bitmap bmp, Control control)
        {
            this.indicator = indicator;
            this.bmp = bmp;
            this.control = control;
            control.MouseEnter += MouseEnter;
            control.MouseMove += MouseMove;
            control.MouseLeave += MouseLeave;
        }

        #endregion

        #region Public Members

        public Bitmap Bitmap
        {
            get
            {
                return bmp;
            }
            set
            {
                bmp = value;
            }
        }

        #endregion

        #region Event Handlers


        void MouseEnter(object sender, EventArgs args)
        {
            if (bmp == null)
            {
                MouseLeave(sender, args);
                return;
            }
            indicator.Enabled = true;
            isEnabled = true;
        }

        void MouseMove(object sender, MouseEventArgs args)
        {
            if (!isEnabled)
            {
                return;
            }
            int x = args.X;
            int y = args.Y;
            if ((x >= bmp.Width) | (y >= bmp.Height))
            {
                return;
            }
            Color c = bmp.GetPixel(x, y);
            indicator.Show(x, y, c);
        }

        void MouseLeave(object sender, EventArgs args)
        {
            isEnabled = false;
            indicator.Enabled = false;

        }


        #endregion

    }
}
