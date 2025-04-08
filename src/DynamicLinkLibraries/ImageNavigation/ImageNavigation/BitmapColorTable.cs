using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Drawing;


using CategoryTheory;


using DataPerformer.Portable.Measurements;
using DataPerformer.Portable;
using DataPerformer.Interfaces;

using BitmapConsumer;
using NamedTree;


namespace ImageNavigation
{
    /// <summary>
    /// Color table for bitmap
    /// </summary>
    [Serializable()]
    public class BitmapColorTable : CategoryObject, ISerializable, IMeasurements, IBitmapConsumer, 
        IDataConsumer, IPostSetArrow
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        /// <summary>
        /// Add remove event
        /// </summary>
        event Action<IBitmapProvider, bool> addRemove =
            (IBitmapProvider p, bool b) => { };
        
 
        double[,][] results;

        string x;

        string y;

        List<IMeasurements> measurements = new List<IMeasurements>();

        private readonly string[] colors = new string[] { "Red", "Green", "Blue" };

        IMeasurement[] meas = new IMeasurement[3];

        double cX = 0;

        double cY = 0;

        const double coeff = 1.0 / 255;

        IMeasurement[] input = new IMeasurement[2];

        IBitmapProvider provider;

        bool isUpdated;

        bool isSerialized = false;

        Color current = Color.Black;



        #endregion

        #region Ctor

        public BitmapColorTable()
        {
            Func<object>[] ff = new Func<object>[]
            {
                ()=> { return coeff * (double)current.R;},
              ()=> { return coeff * (double)current.G;},
              ()=> { return coeff * (double)current.B;}
            };
            for (int i = 0; i < 3; i++)
            {
                int[] k = new int[] { i };
                //Func<object> f = () => { return GetValue(k[0]); };
                meas[i] = new Measurement(ff[i], colors[i], this);
            }
        }

        protected BitmapColorTable(SerializationInfo info, StreamingContext context)
            : this()
        {
            x = info.GetString("X");
            y = info.GetString("Y");
            isSerialized = true;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", x);
            info.AddValue("Y", y);
        }

        #endregion

        #region IDataConsumer Members

        void IChildren<IMeasurements>.AddChild(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        public void UpdateChildrenData()
        {
            measurements.UpdateMeasurements(false);
        }

        public int Count
        {
            get { return measurements.Count; }
        }

        public IMeasurements this[int number]
        {
            get { return measurements[number]; }
        }

        public void Reset()
        {
            this.FullReset();
        }


        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        #endregion

        #region IBitmapConsumer Members

        void IBitmapConsumer.Process()
        {
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
            if (!isSerialized)
            {
                CreateTable();
            }
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

        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return 3; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return meas[number]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            this.UpdateChildrenData();
            cX = (double)input[0].Parameter();
            cY = (double)input[1].Parameter();
            current = provider.Bitmap.GetPixel((int)cX, (int)cY);
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            CreateInput();
            CreateTable();
            isSerialized = false;
        }

        #endregion

        #region Own Members

        public string X
        {
            get
            {
                return x;
            }
        }

        public string Y
        {
            get
            {
                return y;
            }
        }

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => meas;

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;

        public void Set(string x, string y)
        {
            this.x = x;
            this.y = y;
            CreateInput();
        }

        void CreateInput()
        {
            if (x.Length == 0 | y.Length == 0)
            {
                return;
            }
            input[0] = this.FindMeasurement(x, false);
            input[1] = this.FindMeasurement(y, false);
        }

        void CreateTable()
        {
            if (provider == null)
            {
                return;
            }
            Bitmap bmp = provider.Bitmap;
            if (bmp == null)
            {
                return;
            }
            int w = bmp.Width;
            int h = bmp.Height;
            results = new double[w, h][];
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    results[x, y] = new double[] { (double)c.R / 255, (double)c.G / 255, (double)c.B / 255 };

                }
            }

        }

        double GetValue(double x, double y, int i)
        {
            int xx = (int)Math.Floor(x);
            int yy = (int)Math.Floor(y);
            return results[xx, yy][i];
        }

        double GetValue(int i)
        {
            return GetValue(cX, cY, i);
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
            throw new NotImplementedException();
        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}