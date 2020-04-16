using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace Chart
{
    /// <summary>
    /// Performer of dictionary operations
    /// </summary>
    [Serializable()]
    public class DictionaryPerformer : ISerializable
    {
        #region Fields

        Action<IDictionary<string, object>, double> add;

 
        Dictionary<string, PenValue> pens = new Dictionary<string, PenValue>();

        Dictionary<string, PenSave> save = new Dictionary<string, PenSave>();

        Dictionary<string, Tuple<Pen, bool, double[], Func<object, double>>> dictionary =
            new Dictionary<string, Tuple<Pen, bool, double[], Func<object, double>>>();

        int bufferSize = 50;

        private Bitmap bmp;

        private Bitmap bmpOld;


        private Bitmap bmpNew;

        private Dictionary<string, Func<object, double>> converters = new Dictionary<string, Func<object, double>>();

        private Brush fonBrush = new SolidBrush(Color.Black);

        double invertedHeight;

        Rectangle oldRect;

        Rectangle newRect;

        Rectangle dRect;

        Control contol;

        private int wNew = 0;

        private List<string> exists = new List<string>();

        private double interval = 0;

        private double currentTime;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DictionaryPerformer()
        {
            init();
        }



        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DictionaryPerformer(SerializationInfo info, StreamingContext context) 
        {
            save = SerializationPerformer.GetObject<Dictionary<string, PenSave>>(info, "Pens");
            foreach (string s in save.Keys)
            {
                PenSave ps = save[s];
                PenValue pv = Transform(ps);
                pens[s] = pv;
            }
            init();
        }


        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            SerializationPerformer.Serialize(save, info, "Pens");
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Clears itself
        /// </summary>
        public void Clear()
        {
            pens.Clear();
            save.Clear();
            dictionary.Clear();
            converters.Clear();
        }

        /// <summary>
        /// Names of existed series
        /// </summary>
        public ICollection<string> Exists
        {
            get
            {
                List<string> ex = new List<string>(save.Keys);
                foreach (string s in ex)
                {
                    if (!exists.Contains(s))
                    {
                        save.Remove(s);
                        pens.Remove(s);
                    }
                }
                return exists;
            }
        }

        /// <summary>
        /// Removes series
        /// </summary>
        /// <param name="s">Series name</param>
        public void Remove(string s)
        {
            save.Remove(s);
        }

        /// <summary>
        /// Gets pen for series
        /// </summary>
        /// <param name="s">Series name</param>
        /// <returns>The pen</returns>
        public Pen GetPen(string s)
        {
            if (!save.ContainsKey(s))
            {
                return null;
            }
            return new Pen(save[s].color);
        }

        /// <summary>
        /// Gets minimal value for series
        /// </summary>
        /// <param name="s">Series name</param>
        /// <returns>Minimal value</returns>
        public double GetMin(string s)
        {
            if (!save.ContainsKey(s))
            {
                return 0;
            }
            return save[s].min;
        }

        /// <summary>
        /// Gets maximal value for series
        /// </summary>
        /// <param name="s">Series name</param>
        /// <returns>Maximal value</returns>
        public double GetMax(string s)
        {
            if (!save.ContainsKey(s))
            {
                return 1;
            }
            return save[s].max;
        }

        /// <summary>
        /// Active seies names
        /// </summary>
        public ICollection<string> Active
        {
            get
            {
                return save.Keys;
            }
        }

        /// <summary>
        /// Resets itself
        /// </summary>
        public void Reset()
        {
            add = AddNew;
        }


        /// <summary>
        /// Control for paint
        /// </summary>
        public Control Control
        {
            set
            {
                contol = value;
                CreateBitmaps(value);
                value.Resize += Resize;
                value.Paint += Paint;
            }
        }

        /// <summary>
        /// Interval
        /// </summary>
        public double Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
            }
        }

        /// <summary>
        /// Writes dictionary
        /// </summary>
        /// <param name="d">The dictionary to write</param>
        public void Write(IDictionary<string, object> d, double time = 0)
        {
            add(d, time);
        }

        /// <summary>
        /// Access to function by name
        /// </summary>
        /// <param name="name">Function name</param>
        /// <returns>The function</returns>
        public Tuple<Pen, bool, double[], Func<object, double>> this[string name]
        {
            set
            {
                dictionary[name] = value;
                PenSave ps = new PenSave();
                save[name] = ps;
                pens[name] = Transform(ps);
                SetPen(name, value.Item1);
                double[] d = value.Item3;
                SetScale(name, d[0], d[1]);
                converters[name] = value.Item4;
            }
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Sets series to active
        /// </summary>
        /// <param name="s">Series name</param>
        /// <param name="active">True if active and facle otherwise</param>
        void SetAcive(string s, bool active)
        {
            if (active & save.ContainsKey(s))
            {
                return;
            }
            if (!active & !save.ContainsKey(s))
            {
                return;
            }
            if (!active)
            {
                save.Remove(s);
                pens.Remove(s);
                return;
            }
            PenSave ps = new PenSave();
            ps.color = Color.White;
            PenValue pv = Transform(ps);
            save[s] = ps;
            pens[s] = pv;
        }

        /// <summary>
        /// Sets pen to series
        /// </summary>
        /// <param name="s">Series name</param>
        /// <param name="pen">Pen</param>
        void SetPen(string s, Pen pen)
        {
            if (!save.ContainsKey(s))
            {
                return;
            }
            save[s].color = pen.Color;
            pens[s].pen = pen;
        }

        /// <summary>
        /// Sets scale
        /// </summary>
        /// <param name="s">Series name</param>
        /// <param name="min">Minimal value</param>
        /// <param name="max">Maximal value</param>
        void SetScale(string s, double min, double max)
        {
            if (!save.ContainsKey(s))
            {
                return;
            }
            lock (this)
            {
                PenSave ps = save[s];
                ps.min = min;
                ps.max = max;
                pens[s] = Transform(ps);
                init();
            }
        }

        /// <summary>
        /// Creates bitmaps
        /// </summary>
        /// <param name="width">Width of bitmaps</param>
        /// <param name="height">Height of bitmaps</param>
        void CreateBitmaps(int width, int height)
        {
            invertedHeight = ((double)height);
            double x = (double)width / 3;
            if (x < 50)
            {
                bufferSize = 50;
            }
            else
            {
                bufferSize = (int)x;
            }
            if ((width < 1) | (height < 1))
            {
                return;
            }
            bmp = new Bitmap(width, height);
            Clear(bmp);
            double res = (double)width / (double)bufferSize;
            wNew = (int)res;
            if (wNew < 1)
            {
                wNew = 1;
            }
            bmpNew = new Bitmap(wNew, height);
            Clear(bmpNew);
            bmpOld = new Bitmap(width - wNew, height);
            Clear(bmpOld);
            oldRect.Height = height;
            oldRect.X = 0;
            oldRect.Y = 0;
            oldRect.Width = width - wNew;
            newRect.Height = height;
            newRect.X = oldRect.Width;
            newRect.Y = 0;
            newRect.Width = wNew;
            dRect.X = 0;
            dRect.Y = 0;
            dRect.Width = oldRect.Width;
            dRect.Height = height;
        }

        /// <summary>
        /// Creates bitmap for control
        /// </summary>
        /// <param name="control">The control</param>
        void CreateBitmaps(Control control)
        {
            CreateBitmaps(contol.Width, contol.Height);
        }

        void CopyBmp(Graphics g)
        {
            g.DrawImage(bmpOld, oldRect, 0, 0, bmpOld.Width, bmpOld.Height, GraphicsUnit.Pixel);
            g.DrawImage(bmpNew, newRect, 0, 0, bmpNew.Width, bmpNew.Height, GraphicsUnit.Pixel);
        }

        void DrawFullBmp()
        {
            Graphics go = Graphics.FromImage(bmpOld);
            go.DrawImage(bmp, dRect, wNew, 0, bmpOld.Width, bmpOld.Height, GraphicsUnit.Pixel);
            Graphics g = Graphics.FromImage(bmp);
            CopyBmp(g);
        }

        void Paint(object sender, PaintEventArgs arg)
        {
            arg.Graphics.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
        }

        void Resize(object s, EventArgs arg)
        {
            CreateBitmaps(contol);
        }

        void SaveOld()
        {
            Graphics g = Graphics.FromImage(bmpOld);
            g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
        }

        void Clear(Graphics g, int w, int h)
        {
            g.FillRectangle(fonBrush, 0, 0, w, h);
        }

        void Clear(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            Clear(g, bmp.Width, bmp.Height);
        }

        void AddExist(IDictionary<string, object> d, double time)
        {
            if (interval > 0)
            {
               double a = ((time - currentTime) / interval);
               double b = ((double)wNew / (double)bmp.Width);
               if (a < b)
               {
                   return;
               }
            }
            currentTime = time;
            Graphics g = Graphics.FromImage(bmpNew);
            Clear(g, bmpNew.Width, bmpNew.Height);
            foreach (string s in pens.Keys)
            {
                PenValue pv = pens[s];
                if (pv.pen == null)
                {
                    continue;
                }
                int x1 = pv.x;
                if (!converters.ContainsKey(s))
                {
                    continue;
                }
                Func<object, double> conv = converters[s];
                int y = Get(pv, conv(d[s]));
                g.DrawLine(pv.pen, 0, x1, wNew, y);
            }
            DrawControl();
        }

        void DrawControl()
        {
            Graphics g = Graphics.FromHwnd(contol.Handle);
            DrawFullBmp();
            g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
        }

        void AddNew(IDictionary<string, object> d, double time)
        {
            currentTime = time;
            exists.Clear();
            List<string> l = new List<string>(pens.Keys);
            foreach (string s in l)
            {
                if (!d.ContainsKey(s))
                {
                    pens.Remove(s);
                }
            }
            foreach (string s in d.Keys)
            {
                exists.Add(s);
                if (!pens.ContainsKey(s))
                {
                    continue;
                }
                PenValue pv = pens[s];
                object o = d[s];
               Func<object, double> conv = converters[s];
                Get(pv, conv(o));
            }
            add = AddExist;
        }

        int Get(PenValue pv, double d)
        {
            double x = (pv.max - d) * pv.scale * invertedHeight;
            int y = (int)x;
            pv.x = y;
            return y;
        }

        PenValue Transform(PenSave ps)
        {
            PenValue pv = new PenValue();
            pv.pen = new Pen(ps.color);
            pv.min = ps.min;
            pv.max = ps.max;
            pv.scale = 1 / (ps.max - ps.min);
            return pv;
        }

        void Add(string s, PenSave ps)
        {
            PenValue pv = Transform(ps);
            save[s] = ps;
            pens[s] = pv;
        }

        void init()
        {
            add = AddNew;
        }

 
     #endregion

        #region The Pen - value class
        
        class PenValue
        {
            internal Pen pen;
            internal double min;
            internal double max;
            internal double scale;
            internal int x;
        }

        #endregion

    }

    /// <summary>
    /// Saved pens
    /// </summary>
    [Serializable()]
    public class PenSave : ISerializable
    {
        internal Color color;
        internal double min;
        internal double max;


        #region Ctor

        internal PenSave()
        {
            color = Color.White;
            min = 0;
            max = 1;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected PenSave(SerializationInfo info, StreamingContext context)
        {
            color = (Color)info.GetValue("Color", typeof(Color));
            min = (double)info.GetValue("Min", typeof(double));
            max = (double)info.GetValue("Max", typeof(double));
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Color", color, typeof(Color));
            info.AddValue("Min", min, typeof(double));
            info.AddValue("Max", max, typeof(double));
        }

        #endregion
    }
}
