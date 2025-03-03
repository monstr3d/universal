using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;

using CategoryTheory;
using DataPerformer;
using Diagram.UI;

using BitmapConsumer;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using ErrorHandler;

namespace ImageTransformations
{
    [Serializable()]
    public class DataPicture : CategoryObject, ISerializable, IPostSetArrow, 
        IDataConsumer, IBitmapDrawing
    {

        #region Fields
        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        List<IMeasurements> measurementsData = new List<IMeasurements>();
        List<string> measures = new List<string>();
        private List<string> aliasNames = new List<string>();
        private bool proportional = false;
        private bool equals = false;
        private bool colored;
        private bool rainBow = false;
        private double max;
        private double min;

        private double[] amax = new double[3];

        private double[] amin = new double[3];

        private int[] col = new int[3];

        private double[] rainBowC = new double[3];

        private DataPerformerOperations op = new DataPerformerOperations();


        object[] oin = new object[2];
        object[] oout = new object[1];
        object[] aoout = new object[3];

        #endregion

        #region Ctor

        public DataPicture()
        {
        }

        protected DataPicture(SerializationInfo info, StreamingContext context)
        {
            try
            {
                measures = info.GetValue("Measures", typeof(List<string>)) as List<string>;
                aliasNames = info.GetValue("AliasNames", typeof(List<string>)) as List<string>;
                proportional = (bool)info.GetValue("Proportional", typeof(bool));
                equals = (bool)info.GetValue("Equals", typeof(bool));
                colored = (bool)info.GetValue("Colored", typeof(bool));
                rainBow = (bool)info.GetValue("RainBow", typeof(bool));

            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }

        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Measures", measures, typeof(List<string>));
            info.AddValue("AliasNames", aliasNames, typeof(List<string>));
            info.AddValue("Proportional", proportional, typeof(bool));
            info.AddValue("Equals", equals, typeof(bool));
            info.AddValue("Colored", colored, typeof(bool));
            info.AddValue("RainBow", rainBow, typeof(bool));

        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            op.Set(this, measures, aliasNames);
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            measurementsData.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            measurementsData.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            this.UpdateChildrenData();
        }

        int IDataConsumer.Count
        {
            get { return measurementsData.Count; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurementsData[n]; }
        }

        void IDataConsumer.Reset()
        {
            this.ResetAll();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        #endregion

        #region IBitmapDrawing Members

        void IBitmapDrawing.Draw(Bitmap bmp)
        {
            if (bmp == null)
            {
                return;
            }
            int w = bmp.Width;
            int h = bmp.Height;
            if (equals)
            {
                if (h > w)
                {
                    h = w;
                }
                else
                {
                    w = h;
                }
            }
            double dw = (double)w;
            double dh = (double)h;
            min = 0;
            max = 1;
            try
            {
                if (proportional)
                {
                    if (colored)
                    {
                        defineColorBounds(w, h);
                    }
                    else
                    {
                        defineBounds(w, h);
                    }
                }
                if (colored)
                {
                    paintColored(bmp, w, h);
                }
                else
                {
                    if (rainBow)
                    {
                        paintRainBow(bmp, w, h);
                    }
                    else
                    {
                        paintGrayScale(bmp, w, h);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }

        #endregion

        #region Specific Members

        public bool RainBow
        {
            get
            {
                return rainBow;
            }
            set
            {
                rainBow = value;
            }
        }

        public void Set(List<string> measures, List<string> aliases)
        {
            if (aliases.Count != 2)
            {
                throw new Exception("Ill");
            }
            if (measures.Count < 1)
            {
                throw new Exception("Ill");
            }
            if (colored & measures.Count < 3)
            {
                throw new Exception("Ill");
            }
            this.measures = measures;
            aliasNames = aliases;
            IPostSetArrow p = this;
            p.PostSetArrow();
        }

        public List<string> Aliases
        {
            get
            {
                return aliasNames;
            }
        }


        public List<string> Measures
        {
            get
            {
                return measures;
            }
        }

        public List<string> AllAliases
        {
            get
            {
                Double a = 0;
                return this.GetAliases(a);
            }
        }

        public List<string> AllMeasures
        {
            get
            {
                Double a = 0;
                return this.GetAllMeasurements(a);
            }
        }

        public bool Proportional
        {
            get
            {
                return proportional;
            }
            set
            {
                proportional = value;
            }
        }
        
        public bool EqualSize
        {
            get
            {
                return equals;
            }
            set
            {
                equals = value;
            }
        }

        public bool Colored
        {
            get
            {
                return colored;
            }
            set
            {
                colored = value;
            }
        }

        private void rainBowCol(double a, double[] v)
        {
            double x = a;// + 0.5 * a * a;
            if (true)
            {
                v[0] = 0.7;
                v[1] = 0.7;
                v[2] = 0.7;
                //v[3] = 1 - x;
            }
            //v[3] = 1;
            int k = (int)(x * 5);
            if (k < 0)
            {
                k = 0;
            }
            if (k > 4)
            {
                k = 4;
            }
            double y = 5 * (x - (double)(k) / 5.0);
            if (k == 0)
            {
                v[0] = 1;
                v[1] = y;
                v[2] = 0;
            }
            else if (k == 1)
            {
                v[0] = 1 - y;
                v[1] = 1;
                v[2] = 0;
            }
            else if (k == 2)
            {
                v[0] = 0;
                v[1] = 1;
                v[2] = y;
            }
            else if (k == 3)
            {
                v[0] = 0;
                v[1] = 1 - y;
                v[2] = 1;
            }
            else
            {
                v[0] = y;
                v[1] = 0;
                v[2] = 1;
            }
        }




        private void defineBounds(int w, int h)
        {
            double dw = (double)w;
            double dh = (double)h;

            for (int i = 0; i < w; i++)
            {
                double di = (double)i / dw;
                oin[0] = di;
                for (int j = 0; j < h; j++)
                {
                    double dj = (double)j / dh;
                    oin[1] = dj;
                    op.Transform(oin, oout);
                    double x = (double)oout[0];
                    if (i == 0 & j == 0)
                    {
                        min = x;
                        max = x;
                        continue;
                    }
                    if (x > max)
                    {
                        max = x;
                        continue;
                    }
                    if (x < min)
                    {
                        min = x;
                        continue;
                    }
                }
            }

        }
        private void defineColorBounds(int w, int h)
        {
            double dw = (double)w;
            double dh = (double)h;

            for (int i = 0; i < w; i++)
            {
                double di = (double)i / dw;
                oin[0] = di;
                for (int j = 0; j < h; j++)
                {
                    double dj = (double)j / dh;
                    oin[1] = dj;
                    op.Transform(oin, aoout);
                    for (int k = 0; k < 3; k++)
                    {
                        double x = (double)aoout[k];
                        if (i == 0 & j == 0)
                        {
                            amin[k] = x;
                            amax[k] = x;
                            continue;
                        }
                        if (x > amax[k])
                        {
                            amax[k] = x;
                            continue;
                        }
                        if (x < amin[k])
                        {
                            amin[k] = x;
                            continue;
                        }
                    }
                }

            }
        }

        void paintGrayScale(Bitmap bmp, int w, int h)
        {
            double dw = (double)w;
            double dh = (double)h;
            for (int i = 0; i < w; i++)
            {
                double di = (double)i / dw;
                oin[0] = di;
                for (int j = 0; j < h; j++)
                {
                    double dj = (double)j / dh;
                    oin[1] = dj;
                    op.Transform(oin, oout);
                    double x = ((double)oout[0] - min) / (max - min);
                    int c = (int)(x * 255);
                    Color col = Color.FromArgb(255, c, c, c);
                    bmp.SetPixel(i, j, col);
                }
            }

        }

        void paintColored(Bitmap bmp, int w, int h)
        {
            double dw = (double)w;
            double dh = (double)h;
            for (int i = 0; i < w; i++)
            {
                double di = (double)i / dw;
                oin[0] = di;
                for (int j = 0; j < h; j++)
                {
                    double dj = (double)j / dh;
                    oin[1] = dj;
                    op.Transform(oin, aoout);
                    for (int k = 0; k < 3; k++)
                    {
                        double x = ((double)aoout[k] - min) / (max - min);
                        col[k] = (int)(x * 255);
                    }
                    Color color = Color.FromArgb(255, col[0], col[1], col[2]);
                    bmp.SetPixel(i, j, color);
                }
            }

        }
        void paintRainBow(Bitmap bmp, int w, int h)
        {
            
            double dw = (double)w;
            double dh = (double)h;
            for (int i = 0; i < w; i++)
            {
                double di = (double)i / dw;
                oin[0] = di;
                for (int j = 0; j < h; j++)
                {
                    double dj = (double)j / dh;
                    oin[1] = dj;
                    op.Transform(oin, oout);
                    double x = 1 - ((double)oout[0] - min) / (max - min);
                    rainBowCol(x, rainBowC);
                    for (int k = 0; k < rainBowC.Length; ++k)
                    {
                        col[k] = (int)(rainBowC[k] * 255);
                    }
                    Color c = Color.FromArgb(255, col[0], col[1], col[2]);
                    bmp.SetPixel(i, j, c);
                }
            }
        }


        #endregion
    }
}
