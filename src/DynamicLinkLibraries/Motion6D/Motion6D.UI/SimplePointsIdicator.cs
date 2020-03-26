using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


using Diagram.UI.Interfaces;

using Motion6D;
using Motion6D.Drawing.Interfaces;
using Motion6D.Interfaces;

namespace Motion6D.UI
{
    /// <summary>
    /// Simple indicator of points
    /// </summary>
    public class SimplePointsIdicator : Panel, IPointsIndicator, IRedraw
    {

        #region Fields

        /// <summary>
        /// Static name of indicator
        /// </summary>
        public static readonly string name = "Simple";

        /// <summary>
        /// Backgrund brush
        /// </summary>
        protected Brush backBrush = new SolidBrush(Color.Black);

        /// <summary>
        /// Drawing brush
        /// </summary>
        protected Brush drawBrush = new SolidBrush(Color.White);

        /// <summary>
        /// Collection of positions
        /// </summary>
        protected PositionCollectionIndicator collection;

        private static readonly SimplePointsIdicator Object = new SimplePointsIdicator();

 
        SolidBrush tempBrush = new SolidBrush(Color.White);

        /// <summary>
        /// Auxiliary 3D position
        /// </summary>
        protected double[] auxPos = new double[3];

        Motion6D.Drawing.Indicators.SimplePointsIdicator prototype;
            

        IPointsIndicator prototypeInterface;

        /// <summary>
        /// X coordinate shift
        /// </summary>
        protected int dx;

        /// <summary>
        /// Y coordinate shift
        /// </summary>
        protected int dy;

        /// <summary>
        /// Width
        /// </summary>
        protected int width;

        private static IPointsIndicator indicator = Object;

                    double x1;
            double x2;
            double y1;
            double y2;
        private bool blocked = true;

        #endregion



        #region Ctor

        /// <summary>
        /// Default costructor
        /// </summary>
        public SimplePointsIdicator()
        {
            prototype = new Motion6D.Drawing.Indicators.SimplePointsIdicator(
                ControlProxy.GetProxy(this));
            prototypeInterface = prototype;
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion


        #region IPointsIndicator Members

        IPointsIndicator IPointsIndicator.this[string name]
        {
            get { return new SimplePointsIdicator(); }
        }

        string[] IPointsIndicator.this[PositionCollectionIndicator collection]
        {
            get { return prototypeInterface[collection]; }
        }

        PositionCollectionIndicator IPointsIndicator.Positions
        {
            get
            {
                return prototypeInterface.Positions;
            }
            set
            {
                prototypeInterface.Positions = value;
            }
        }

        bool IPointsIndicator.Blocked
        {
            get
            {
                return prototypeInterface.Blocked;
            }
            set
            {
                if (blocked == value)
                {
                    return;
                }
                prototypeInterface.Blocked = value;
                blocked = value;
                if (blocked)
                {
                    Paint -= SimplePointsIdicator_Paint;
                    return;
                }
                Paint += SimplePointsIdicator_Paint;
                Refresh();
            }
        }


        #endregion

        #region IRedraw Members

        void IRedraw.Redraw()
        {
            if (blocked)
            {
                return;
            }
            prototype.Draw();
            if (InvokeRequired)
            {
                Action d = paint;
                Invoke(d);
                return;
            }
            paint();
        }

        #endregion

  
        #region Specific Members


        void paint()
        {
            Graphics g = Graphics.FromHwnd(Handle);
            g.DrawImage(prototype.Image, dx, dy);
            g.Dispose();
        }


        /// <summary>
        /// Global indicator
        /// </summary>
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

        /// <summary>
        /// Prepares itself
        /// </summary>
        protected virtual void Prepare()
        {
            IReferenceFrame f = collection;
            ReferenceFrame frame = f.Own;
            IPositionCollection positions = collection.Positions;
            bool first = true;
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

 

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SimplePointsIdicator
            // 
            this.AutoSizeChanged += new System.EventHandler(this.SimplePointsIdicator_AutoSizeChanged);
            this.SizeChanged += new System.EventHandler(this.SimplePointsIdicator_SizeChanged);
            this.ResumeLayout(false);

        }

 
 
        private void SimplePointsIdicator_Paint(object sender, PaintEventArgs e)
        {
            Image im = prototype.Image;
            e.Graphics.DrawImage(im, dx, dy);
        }

        private void SimplePointsIdicator_AutoSizeChanged(object sender, EventArgs e)
        {
            prototype.CreateImage();
        }

 
 
        private void SimplePointsIdicator_SizeChanged(object sender, EventArgs e)
        {
            if (blocked)
            {
                return;
            }
            prototype.CreateImage();
            Refresh();
        }

        #endregion


    }
}
