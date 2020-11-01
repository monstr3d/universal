using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Chart.Drawing.Interfaces;

namespace Chart.Drawing
{
    public class VirtualControl : IControl
    {
        #region Members

        int width;

        int height;

        Color backColor;

        #endregion


        #region Ctor

        public VirtualControl(int width, int height, Color backColor)
        {
            this.width = width;
            this.height = height;
            this.backColor = backColor;
        }


        public VirtualControl(Image image, Color backColor)
            : this(image.Width, image.Height, backColor)
        {
        }

        #endregion


        #region IControl Members

        Color IControl.BackColor
        {
            get { return backColor; }
        }

        int IControl.Width
        {
            get { return width; }
        }

        int IControl.Height
        {
            get { return height; }
        }

        #endregion
    }
}
