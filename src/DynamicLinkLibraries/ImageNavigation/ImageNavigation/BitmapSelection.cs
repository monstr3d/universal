using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;

using BitmapConsumer;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

namespace ImageNavigation
{
    /// <summary>
    /// Selection associated with bitmap
    /// </summary>
    [Serializable()]
    public class BitmapSelection : ICategoryObject, ISerializable, IMeasurements, IStructuredSelection,
        IUpdatableSelection, IBitmapConsumer, IStructuredSelectionCollection, IDisposable
    {


        #region Fields

        /// <summary>
        /// Add remove event
        /// </summary>
        event Action<IBitmapProvider, bool> addRemove =
            (IBitmapProvider p, bool b) => { };
 
        /// <summary>
        /// Shifts
        /// </summary>
        private static readonly int[,] sh = new int[,]{{1, 1}, {0, 1}, {-1, 1}, {-1, 0}, 
											{-1, -1}, {0, -1}, {1, -1}, {1, 0}};

        /// <summary>
        /// Border shifts
        /// </summary>
        private static readonly int[,] bsh = new int[,] { { 0, 1 }, { -1, 0 }, { 0, -1 }, { 1, 0 } };

        /// <summary>
        /// Bitmap
        /// </summary>
        private Bitmap bitmap;

        /// <summary>
        /// Camera
        /// </summary>
        private IBitmapProvider bmpProvider;

        /// <summary>
        /// Associated object
        /// </summary>
        private object obj;

        /// <summary>
        /// Color of fon
        /// </summary>
        private Color fonColor;

        /// <summary>
        /// Left border
        /// </summary>
        private Point left;

        /// <summary>
        /// Right border
        /// </summary>
        private Point right;

        /// <summary>
        /// Edge of bitmap
        /// </summary>
        private List<Point>[] bitmapEdge;

        /// <summary>
        /// Edge of camera
        /// </summary>
        private List<Point>[] cameraEdge;

        /// <summary>
        /// Measurements data
        /// </summary>
        private object[] data;

        /// <summary>
        /// Fixed data
        /// </summary>
        private object[] fixedData;

        /// <summary>
        /// Measure
        /// </summary>
        private IMeasurement measurement;

        /// <summary>
        /// Edge delta
        /// </summary>
        private int delta = 10;

        /// <summary>
        /// Bitmap provider
        /// </summary>
        private IBitmapProvider provider;

        /// <summary>
        /// Type of array
        /// </summary>
        private static readonly double a = 0;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        private static readonly double? b = 0;

 
        /// <summary>
        /// The scale of X direction
        /// </summary>
        private double scaleX;

        /// <summary>
        /// The scale of Y direction
        /// </summary>
        private double scaleY;

 
        #endregion

        #region Constructors


        /// <summary>
        /// Default constructor
        /// </summary>
        public BitmapSelection()
        {

            measurement = new Measurement(new object[] { a, a }, getData, "Selection", this);
        }

        /// <summary>
        /// Deserilaization constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        public BitmapSelection(SerializationInfo info, StreamingContext context)
        {
            try
            {
                Bitmap = (Bitmap)info.GetValue("Bitmap", typeof(Bitmap));
                measurement = new Measurement(new object[] { a, a }, getData, "Selection", this);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }


        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bitmap", bitmap);
        }

        #endregion

        #region ICategoryObject Members

        public ICategory Category
        {
            get
            {
                // TODO:  Add BitmapSelection.Category getter implementation
                return null;
            }
        }

        public ICategoryArrow Id
        {
            get
            {
                // TODO:  Add BitmapSelection.Id getter implementation
                return null;
            }
        }

        #endregion

        #region IAssociatedObject Members

        public object Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        #endregion

        #region IMeasurements Members

        public int Count
        {
            get
            {
                return 1;
            }
        }

        public IMeasurement this[int n]
        {
            get
            {
                return measurement;
            }
        }

        public void UpdateMeasurements()
        {
            Bitmap bmp = bmpProvider.Bitmap;
            cameraEdge = createFigureEdge(bmp);
            int n = bitmapEdge[0].Count / delta + bitmapEdge[1].Count / delta;
            if (data == null)
            {
                data = new object[n];
            }
            if (data.Length != n)
            {
                data = new object[n];
            }
            int i = 0;
            for (int j = 0; j < 2; j++)
            {
                List<Point> be = bitmapEdge[j];
                List<Point> ce = cameraEdge[j];
                Point l = ce[0];
                Point r = ce[ce.Count - 1];
                for (int k = 0; k < be.Count; k += delta)
                {
                    Point pb = be[k];
                    double m = 10000000000;
                    foreach (Point pc in ce)
                    {
                        double x = pb.X - pc.X;
                        double y = pb.Y - pc.Y;
                        double a = x * x + y * y;
                        if (m > a)
                        {
                            m = a;
                        }
                    }
                    data[i] = Math.Sqrt(m);
                    ++i;
                    if (i == n)
                    {
                        return;
                    }
                }
            }
        }


        public string SourceName
        {
            get
            {
                IObjectLabel l = obj as IObjectLabel;
                return l.Name;
            }
        }

        public bool IsUpdated
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        #endregion

        #region IStructuredSelection Members

        public int DataDimension
        {
            get
            {
                try
                {
                    return fixedData.Length;
                }
                catch (Exception ex)
                {

                }
                return 0;
            }
        }

        double? IStructuredSelection.this[int n]
        {
            get
            {
                return (double?)fixedData[n];
            }
        }

        public double GetWeight(int n)
        {
            return 1;
        }

        public double GetApriorWeight(int n)
        {
            return 0;
        }

        public int GetTolerance(int n)
        {
            return 0;
        }

        public void SetTolerance(int n, int tolerance)
        {

        }

        public bool HasFixedAmount
        {
            get
            {
                return false;
            }
        }

        public string Name
        {
            get
            {
                return "Bitmap";
            }
        }

        #endregion

        #region IUpdatableSelection Members

        public void UpdateSelection()
        {
            UpdateMeasurements();
            if (fixedData == null)
            {
                fixedData = new object[data.Length];
            }
            if (fixedData.Length != data.Length)
            {
                fixedData = new object[data.Length];
            }
            for (int i = 0; i < data.Length; i++)
            {
                fixedData[i] = b;
            }
        }

        #endregion

        #region IBitmapConsumer Members

        public void Process()
        {
            Bitmap = provider.Bitmap.Clone() as Bitmap;
        }

          /// <summary>
        /// Providers
        /// </summary>
        IEnumerable<IBitmapProvider> IBitmapConsumer.Providers
        {
            get
            {
                if (provider != null)
                {
                    yield return provider;
                }
            }
        }

        /// <summary>
        /// Adds a provider
        /// </summary>
        /// <param name="provider">The provider</param>
        void IBitmapConsumer.Add(IBitmapProvider provider)
        {
            this.provider = provider;
            Bitmap = provider.Bitmap.Clone() as Bitmap;
        }

        /// <summary>
        /// Removes a provider
        /// </summary>
        /// <param name="provider">The provider</param>
        void IBitmapConsumer.Remove(IBitmapProvider provider)
        {
            this.provider = null;
        }

        /// <summary>
        /// Add remove event of provider. If "bool" is true then adding
        /// </summary>
        event Action<IBitmapProvider, bool> IBitmapConsumer.AddRemove
        {
            add { addRemove += value; }
            remove { addRemove -= value; }
        }

        #endregion

        #region IStructuredSelectionCollection Members

        int IStructuredSelectionCollection.Count
        {
            get
            {
                return 1;
            }
        }

        IStructuredSelection IStructuredSelectionCollection.this[int i]
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IDispoable Members

        void IDisposable.Dispose()
        {
            if (bitmap != null)
            {
                bitmap.Dispose();
            }
        }

        #endregion

        #region Specific Members

        public Bitmap Bitmap
        {
            set
            {
                bitmap = value;
                fonColor = bitmap.GetPixel(0, 0);
                bitmapEdge = createFigureEdge(bitmap);
            }
            get
            {
                return bitmap;
            }
        }

        public Bitmap EdgeBitmap
        {
            get
            {
                if (bitmap == null)
                {
                    return null;
                }
                Bitmap bmp = new Bitmap(bitmap.Width, bitmap.Height);
                /*Graphics g = Graphics.FromImage(bmp);
                Brush brush = new SolidBrush(Color.White);
                g.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
                Color bC = Color.Red;
                foreach (List<Point> l in bitmapEdge)
                {
                    foreach (Point p in l)
                    {
                        bmp.SetPixel(p.X, p.Y, bC);
                    }
                }*/
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
                if (bmpProvider != null)
                {
                    try
                    {
                        cameraEdge = createFigureEdge(bmpProvider.Bitmap);
                        Color cC = Color.Red;
                        foreach (List<Point> l in cameraEdge)
                        {
                            foreach (Point p in l)
                            {
                                if ((p.X >= 0) & (p.Y >= 0) & (p.X < bmp.Width) & (p.Y < bmp.Height))
                                {
                                    bmp.SetPixel(p.X, p.Y, cC);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ShowError(10);
                    }
                }
                return bmp;
            }
        }

 
        public Bitmap CreateBitmap(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            scaleX = (double)width / (double)bitmap.Width;
            scaleY = (double)height / (double)bitmap.Height;
            Graphics g = Graphics.FromImage(bmp);
            Brush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
            Color bC = Color.Red;
            foreach (List<Point> l in bitmapEdge)
            {
                foreach (Point p in l)
                {
                    bmp.SetPixel(GetX(p.X), GetY(p.Y), bC);
                }
            }
            if (bmpProvider != null)
            {
                try
                {
                    cameraEdge = createFigureEdge(bmpProvider.Bitmap);
                    Color cC = Color.Blue;
                    foreach (List<Point> l in cameraEdge)
                    {
                        foreach (Point p in l)
                        {
                            bmp.SetPixel(GetX(p.X), GetY(p.Y), cC);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
            }
            return bmp;
        }

 
        public IBitmapProvider BitmapProvider
        {
            set
            {
                if (value == null)
                {
                    bmpProvider = null;
                    return;
                }
                if (bmpProvider != null)
                {
                    throw new Exception("Camera already exists");
                }
                bmpProvider = value;
            }
        }


        private int GetX(int x)
        {
            double a = scaleX * (double)x;
            return (int)a;
        }
        
        private int GetY(int y)
        {
            double a = scaleY * (double)y;
            return (int)a;
        }

        private List<Point>[] createFigureEdge(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (!bmp.GetPixel(i, j).Equals(fonColor) & (i > 0) & (j > 0))
                    {
                        left = new Point(i - 1, j);
                        goto endLeft;
                    }
                }
            }
        endLeft:
            for (int i = bmp.Width - 1; i >= 0; i--)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (!bmp.GetPixel(i, j).Equals(fonColor))
                    {
                        right = new Point(i + 1, j);
                        goto endRight;
                    }
                }
            }
        endRight:
            List<Point> l = new List<Point>();
            l.Add(left);
            int n = 0;
            Point p1 = addPoint(left, bmp, l, ref n);
            n = 0;
            Point p2 = addPoint(left, bmp, l, ref n);
            Point pt = (p1.Y < p2.Y) ? p1 : p2;
            Point pb = (p1.Y < p2.Y) ? p2 : p1;
            List<Point> lt = new List<Point>();
            lt.Add(left);
            lt.Add(pt);
            createFigureEdge(bmp, pt, lt);
            List<Point> lb = new List<Point>();
            lb.Add(left);
            lb.Add(pb);
            createFigureEdge(bmp, pb, lb);
            return new List<Point>[] { lt, lb };
        }

        private object getData()
        {
            return data;
        }

        private void createFigureEdge(Bitmap bmp, Point p, List<Point> list)
        {
            int n = 0;
            Point point = new Point(p.X, p.Y);
            do
            {
                point = addPoint(point, bmp, list, ref n);
            }
            while (point.X > 0);
        }

        private Point addPoint(Point point, Bitmap bmp, List<Point> list, ref int n)
        {
            Point p = new Point(point.X, point.Y);
            for (int i = 0; i < sh.GetLength(0); i++)
            {
                p.X = point.X + sh[i, 0];
                p.Y = point.Y + sh[i, 1];
                Color c = fonColor;
                if ((p.X >= 0) & (p.Y >= 0))
                {
                    c = bmp.GetPixel(p.X, p.Y);
                }
                if ((!c.Equals(fonColor)) | (!layOnBoundary(p, bmp)) | list.Contains(p))
                {
                    continue;
                }
                if (p.Equals(right))
                {
                    return new Point(-1, 0);
                }
                list.Add(p);
                n = list.Count - 1;
                return p;
            }
            Point po = (Point)list[n - 1];
            n = n - 1;
            return addPoint(po, bmp, list, ref n);
        }

        private bool layOnBoundary(Point p, Bitmap bmp)
        {
            for (int i = 0; i < bsh.GetLength(0); i++)
            {
                int x = p.X + bsh[i, 0];
                int y = p.Y + bsh[i, 1];
                Color c = fonColor;
                if ((x < 0) | (y < 0) | (x >= bmp.Width) | (y >= bmp.Height))
                {

                }
                else
                {
                    c = bmp.GetPixel(p.X + bsh[i, 0], p.Y + bsh[i, 1]);
                }
                if (!c.Equals(fonColor))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion


    }
}
