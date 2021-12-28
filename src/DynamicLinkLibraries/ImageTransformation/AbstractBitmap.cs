using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;

using DataPerformer.Interfaces;

using BitmapConsumer;
using System.Drawing;


namespace ImageTransformations
{
    /// <summary>
    /// Abstract bitmap
    /// </summary>
    public abstract class AbstractBitmap : CategoryObject, IBitmapProvider,
        ISerializable, IMeasurements, IRemovableObject, IPostSetArrow
    {
        #region Fields
        /// <summary>
        /// Bitmap
        /// </summary>
        protected Bitmap bitmap;

        protected static readonly string[] names = new string[]{"Width", "Height"};

        /// <summary>
        /// Comments
        /// </summary>
        protected ArrayList comments = new ArrayList();

        protected IMeasurement[] bitmapmeas = new IMeasurement[0];

        #endregion

        #region Constructors


        #endregion

        #region ISerializable Members

        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
 
        #endregion

        #region IBitmapProvider Members

        /// <summary>
        /// Bitmap
        /// </summary>
        Bitmap IBitmapProvider.Bitmap
        {
            get
            {
                return bitmap;
            }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return bitmapmeas.Length; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return bitmapmeas[n]; }
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

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            CreateMeasurements();
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Image
        /// </summary>
        public abstract Image Image
        {
            get;
            set;
        }

        /// <summary>
        /// Sets bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        public void SetBitmap(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            CreateMeasurements();
        }

        protected virtual void CreateMeasurements(int width, int height)
        {
            bitmapmeas = new IMeasurement[] { new ConstMeasurement(width, names[0]),
                new ConstMeasurement(height, names[1]),
                new Measurment(this)};
        }


        private void CreateMeasurements()
        {
            if (bitmap == null)
            {
                CreateMeasurements(0, 0);
            }
            else
            {
                CreateMeasurements(bitmap.Width, bitmap.Height);
            }
        }

        #endregion

        class Measurment : IMeasurement
        {
            AbstractBitmap bmp;

            const string Bitmap = "Bitmap";

            static readonly Type type = typeof(Bitmap);


            internal Measurment(AbstractBitmap bmp)
            {
                this.bmp = bmp;

            }


            string IMeasurement.Name
            {
                get
                {
                    return Bitmap;
                }
            }

            Func<object> IMeasurement.Parameter
            {
                get
                {
                    return Get;
                }
            }

            object IMeasurement.Type
            {
                get
                {
                    return type;
                }
            }

            object Get()
            {
                return bmp.Image;
            }
        }

    }
}
