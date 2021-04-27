using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Motion6D.Interfaces;

namespace InterfaceOpenGL
{
    [Serializable()]
    public class Reper : CategoryObject, ISerializable, Motion6D.Interfaces.IVisible, Motion6D.Interfaces.ILength,
        IRemovableObject
    {

        #region Fields

        IPosition position;
 
        private double length = 1;

        private OpenGL_Library.ReperGL reper = new OpenGL_Library.ReperGL();

        #endregion

        #region Ctor

        public Reper()
        {
            setLength();
        }

        protected Reper(SerializationInfo info, StreamingContext context)
        {
            length = (double)info.GetValue("Length", typeof(double));
            setLength();
        }

        ~Reper()
        {
            RemoveObject();
        }


        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Length", length, typeof(double));
        }

        #endregion

        #region ILength Members

        double Motion6D.Interfaces.ILength.Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
                setLength();
            }
        }

        #endregion

        #region IRemovableObject Members

        public void RemoveObject()
        {
            if (reper != null)
            {
                reper.Dispose();
                reper = null;
            }
        }

        #endregion

        #region IPositionObject Members

        IPosition IPositionObject.Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        #endregion
 


        #region Specific Members

        internal OpenGL_Library.ReperGL Peer
        {
            get
            {
                return reper;
            }
        }

        private void setLength()
        {
            reper.SetLength(length);
        }

        #endregion

    }
}
