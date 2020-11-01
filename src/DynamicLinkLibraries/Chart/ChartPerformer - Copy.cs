using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

using Chart.Interfaces;


using Chart;
using Chart.Drawing.Interfaces;
using Chart.Drawing;
using Chart.Drawing.Painters;

namespace Chart
{
    /// <summary>
    /// Performer of chart
    /// </summary>
    public class ChartPerformer : Drawing.ChartPerformer
    {

        #region Fields
        /// <summary>
        /// Shift delta
        /// </summary>
        const int DELTA = 5;

 
        /// <summary>
        /// Indicators of mouse motion
        /// </summary>
        private List<IMouseChartIndicator> mouseIndicators = new List<IMouseChartIndicator>();

        /// <summary>
        /// The "is mouse moved" sign
        /// </summary>
        protected bool isMoved;

         /// <summary>
        /// Has standard event handlers
        /// </summary>
        protected bool hasStandardHandlers = false;

        /// <summary>
        /// Parent control
        /// </summary>
        protected Control control;

        /// <summary>
        /// Resizer
        /// </summary>
        protected IChartResizer resizer;

        MouseButtons lastPressed;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="control">Control to draw</param>
        /// <param name="insets">Insets</param>
        /// <param name="hasStandardHandlers">The "has standard event handlers" sign</param>
        public ChartPerformer(Control control, int[,] insets, bool hasStandardHandlers)
            : base(new ControlWrapper(control), insets)
        {
            this.control = control;
            HasStandardEventHandlers = hasStandardHandlers;
            control.MouseMove += MouseIndicatorMove;
            resizer = new StandardChartResizer(this);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="insets">insets</param>
        /// <param name="backColor">Bacground color</param>
        public ChartPerformer(int[] size, int[,] insets, Color backColor)
            : base(size, insets, backColor)
        {

        }

        /// <summary>
        /// Constuctor
        /// </summary>
        protected ChartPerformer() : base()
        {
            resizer = new StandardChartResizer(this);
        }

        #endregion

        #region Standard Event Handlers

        /// <summary>
        /// The "has standard event handlers" sign
        /// </summary>
        public bool HasStandardEventHandlers
        {
            get
            {
                return hasStandardHandlers;
            }
            set
            {
                if (value == hasStandardHandlers)
                {
                    return;
                }
                hasStandardHandlers = value;
                if (value)
                {
                    control.MouseDown += new MouseEventHandler(onMouseDown);
                    control.MouseUp += new MouseEventHandler(onMouseUp);
                    control.MouseMove += new MouseEventHandler(onMouseMove);
                    control.MouseLeave += new EventHandler(onMouseLeave);
                    control.MouseEnter += onMouseEnter;
                }
                else
                {
                    control.MouseDown -= new MouseEventHandler(onMouseDown);
                    control.MouseUp -= new MouseEventHandler(onMouseUp);
                    control.MouseMove -= new MouseEventHandler(onMouseMove);
                    control.MouseLeave -= new EventHandler(onMouseLeave);
                    control.MouseEnter -= onMouseEnter;
                }
            }
        }

        /// <summary>
        /// On mouse down event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        protected void onMouseDown(object sender, MouseEventArgs e)
        {
            lastPressed = e.Button;
            if (lastPressed == MouseButtons.Left)
            {
                xp = e.X - insets[0, 0];
                yp = e.Y - insets[0, 1];
                isMoved = true;
                SetCurrent(e);
            }
        }

        /// <summary>
        /// On mouse enter event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        protected void onMouseEnter(object sender, EventArgs e)
        {
            isIndicated = true;
            foreach (IMouseChartIndicator i in mouseIndicators)
            {
                i.IsEnabled = true;
            }
        }

        /// <summary>
        /// On mouse move event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        protected void onMouseMove(object sender, MouseEventArgs e)
        {
            if (!isMoved)
            {
                return;
            }
            SetCurrent(e);
            xc = e.X - insets[0, 0];
            yc = e.Y - insets[0, 1];
            int xmin, ymin, xmax, ymax;
            if (xp > xc)
            {
                xmin = xc;
                xmax = xp;
            }
            else
            {
                xmin = xp;
                xmax = xc;
            }
            if (yp > yc)
            {
                ymin = yc;
                ymax = yp;
            }
            else
            {
                ymin = yp;
                ymax = yc;
            }
            Graphics g = Graphics.FromImage(iTemp);
            dR.X = xmin - DELTA;
            dR.Y = ymin - DELTA;
            dR.Width = 2 * DELTA + xmax - xmin;
            dR.Height = 2 * DELTA + ymax - ymin;
            sR.X = xmin - DELTA;
            sR.Y = ymin - DELTA;
            sR.Width = 2 * DELTA + xmax - xmin;
            sR.Height = 2 * DELTA + ymax - ymin;
            g.DrawImage(image, dR, sR, GraphicsUnit.Pixel);
            g.DrawRectangle(linePen, xmin, ymin, xmax - xmin, ymax - ymin);
            g.Dispose();
            g = Graphics.FromHwnd(control.Handle);
            dR.X = xmin - DELTA + insets[0, 0];
            dR.Y = ymin - DELTA + insets[0, 1];
            dR.Width = 2 * DELTA + xmax - xmin;
            dR.Height = 2 * DELTA + ymax - ymin;
            sR.X = xmin - DELTA;
            sR.Y = ymin - DELTA;
            sR.Width = 2 * DELTA + xmax - xmin;
            sR.Height = 2 * DELTA + ymax - ymin;
            g.DrawImage(iTemp, dR, sR, GraphicsUnit.Pixel);
            g.Dispose();
        }


        /// <summary>
        /// On mouse up event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        protected void onMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                resizer.Resize(xp, yp, xc, yc);
            }
        }

        /// <summary>
        /// On mouse leave event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        protected void onMouseLeave(object sender, EventArgs e)
        {
            if (lastPressed == MouseButtons.Right)
            {
                return;
            }
            if (isMoved)
            {
                RefreshAll();
                isMoved = false;
            }
            isIndicated = false;
            foreach (IMouseChartIndicator i in mouseIndicators)
            {
                i.IsEnabled = false;
            }
        }
 
        #endregion

        #region Additional Event Handlers

        /// <summary>
        /// The mouse Move event
        /// </summary>
        public event MouseEventHandler MouseMove
        {
            add
            {
                control.MouseMove += value;
            }
            remove
            {
                control.MouseMove -= value;
            }
        }

        /// <summary>
        /// The mouse up event
        /// </summary>
        public event MouseEventHandler MouseUp
        {
            add
            {
                control.MouseUp += value;
            }
            remove
            {
                control.MouseUp -= value;
            }
        }

        /// <summary>
        /// The mouse up event
        /// </summary>
        public event MouseEventHandler MouseDown
        {
            add
            {
                control.MouseDown += value;
            }
            remove
            {
                control.MouseDown -= value;
            }
        }

        #endregion

        #region Mouse Indicators


        /// <summary>
        /// Adds an indicator
        /// </summary>
        /// <param name="ind">Indicator for aading</param>
        public void Add(IMouseChartIndicator ind)
        {
            mouseIndicators.Add(ind);
        }

        /// <summary>
        /// Removes an indicator
        /// </summary>
        /// <param name="ind">Indicator for removing</param>
        public void Remove(IMouseChartIndicator ind)
        {
            mouseIndicators.Remove(ind);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Last pressed
        /// </summary>
        public MouseButtons LastPressed
        {
            get
            {
                return lastPressed;
            }
        }

        /// <summary>
        /// Is moved sign
        /// </summary>
        public bool IsMoved
        {
            get { return isMoved; }
            set { isMoved = value; }
        }

        /// <summary>
        /// Adds a performer
        /// </summary>
        /// <param name="performer">Performer to add</param>
        public void Add(ChartPerformer performer)
        {
            if (performer == this)
            {
                throw new Exception();
            }
            if (performer.parent != null)
            {
                throw new Exception();
            }
            children.Add(performer);
            performer.parent = this;
            foreach (ISeries s in painters.Keys)
            {
                performer.AddSeries(s, painters[s]);
            }
        }

        /// <summary>
        /// Removes a performer
        /// </summary>
        /// <param name="performer">Performer to remove</param>
        public void Remove(ChartPerformer performer)
        {
            children.Remove(performer);
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        new public void Remove()
        {
            if (parent != null)
            {
                parent.Remove(this);
                painters.Clear();
            }
        }

        /// <summary>
        /// The "is blocked" sign
        /// </summary>
        new public bool IsBlocked
        {
            get
            {
                return isBlocked;
            }
            set
            {
                isBlocked = value;
                foreach (ChartPerformer p in children)
                {
                    p.IsBlocked = value;
                }
            }
        }

        /// <summary>
        /// Access to size
        /// </summary>
        new public double this[int i, int j]
        {
            get
            {
                return dSize[i, j];
            }
            set
            {
                dSize[i, j] = value;
            }
        }


        /// <summary>
        /// Step along x axis
        /// </summary>
        new public int StepX
        {
            get
            {
                return stepX;
            }
            set
            {
                stepX = value;
            }
        }

        /// <summary>
        /// Step alogn y axis
        /// </summary>
        new public int StepY
        {
            get
            {
                return stepY;
            }
            set
            {
                stepY = value;
            }
        }


        /// <summary>
        /// Internal insets
        /// </summary>
        new public int[,] InternalInsets
        {
            get
            {
                return internalInsets;
            }
        }

        /// <summary>
        /// The invert x - axis sign
        /// </summary>
        new public bool InvertX
        {
            get
            {
                return invertX;
            }
            set
            {
                invertX = value;
            }
        }

        /// <summary>
        /// The invert y - axis sign
        /// </summary>
        new public bool InvertY
        {
            get
            {
                return invertY;
            }
            set
            {
                invertY = value;
            }
        }

        /// <summary>
        /// Painter of coordinates
        /// </summary>
        new public ICoordPainter Coordinator
        {
            get
            {
                return coordPainter;
            }
            set
            {
                coordPainter = value;
            }
        }

        /// <summary>
        /// Calculator of area size
        /// </summary>
        new public Action CalculateAreaSize
        {
            get
            {
                return calculateAreaSize;
            }
            set
            {
                calculateAreaSize = value;
            }
        }

        /// <summary>
        /// Paints itself
        /// </summary>
        /// <param name="g">Graphics to paint</param>
        public override void Paint(Graphics g)
        {
            base.Paint(g);
            if (image == null | isBlocked)
            {
                return;
            }
            if (coordPainter != null)
            {
                if (control != null)
                {
                    coordPainter.ClearInsets(virtualControl, insets);
                    Graphics gc = Graphics.FromHwnd(control.Handle);
                    coordPainter.DrawCoord(gc, insets, dSize, size);
                    gc.Dispose();
                }
            }
        }



        /// <summary>
        /// Performs all refresh operations
        /// </summary>
        public override void RefreshAll()
        {
            if (lastPressed == MouseButtons.Right)
            {
                return;
            }
            base.RefreshAll();
            if (control != null)
            {
                Action act = () =>
                {
                    Graphics g = Graphics.FromHwnd(control.Handle);
                    Paint(g);
                    control.Refresh(); 
                };
                if (!control.InvokeRequired)
                {
                    act();
                }
                control.Invoke(act);
            }
        }


        /// <summary>
        /// Refreshs itself
        /// </summary>
        public void Refresh()
        {
            //Resize();
            //CalculateSize();
            Paint();
            if (coordPainter != null)
            {
                if (control != null)
                {
                    coordPainter.ClearInsets(virtualControl, insets);
                }
            }
            if (control != null)
            {
                control.Refresh();
            }
        }

        /// <summary>
        /// The temporary buffer
        /// </summary>
        new public Image Buffer
        {
            get
            {
                return iTemp;
            }
        }

        /// <summary>
        /// Physical - screen transformation
        /// </summary>
        /// <param name="x">Physical x - coordinate</param>
        /// <param name="y">Physical y - coordinate</param>
        /// <param name="p">Screen coordinates</param>
        new public void Transform(double x, double y, int[] p)
        {
            if (invertX)
            {
                p[0] = (int)((double)size[0] * ((x - dSize[1, 0]) / (dSize[0, 0] - dSize[1, 0])));
            }
            else
            {
                p[0] = (int)((double)size[0] * ((x - dSize[0, 0]) / (dSize[1, 0] - dSize[0, 0])));
            }
            if (invertY)
            {
                p[1] = size[1] - (int)((double)size[1] * ((y - dSize[1, 1]) /
                    (dSize[0, 1] - dSize[1, 1])));
            }
            else
            {
                p[1] = size[1] - (int)((double)size[1] * ((y - dSize[0, 1]) /
                    (dSize[1, 1] - dSize[0, 1])));
            }
        }

        /// <summary>
        /// Physical - screen transformation
        /// </summary>
        /// <param name="x">Physisical coordinates</param>
        /// <param name="point">Screen coordinates</param>
        new public void Transform(double[] x, int[] point)
        {
            if (InvertX)
            {
                point[0] = (int)((double)(size[0])
                    * ((x[0] - dSize[1, 0]) / (dSize[0, 0] - dSize[1, 0])));
            }
            else
            {
                point[0] = (int)((double)((size[0])
                    * (x[0] - dSize[0, 0]) / (dSize[1, 0] - dSize[0, 0])));
            }
            if (InvertY)
            {
                point[1] = size[1]
                    - (int)((double)((size[1])
                    * ((x[1] - dSize[1, 1]) / (dSize[0, 1] - dSize[1, 1]))));
            }
            else
            {
                point[1] = size[1] - (int)((double)((size[1])
                    * ((x[1] - dSize[0, 1]) / (dSize[1, 1] - dSize[0, 1]))));
            }
        }

        /// <summary>
        /// Screen - physical coordinates
        /// </summary>
        /// <param name="ix">Screen x - coordinate</param>
        /// <param name="iy">Screen y - coordinate</param>
        /// <param name="x">Physical x - coordinate</param>
        /// <param name="y">Physical y - coordinate</param>
        new public void Transform(int ix, int iy, out double x, out double y)
        {
            x = 0;
            y = 0;
            int sx = size[0];
            int sy = size[1];
            double dx = dSize[0, 0] - dSize[1, 0];
            double dy = dSize[0, 1] - dSize[1, 1];
            double scx = 0;
            double scy = 0;
            try
            {
                scx = -dx / (double)sx;
                scy =  dy / (double)sy;
            }
            catch (Exception)
            {
                return;
            }
            double ddx = scx * (double)(ix - insets[0, 0]);
            double ddy = scy * (double)(iy - insets[0, 1]);
            if (InvertX)
            {
                x = dSize[1, 0] - ddx;
            }
            else
            {
                x = ddx + dSize[0, 0];
            }
            if (InvertY)
            {
                y = ddy - dSize[1, 1];
            }
            else
            {
                y = dSize[1, 1] + ddy;
            }
        }

        #endregion

        #region Protected & Private Members


        /// <summary>
        /// Draws histogram
        /// </summary>
        /// <param name="o">Histogram object</param>
        /// <param name="g">Graphics</param>
        protected void drawHistogram(object[] o, Graphics g)
        {
            double[,] hist = (double[,])o[0];
            Color color = (Color)o[1];
            double step = hist[1, 0] - hist[0, 0];
            double[] x = new double[2];
            int[] il = new int[2];
            int[] ir = new int[2];
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(color);
            for (int i = 0; i < hist.GetLength(0); i++)
            {
                x[0] = hist[i, 0];
                x[1] = hist[i, 1];
                Transform(x, il);
                x[0] += step;
                x[1] = 0;
                Transform(x, ir);
                int w = ir[0] - il[0];
                int h = ir[1] - il[1];
                g.FillRectangle(brush, il[0], il[1], w, h);
                g.DrawRectangle(pen, il[0], il[1], w, h);
            }
        }

        /// <summary>
        /// Resizes histogram
        /// </summary>
        /// <param name="o">Diagram object</param>
        protected void resizeHistogram(object[] o)
        {
            double[,] hist = o[0] as double[,];
            if (hist[0, 0] < dSize[0, 0])
            {
                dSize[0, 0] = hist[0, 0];
            }
            double a = hist[hist.GetLength(0) - 1, 0] + hist[1, 0] - hist[0, 0];
            if (a > dSize[1, 0])
            {
                dSize[1, 0] = a;
            }
            if (dSize[0, 1] > 0)
            {
                dSize[0, 1] = 0;
            }
            for (int i = 0; i < hist.GetLength(0); i++)
            {
                a = hist[i, 1];
                if (dSize[1, 1] < a)
                {
                    dSize[1, 1] = a;
                }
            }
        }

        /// <summary>
        /// Mouse move event handler
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="args">Arguments of event</param>
        private void MouseIndicatorMove(object sender, MouseEventArgs args)
        {
            if (isMoved)
            {
                return;
            }
            if (!isIndicated)
            {
                return;
            }
            if (mouseIndicators.Count == 0)
            {
                return;
            }
            int ix = args.X;
            int iy = args.Y;
            double x;
            double y;
            Transform(ix, iy, out x, out y);
            foreach (IMouseChartIndicator i in mouseIndicators)
            {
                i.Indicate(x, y);
            }
        }

        void SetCurrent(MouseEventArgs e)
        {
            SetCurrent(e.X, e.Y);
        }


        #endregion

        #region Helper Classes


        class StandardChartResizer : IChartResizer
        {
            #region Fields
            private ChartPerformer performer;
            #endregion

            #region Ctor

            internal StandardChartResizer(ChartPerformer performer)
            {
                this.performer = performer;
            }

            #endregion


            #region IChartResizer Members

            void IChartResizer.Resize(int xold, int yold, int xnew, int ynew)
            {
                int xp = xold;
                int yp = yold;
                int xc = xnew;
                int yc = ynew;
                if ((xp < xc) & (yp < yc))
                {
                    double xb = performer.dSize[0, 0];
                    double xd = performer.dSize[1, 0] - performer.dSize[0, 0];
                    performer.dSize[0, 0] = xb + (double)xp * xd / (double)(performer.size[0]);
                    performer.dSize[1, 0] = xb + (double)xc * xd / (double)(performer.size[0]);
                    double yb = performer.dSize[1, 1];
                    double yd = performer.dSize[1, 1] - performer.dSize[0, 1];
                    performer.dSize[0, 1] = yb - (double)yc * yd / (double)(performer.size[1]);
                    performer.dSize[1, 1] = yb - (double)yp * yd / (double)(performer.size[1]);
                    performer.Refresh();
                }
                else
                {
                    performer.RefreshAll();
                }
                Graphics g = Graphics.FromImage(performer.iTemp);
                g.DrawImage(performer.image, 0, 0, performer.image.Width, performer.image.Height);
                g.Dispose();
                performer.isMoved = false;
            }

            #endregion
        }

        class ControlWrapper : IControl
        {
            #region Fields

            Control control;

            #endregion


            internal ControlWrapper(Control control)
            {
                this.control = control;
            }

            #region IControl Members

            Color IControl.BackColor
            {
                get { return control.BackColor; }
            }

            int IControl.Width
            {
                get { return control.Width; }
            }

            int IControl.Height
            {
                get { return control.Height; }
            }

            #endregion
        }

        #endregion

    }

}
