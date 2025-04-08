using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using BitmapConsumer;
using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using Diagram.UI;
using Diagram.UI.Aliases;
using NamedTree;

namespace ImageTransformations
{
    [Serializable()]
    public class MapTransformation : CategoryObject, ISerializable, IDataConsumer, 
        IBitmapConsumer, IPostSetArrow, IBitmapProvider, IDisposable
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        private int[,][] trans;

        private int width = 600;

        private int height = 600;

        private string[] instr = new string[2];

        private string[] outstr = new string[2];

        private List<IMeasurements> measurements = new List<IMeasurements>();

        private IMeasurement[] measures = new IMeasurement[2];

        private AliasName[] aln = new AliasName[2];

        private Bitmap bmp;

        private Bitmap pBmp;

        private IBitmapProvider provider;
        /// <summary>
        /// Add remove event
        /// </summary>
        event Action<IBitmapProvider, bool> addRemove =
            (IBitmapProvider p, bool b) => { };
 

        #endregion

        #region Ctor

        public MapTransformation()
        {
            createBitmap();
        }

        protected MapTransformation(SerializationInfo info, StreamingContext context)
        {
            instr = info.GetValue("Instr", typeof(string[])) as string[];
            outstr = info.GetValue("Outstr", typeof(string[])) as string[];
            width = (int)info.GetValue("Width", typeof(int));
            height = (int)info.GetValue("Height", typeof(int));
            createBitmap();
        }

        ~MapTransformation()
        {
            IDisposable d = this;
            d.Dispose();
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Instr", instr, typeof(string[]));
            info.AddValue("Outstr", outstr, typeof(string[]));
            info.AddValue("Width", width, typeof(int));
            info.AddValue("Height", height, typeof(int));
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

        void IDataConsumer.UpdateChildrenData()
        {
            foreach (IMeasurements m in measurements)
            {
                m.UpdateMeasurements();
            }
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurements[n]; }
        }

        void IDataConsumer.Reset()
        {
            foreach (IMeasurements m in measurements)
            {
                m.IsUpdated = false;
                if (m is IDataConsumer)
                {
                    IDataConsumer c = m as IDataConsumer;
                    c.Reset();
                }
            }
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
            if (provider != null)
            {
                if (provider is IUpdatableObject)
                {
                    IUpdatableObject up = provider as IUpdatableObject;
                    if (up.Update != null)
                    {
                        up.Update();
                    }
                }
                pBmp = provider.Bitmap;
                if (pBmp != null)
                {
                    draw();
                }
            }
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
            if (provider != null & provider != null)
            {
                throw new Exception("Provider already exists");
            }
            this.provider = provider;
            if (provider == null)
            {
                pBmp = null;
                return;
            }
            pBmp = provider.Bitmap;
            if (pBmp != null)
            {
                createTransition();
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

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            createMeasurements();
        }

        #endregion

        #region IBitmapProvider Members

        Bitmap IBitmapProvider.Bitmap
        {
            get { return bmp; }
        }

        #endregion

        #region IRemovableObject Members

        void IDisposable.Dispose()
        {
            if (bmp is IDisposable d)
            {
                d.Dispose();
                bmp = null;
            }
        }

        #endregion

        #region Specific Members



        public string[] Input
        {
            get
            {
                return instr;
            }
        }

        public string[] Output
        {
            get
            {
                return outstr;
            }
        }

        public void Set(string[] instr, string[] outstr)
        {
            foreach (string s in instr)
            {
                if (s == null)
                {
                    return;
                }
            }
            foreach (string s in outstr)
            {
                if (s == null)
                {
                    return;
                }
            }
            this.instr = instr;
            this.outstr = outstr;
            createMeasurements();
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (width == value)
                {
                    return;
                }
                width = value;
                createBitmap();
                createTransition();
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (height == value)
                {
                    return;
                }
                height = value;
                createBitmap();
                createTransition();
            }
        }

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;

        public void Set(int width, int height)
        {
            this.width = width;
            this.height = height;
            createBitmap();
            createTransition();
        }



        private void createBitmap()
        {
            bmp = new Bitmap(width, height);
        }

        private void createMeasurements()
        {
            foreach (string s in instr)
            {
                if (s == null)
                {
                    return;
                }
            }
            foreach (string s in outstr)
            {
                if (s == null)
                {
                    return;
                }
            }
            for (int i = 0; i < instr.Length; i++)
            {
                AliasName a = this.FindAliasName(instr[i], false);
                aln[i] = a;
            }
            for (int i = 0; i < outstr.Length; i++)
            {
                measures[i] = this.FindMeasurement(outstr[i], true);
            }
            createTransition();
        }

        private void createTransition()
        {
            if (provider == null)
            {
                return;
            }
            Bitmap b = provider.Bitmap;
            if (b == null)
            {
                return;
            }
            foreach (IMeasurement m in measures)
            {
                if (m == null)
                {
                    return;
                }
            }
            foreach (AliasName an in aln)
            {
                if (an == null)
                {
                    return;
                }
            }
            double[] div = new double[] { 1.0 / (double)bmp.Width, 1.0 / (double)bmp.Height };
            double[] mul = new double[] { (double)b.Width, (double)b.Height };
            IDataConsumer c = this;
            trans = new int[bmp.Width, bmp.Height][];
            for (int i = 0; i < bmp.Width; i++)
            {
                double x = i * div[0];
                for (int j = 0; j < bmp.Height; j++)
                {
                    double y = j * div[1];
                    aln[0].SetValue(x);
                    aln[1].SetValue(y);
                    c.Reset();
                    c.UpdateChildrenData();
                    double xd = (double)measures[0].Parameter();
                    if (xd < 0 | xd > 1)
                    {
                        continue;
                    }
                    double yd = (double)measures[1].Parameter();
                    if (yd < 0 | yd > 1)
                    {
                        continue;
                    }
                    xd *= mul[0];
                    yd *= mul[1];
                    int[] n = new int[] { (int)xd, (int)yd };
                    trans[i, j] = n;
                }
            }
        }


        private void draw()
        {
            if (pBmp == null)
            {
                return;
            }
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int[] n = trans[i, j];
                    if (n == null)
                    {
                        continue;
                    }
                    if (n[0] >= pBmp.Width | n[0] < 0
                        | n[1] >= pBmp.Height | n[1] < 0)
                    {
                        continue;
                    }
                    Color c = pBmp.GetPixel(n[0], n[1]);
                    bmp.SetPixel(i, j, c);
                }
            }
        }


        #endregion

    }
}