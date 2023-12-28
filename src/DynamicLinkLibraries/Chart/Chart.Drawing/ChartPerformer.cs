using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;


using Chart.Drawing.Interfaces;
using Chart.Drawing.Painters;

namespace Chart.Drawing
{
    /// <summary>
    /// Performer of chart
    /// </summary>
    public class ChartPerformer
    {

        #region Fields

        /// <summary>
        /// Shift delta
        /// </summary>
        const int DELTA = 5;

        /// <summary>
        /// Control to draw
        /// </summary>
        protected IControl virtualControl = null;

        /// <summary>
        /// internal insets 
        /// </summary>
        protected int[,] internalInsets = new int[,] { { 0, 0 }, { 0, 0 } };

        /// <summary>
        /// Array of series
        /// </summary>
        protected List<ISeries> series = new List<ISeries>();

        /// <summary>
        /// Painters of series
        /// </summary>
        protected Dictionary<ISeries, ISeriesPainter> painters = new Dictionary<ISeries, ISeriesPainter>();

        /// <summary>
        /// Size of canvas
        /// </summary>
        protected int[] size = new int[2];

        /// <summary>
        /// Physical size
        /// </summary>
        protected double[,] dSize = new double[2, 2];

        /// <summary>
        /// Insets
        /// </summary>
        protected int[,] insets;

        /// <summary>
        /// Temporary buffer
        /// </summary>
        protected Image iTemp;

        /// <summary>
        /// Buffer
        /// </summary>
        protected Image image;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected int xp;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected int yp;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected int xc;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected int yc;

        /// <summary>
        /// Rectangle for drawing
        /// </summary>
        protected Rectangle r = new Rectangle();

        /// <summary>
        /// Painter of coordinates
        /// </summary>
        protected ICoordPainter coordPainter = null;


        /// <summary>
        /// Pen for coordinates drawing
        /// </summary>
        protected Pen linePen;

        /// <summary>
        /// Source rectangle
        /// </summary>
        protected Rectangle sR;

        /// <summary>
        /// Descination rectangle
        /// </summary>
        protected Rectangle dR;

        /// <summary>
        /// The invert x - axis sign
        /// </summary>
        protected bool invertX = false;


        /// <summary>
        /// The invert y - axis sign
        /// </summary>
        protected bool invertY = false;

        /// <summary>
        /// Background color
        /// </summary>
        protected Color backColor;

        /// <summary>
        /// Step along x axis
        /// </summary>
        protected int stepX = 0;

        /// <summary>
        /// Step alogn y axis
        /// </summary>
        protected int stepY = 0;

        /// <summary>
        /// The blocked sign
        /// </summary>
        protected bool isBlocked = false;

        /// <summary>
        /// The "is indicated" sign
        /// </summary>
        protected bool isIndicated = false;

 
        /// <summary>
        /// Width
        /// </summary>
        protected int width;

        /// <summary>
        /// Height
        /// </summary>
        protected int height;

        /// <summary>
        /// Calcuales size of area
        /// </summary>
        protected Action calculateAreaSize;

        /// <summary>
        /// Children performers
        /// </summary>
        protected List<ChartPerformer> children = new List<ChartPerformer>();

        /// <summary>
        /// Parent performer
        /// </summary>
        protected ChartPerformer parent;

        protected double currentX = 0;

        protected double currentY = 0;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="control">Control to draw</param>
        /// <param name="insets">Insets</param>
        public ChartPerformer(IControl control, int[,] insets)
            : this()
        {
            this.virtualControl = control;
            this.insets = insets;
            linePen = new Pen(Color.Black);
            sR = new Rectangle();
            dR = new Rectangle();
            SetInsets();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="insets">insets</param>
        /// <param name="backColor">Bacground color</param>
        public ChartPerformer(int[] size, int[,] insets, Color backColor)
        {
            this.size = size;
            this.insets = insets;
            this.backColor = backColor;
            linePen = new Pen(Color.Black);
            sR = new Rectangle();
            dR = new Rectangle();
            image = new Bitmap(size[0], size[1]);
            iTemp = new Bitmap(size[0], size[1]);
            Image im = image;
            Graphics g = Graphics.FromImage(im);
            Color back = Bkgnd;
            g.FillRectangle(new SolidBrush(back), 0, 0, im.Width, im.Height);
            g.Dispose();
            im = iTemp;
            g = Graphics.FromImage(im);
            g.FillRectangle(new SolidBrush(back), 0, 0, im.Width, im.Height);
            g.Dispose();
            SetInsets();
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        protected ChartPerformer()
        {
            calculateAreaSize = delegate()
            {
                width = virtualControl.Width;
                height = virtualControl.Height;
            };
        }

        #endregion

        #region Public Members

        /// <summary>
        /// First series
        /// </summary>
        public ISeries First
        {
            get
            {
                if (series != null)
                {
                    if (series.Count > 0)
                    {
                        return series.First();
                    }
                }
                return null;
            }
        }



        /// <summary>
        /// Current physical value of X - coordinate
        /// </summary>
        public double CurrentX
        {
            get
            {
                return currentX;
            }
        }

        /// <summary>
        /// Current physical value of Y - coordinate
        /// </summary>
        public double CurrentY
        {
            get
            {
                return currentY;
            }
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
        public void Remove()
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
        public bool IsBlocked
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
        public double this[int i, int j]
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
        public int StepX
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
        public int StepY
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
        public int[,] InternalInsets
        {
            get
            {
                return internalInsets;
            }
        }

        /// <summary>
        /// The invert x - axis sign
        /// </summary>
        public bool InvertX
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
        public bool InvertY
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
        public ICoordPainter Coordinator
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
        public Action CalculateAreaSize
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
        /// Adds series
        /// </summary>
        /// <param name="s">Series to add</param>
        /// <param name="color">Color</param>
        public void AddSeries(ISeries s, Color color)
        {
            ISeriesPainter p = new SimpleSeriesPainter(new Color[] { color });
            AddSeries(s, p);
        }

        /// <summary>
        /// Adds series
        /// </summary>
        /// <param name="s">Series to add</param>
        /// <param name="color">Color</param>
        public void AddSeries(ISeries s, Color[] color)
        {
            ISeriesPainter p = new SimpleSeriesPainter(color);
            AddSeries(s, p);
        }


        public void AddSeries(ISeries s, ISeriesPainter painter)
        {
            if (parent != null)
            {
                parent.AddSeries(s, painter);
                return;
            }
            series.Add(s);
            painter.Performer = this;
            painters[s] = painter;
            foreach (ChartPerformer ch in children)
            {
                ISeriesPainter p = painter.Clone() as ISeriesPainter;
                ch.AddSeries(s, p);
            }
        }

        /// <summary>
        /// Access to series
        /// </summary>
        public ISeries this[int n]
        {
            get
            {
                return series[n];
            }
        }

        /// <summary>
        /// Count of series
        /// </summary>
        public int Count
        {
            get
            {
                return series.Count;
            }
        }

        /// <summary>
        /// The last series
        /// </summary>
        public ISeries Last
        {
            get
            {
                if (series.Count == 0)
                {
                    return null;
                }
                return this[Count - 1];
            }
        }

        /// <summary>
        /// Removes all series
        /// </summary>
        public void RemoveAll()
        {
            series.Clear();
        }


        /// <summary>
        /// Removes series those have attribute
        /// </summary>
        /// <param name="attributeType"></param>
        public void Remove(Type attributeType)
        {
            List<ISeries> l = new List<ISeries>();
            foreach (ISeries s in series)
            {
                Type type = s.GetType();
                object[] da = type.GetCustomAttributes(attributeType, true);
                if (da != null)
                {
                    if (da.Length > 0)
                    {
                        l.Add(s);
                    }
                }
            }
            l.ForEach(delegate(ISeries s)
            {
                series.Remove(s);
            }
        );
        }

        /// <summary>
        /// Removes a series
        /// </summary>
        /// <param name="s">The series to remove</param>
        public void Remove(ISeries s)
        {
            if (parent != null)
            {
                parent.Remove(s);
                return;
            }
            series.Remove(s);
            if (painters.ContainsKey(s))
            {
                painters.Remove(s);
            }
        }

        /// <summary>
        /// Size calculation
        /// </summary>
        public void CalculateSize()
        {
            if (Count == 0)
            {
                dSize[0, 0] = -1;
                dSize[0, 1] = -1;
                dSize[1, 0] = 1;
                dSize[1, 1] = 1;
                return;
            }
            for (int i = 0; i < Count; i++)
            {
                ISeries s = this[i];
                double[,] size = s.Size;
                if (i == 0)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            dSize[j, k] = size[j, k];
                        }
                    }
                    continue;
                }
                for (int j = 0; j < 2; j++)
                {
                    if (size[0, j] < dSize[0, j])
                    {
                        dSize[0, j] = size[0, j];
                    }
                    if (size[1, j] > dSize[1, j])
                    {
                        dSize[1, j] = size[1, j];
                    }
                }
            }
            //resizeHistograms();
            for (int i = 0; i < 2; i++)
            {
                double[] p = new double[3];
                double a = size[i] + internalInsets[i, 0] + internalInsets[i, 1];
                p[0] = (double)internalInsets[0, i] / a;
                p[1] = (double)size[i] / a;
                p[2] = (double)internalInsets[1, i] / a;
                double min = dSize[0, i];
                double max = dSize[1, i];
                dSize[0, i] = min - p[0] * (max - min);
                dSize[1, i] = max + p[2] * (max - min);
            }
            for (int i = 0; i < 2; i++)
            {
                if (dSize[0, i] == dSize[1, i])
                {
                    if (dSize[1, i] > 0)
                    {
                        dSize[0, i] = 0;
                        dSize[1, i] *= 1.1;
                    }
                    else if (dSize[1, i] < 0)
                    {
                        dSize[1, i] = 0;
                        dSize[0, i] *= 1.1;
                    }
                    else
                    {
                        dSize[0, i] = -1;
                        dSize[1, i] = 1;
                    }
                }
            }
            if (dSize[0, 1] != dSize[1, 1])
            {
                double delta = 0.02 * (dSize[1, 1] - dSize[0, 1]);
                dSize[0, 1] -= delta;
                dSize[1, 1] += delta;
            }
            IsNaN(true);
        }



        /// <summary>
        /// Size of canvas
        /// </summary>
        public int[] CanvasSize
        {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// Resizes itself
        /// </summary>
        public void Resize()
        {
            if (isBlocked)
            {
                return;
            }
            if (virtualControl != null)
            {
                calculateAreaSize();
                size[0] = width - insets[0, 0] - insets[1, 0];
                size[1] = height - insets[0, 1] - insets[1, 1];
                if (size[0] <= 0 | size[1] <= 0)
                {
                    return;
                }
                image = new Bitmap(size[0], size[1]);
                iTemp = new Bitmap(size[0], size[1]);
            }
            else
            {
                image = new Bitmap(size[0], size[1]);
                iTemp = new Bitmap(size[0], size[1]);
                Image im = image;
                Graphics g = Graphics.FromImage(im);
                Color back = Bkgnd;
                g.FillRectangle(new SolidBrush(back), 0, 0, im.Width, im.Height);
                g.Dispose();
                im = iTemp;
                g = Graphics.FromImage(im);
                g.FillRectangle(new SolidBrush(back), 0, 0, im.Width, im.Height);
                g.Dispose();
            }
            CalculateSize();
        }



        /// <summary>
        /// Bitmap
        /// </summary>
        public Image Image
        {
            get
            {
                Bitmap bitmap = new Bitmap(size[0] + insets[0, 0] + insets[1, 0],
                    size[1] + insets[0, 1] + insets[1, 1]);
                Paint();
                Graphics g = Graphics.FromImage(bitmap);
                g.FillRectangle(new SolidBrush(Bkgnd), 0, 0, bitmap.Width, bitmap.Height);
                g.DrawImage(image, insets[0, 0], insets[0, 1], image.Width, image.Height);
                if (coordPainter != null)
                {
                    coordPainter.DrawCoord(g, insets, dSize, size);
                }
                g.Dispose();
                return bitmap;
            }
        }

        /// <summary>
        /// Paints itself
        /// </summary>
        public void Paint()
        {
            if (isBlocked)
            {
                return;
            }
            if (image == null)
            {
                return;
            }
            Brush brush = new SolidBrush(Bkgnd);
            Graphics gi = Graphics.FromImage(image);
            gi.FillRectangle(brush, 0, 0, image.Width, image.Height);
            if (IsNaN(false))
            {
                return;
            }
            if (coordPainter != null)
            {
                coordPainter.DrawCoord(gi, dSize, size);
            }
            for (int i = 0; i < Count; i++)
            {
                ISeries s = this[i];
                ISeriesPainter p = null;
                if (painters.ContainsKey(s))
                {
                    p = painters[s];
                }
                else
                {
                    p = new SimpleSeriesPainter(new Color[] { Color.Black });
                    p.Performer = this;
                    painters[s] = p;
                }
                if (p != null)
                {
                    p.Draw(s, gi);
                }
            }
            //drawHistograms(gi);
            gi.Dispose();
            gi = Graphics.FromImage(iTemp);
            gi.DrawImage(image, 0, 0, image.Width, image.Height);
            gi.Dispose();
        }

        /// <summary>
        /// Paints itself
        /// </summary>
        /// <param name="g">Graphics to paint</param>
        public virtual void Paint(Graphics g)
        {
            if (isBlocked)
            {
                return;
            }
            if (image == null)
            {
                return;
            }
            g.DrawImage(iTemp, insets[0, 0], insets[0, 1], iTemp.Width, iTemp.Height);
            if (IsNaN(false))
            {
                return;
            }
        }

        /// <summary>
        /// Performs all refresh operations
        /// </summary>
        public virtual void RefreshAll()
        {
            if (isBlocked)
            {
                return;
            }
            Resize();
            Paint();
            if (coordPainter != null)
            {
                if (virtualControl != null)
                {
                    coordPainter.ClearInsets(virtualControl, insets);
                }
            }
       }

        /// <summary>
        /// The temporary buffer
        /// </summary>
        public Image Buffer
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
        public void Transform(double x, double y, int[] p)
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
        /// <param name="x">Physical x - coordinate</param>
        /// <param name="y">Physical y - coordinate</param>
        /// <param name="p">Screen coordinates</param>
        public void Transform(double x, double[] y, int[] p)
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
                for (var i = 0; i < y.Length; i++)
                {
                    p[i + 1] = size[1] - (int)((double)size[1] * ((y[i] - dSize[1, 1]) /
                    (dSize[0, 1] - dSize[1, 1])));
                }
            }
            else
            {
                for (var i = 0; i < y.Length; i++)
                {
                    p[i + 1] = size[1] - (int)((double)size[1] * ((y[i] - dSize[0, 1]) /
                    (dSize[1, 1] - dSize[0, 1])));
                }
            }
        }



        /// <summary>
        /// Physical - screen transformation
        /// </summary>
        /// <param name="x">Physisical coordinates</param>
        /// <param name="point">Screen coordinates</param>
        public void Transform(double[] x, int[] point)
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
        public void Transform(int ix, int iy, out double x, out double y)
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
                scy = dy / (double)sy;
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

        #region Protected Members

        /// <summary>
        /// Draws histogram
        /// </summary>
        /// <param name="o">Histogram object</param>
        /// <param name="g">Graphics</param>
        protected void DrawHistogram(object[] o, Graphics g)
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
        protected void ResizeHistogram(object[] o)
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
        /// Background color
        /// </summary>
        protected Color Bkgnd
        {
            get
            {
                if (virtualControl != null)
                {
                    return virtualControl.BackColor;
                }
                return backColor;
            }
        }

        protected void SetCurrent(int x, int y)
        {
            Transform(x, y, out currentX, out currentY);
        }

        #endregion

        #region Private Members

        private bool IsNaN(bool exception)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (Double.IsNaN(dSize[i, j]))
                    {
                        series.Clear();
                        CalculateSize();
                        if (exception)
                        {
                            throw new Exception("NAN");
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        void SetInsets()
        {
            Bitmap bmp = new Bitmap(2, 2);
            Graphics g = Graphics.FromImage(bmp);
            insets[1, 1] = (int)((g.DpiY / 96f) * (float)insets[1, 1]);
        }

        #endregion

        #endregion

    }
}
