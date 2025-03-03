using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Diagram.UI;

using Motion6D.Drawing.Interfaces;
using Motion6D.Drawing.Classes;
using Motion6D.Interfaces;
using ErrorHandler;

namespace Motion6D.Drawing.Indicators
{
    /// <summary>
    /// Simple indicator of 3D points
    /// </summary>
    public class SimplePointsIdicator : IPointsIndicator
    {

        #region Fields

        public static readonly string name = "Simple";

        protected PositionCollectionIndicator collection;

        private static readonly SimplePointsIdicator Object = new SimplePointsIdicator(null);

        private Image im;

        protected Brush backBrush = new SolidBrush(Color.Black);

        protected Brush drawBrush = new SolidBrush(Color.White);

        SolidBrush tempBrush = new SolidBrush(Color.White);

        protected double[] auxPos = new double[3];


        protected int dx;

        protected int dy;

        protected int width;

        private static IPointsIndicator indicator = Object;

        double x1;
        double x2;
        double y1;
        double y2;
        private bool blocked = true;

        bool first = true;


        protected IControl control;

        #endregion

        #region Ctor

        public SimplePointsIdicator(IControl control)
        {
            this.control = control;
        }

        #endregion

        #region IPointsIndicator Members

        IPointsIndicator IPointsIndicator.this[string name]
        {
            get { return new SimplePointsIdicator(control); }
        }

        string[] IPointsIndicator.this[PositionCollectionIndicator collection]
        {
            get { return new string[] { name }; }
        }

        PositionCollectionIndicator IPointsIndicator.Positions
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                Prepare();
            }
        }

        bool IPointsIndicator.Blocked
        {
            get
            {
                return blocked;
            }
            set
            {
                if (value == blocked)
                {
                    return;
                }
                blocked = value;
            }
        }


        #endregion

        #region Specific Members


        static public IPointsIndicator Indicator
        {
            get
            {
                return indicator;
            }
            set
            {
                indicator = value;
            }
        }

        protected virtual void Prepare()
        {
            IReferenceFrame f = collection;
            ReferenceFrame frame = f.Own;
            IPositionCollection positions = collection.Positions;
            foreach (IPosition p in positions.Positions)
            {
                frame.GetPositon(p, auxPos);
                if (first)
                {
                    x1 = auxPos[0];
                    x2 = x1;
                    y1 = auxPos[1];
                    y2 = y1;
                    first = false;
                    continue;
                }
                double x = auxPos[0];
                double y = auxPos[1];
                if (x < x1)
                {
                    x1 = x;
                }
                if (x > x2)
                {
                    x2 = x;
                }
                if (y < y1)
                {
                    y1 = y;
                }
                if (y > y2)
                {
                    y2 = y;
                }
            }
        }

        public Image Image
        {
            get
            {
                if (im == null)
                {
                    CreateImage();
                }
                return im;
            }
        }

        public void CreateImage()
        {
            width = control.Width;
            dx = 0;
            dy = 0;
            if (control.Height < width)
            {
                width = control.Height;
                dx = (control.Width - width) / 2;
            }
            else
            {
                dy = (control.Height - width) / 2;
            }
            im = new Bitmap(width, width);
            Draw();
        }

        public void Draw()
        {
            try
            {
                int w = im.Width;
                int h = im.Height;
                Graphics g = Graphics.FromImage(im);
                Draw(g, w, h);
                g.Dispose();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }



        protected virtual void Draw(IPosition position, Graphics g, int x, int y)
        {
            int s = 1;
            Brush br = drawBrush;
            object p = position.Parameters;
            if (p != null)
            {
                if (p is ColorSize)
                {
                    ColorSize cs = p as ColorSize;
                    s = (int)cs.Size;
                    if (s < 1)
                    {
                        s = 1;
                    }
                    tempBrush.Color = cs.Color;
                    br = tempBrush;
                }
            }
            g.FillEllipse(br, x - s, y - s, 2 * s, 2 * s);
        }

        protected void Draw(Graphics g, int w, int h)
        {
            IReferenceFrame f = collection;
            ReferenceFrame frame = f.Own;
            IPositionCollection pos = collection.Positions;
            ICollection<IPosition> l = pos.Positions;
            g.FillRectangle(backBrush, 0, 0, (float)w, (float)h);
            foreach (IPosition p in l)
            {
                frame.GetPositon(p, auxPos);
                double x = auxPos[0];
                double y = auxPos[1];
                int xx = (int)(((x - x1) / (x2 - x1)) * (double)w);
                int yy = (int)(((y - y1) / (y2 - y1)) * (double)h);
                Brush br = drawBrush;
                Draw(p, g, xx, yy);
            }
        }

        #endregion
    }
}
