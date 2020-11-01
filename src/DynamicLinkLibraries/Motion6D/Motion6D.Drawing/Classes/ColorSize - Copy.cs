using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Motion6D.Drawing.Classes
{
    class ColorSize
    {

        #region Fields

        Color color;

        double size;

        #endregion

        #region Members

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public double Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        #endregion
    }
}
