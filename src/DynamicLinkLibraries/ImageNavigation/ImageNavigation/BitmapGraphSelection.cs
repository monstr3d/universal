using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.Serialization;
using System.Drawing;


using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Labels;

using GeneralLinearMethod;
using Regression;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

using BitmapConsumer;
using NamedTree;






namespace ImageNavigation
{
    /// <summary>
    /// Graph selection bitmap
    /// </summary>
    [Serializable()]
    public class BitmapGraphSelection : CategoryObject, ISerializable, IMeasurements, IBitmapConsumer, 
        IStructuredSelectionCollection, IPostSetArrow
    {

        #region Fields

        private Color color = Color.FromArgb(255, 0, 0, 0);

        private IBitmapProvider provider;

        private bool isSerialized = false;

        private ArrayStructuredSelection x;

        private ArrayStructuredSelection y;

        private double[] xx;

        private double[] yy;

        /// <summary>
        /// Add remove event
        /// </summary>
        event Action<IBitmapProvider, bool> addRemove =
            (IBitmapProvider p, bool b) => { };
 

        #endregion

        #region Ctor

        public BitmapGraphSelection()
        {

        }

        protected BitmapGraphSelection(SerializationInfo info, StreamingContext context)
        {
            color = (Color)info.GetValue("Color", typeof(Color));
            try
            {
                xx = info.GetValue("X", typeof(double[])) as double[];
                yy = info.GetValue("Y", typeof(double[])) as double[];
            }
            catch (Exception)
            {

            }
            isSerialized = true;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Color", color, typeof(Color));
            info.AddValue("X", x.ToDoubleArray(), typeof(double[]));
            info.AddValue("Y", y.ToDoubleArray(), typeof(double[]));
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return (x == null) ? 0 : 2; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return (n == 0) ? x : y; }
        }

        void IMeasurements.UpdateMeasurements()
        {
        }

        bool IMeasurements.IsUpdated
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
                CreateSelections();
            }
        }

        /// <summary>
        /// Removes a provider
        /// </summary>
        /// <param name="provider">The provider</param>
        void IBitmapConsumer.Remove(IBitmapProvider provider)
        {
            this.provider = null;
            x = null;
            y = null;
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



        #endregion

        #region IStructuredSelectionCollection Members

        int IStructuredSelectionCollection.Count
        {
            get { return (x == null) ? 0 : 2; }
        }

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => [x,y];

        IStructuredSelection IStructuredSelectionCollection.this[int i]
        {
            get { return (i == 0) ? x : y; }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            if (!isSerialized)
            {
                return;
            }
            if (xx != null)
            {
                x = new ArrayStructuredSelection(xx, "X", "X");
                y = new ArrayStructuredSelection(yy, "Y", "Y");
                xx = null;
                yy = null;
                isSerialized = false;
                return;
            }
            CreateSelections();
            isSerialized = false;
        }

        #endregion

        #region Specific Members

        private void CreateSelections()
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
            List<double[]> mea = new List<double[]>();
            int h = bmp.Height;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    if (c == color)
                    {
                        double[] a = new double[] { i, (h - j - 1) };
                        mea.Add(a);
                    }
                }
            }
            double[] xx = new double[mea.Count];
            double[] yy = new double[mea.Count];
            for (int i = 0; i < xx.Length; i++)
            {
                double[] a = mea[i];
                xx[i] = a[0];
                yy[i] = a[1];
            }
            x = new ArrayStructuredSelection(xx, "X", "X");
            y = new ArrayStructuredSelection(yy, "Y", "Y");
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
            throw new ErrorHandler.OwnException();

        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }

        #endregion

    }
}
