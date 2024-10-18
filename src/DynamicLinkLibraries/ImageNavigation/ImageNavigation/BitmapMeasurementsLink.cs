using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;


using CategoryTheory;
using BitmapConsumer;

namespace ImageNavigation
{
    [Serializable()]
    public class BitmapMeasurementsLink : ICategoryArrow, IDisposable, ISerializable
    {
        #region Fields
        private object obj;
        private int a = 0;

        private BitmapSelection source;

        private IBitmapProvider target;

        #endregion

        #region Constructors
        public BitmapMeasurementsLink()
        {
        }

        public BitmapMeasurementsLink(SerializationInfo info, StreamingContext context)
        {
            info.GetValue("A", typeof(int));
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("A", a);
        }

        #endregion

        #region ICategoryArrow Members

        public ICategoryObject Source
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                if (!(value is BitmapSelection))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                source = value as BitmapSelection;
            }
        }

        public ICategoryObject Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                if (!(value is IBitmapProvider))
                {
                    CategoryException.ThrowIllegalTargetException();
                }
                target = value as IBitmapProvider;
                source.BitmapProvider = target;
            }
        }

        public bool IsMonomorphism
        {
            get
            {
                return false;
            }
        }

        public bool IsEpimorphism
        {
            get
            {
                return false;
            }
        }

        public bool IsIsomorphism
        {
            get
            {
                return false;
            }
        }


        public ICategoryArrow Compose(ICategory category, ICategoryArrow next)
        {
            return null;
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

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            source.BitmapProvider = null;
        }

        #endregion

    }
}
