using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Chart.Drawing.Interfaces;

namespace Chart.Drawing.Drawable
{
    public class ColoredCircle : IDrawablePoint
    {
        #region Fields

        private int size;

        private Color color;

        private static SolidBrush brush = new SolidBrush(Color.Black);


        #endregion


        #region Ctor

        public ColoredCircle(int size, System.Drawing.Color color)
        {
            this.color = color;
            if (size > 1)
            {
                this.size = size;
            }
            else
            {
                this.size = 1;
            }
        }

        #endregion

        #region IDrawablePoint Members

        void IDrawablePoint.Draw(Graphics g, int x, int y)
        {
            brush.Color = color;
            g.FillEllipse(brush, x + size, y + size, 2 * size, 2 * size);
        }

        #endregion
    }
}
