using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;
using Motion6D.Interfaces;
using Motion6D.Portable;

namespace Motion6D
{
    /// <summary>
    /// Serializable position
    /// </summary>
    [Serializable()]
    public class SerializablePosition : Position, ISerializable, ICategoryObject, IPostSetArrow, IProperties
    {

        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        protected object obj;

        private object properties;

        private byte[] bytes;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SerializablePosition()
            : base()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SerializablePosition(SerializationInfo info, StreamingContext context)
        {
            Parameters = info.GetValue("Parameters", typeof(object));
            try
            {
                bytes = PureDesktopPeer.LoadProperties(info);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Parameters", Parameters, typeof(object));
            PureDesktopPeer.SaveProperties(properties, bytes, info);
        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
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

        #region Overriden Members

        /// <summary>
        /// Overriden to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ObjectArrowName() + base.ToString() + ")";
        }

        /// <summary>
        /// Position parameters
        /// </summary>
        public override object Parameters
        {
            get
            {
                return base.Parameters;
            }
            set
            {
                if (!(value is ISerializable))
                {
                    throw new Exception("Object should be serialisable");
                }
                base.Parameters = value;
                SetObject();
                if (Parameters is IPositionObject)
                {
                    IPositionObject po = Parameters as IPositionObject;
                    po.Position = this;
                }
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            object o = Parameters;
            SetObject();
  /*          if (o != null)
            {
                if (o is IPostSetArrow)
                {
                    IPostSetArrow p = o as IPostSetArrow;
                    p.PostSetArrow();
                }
            }*/
        }

        #endregion

        #region IProperties Members

        object IProperties.Properties
        {
            get
            {
                return PureDesktopPeer.GetProperties(properties, bytes);
            }
            set
            {
                properties = value;
            }
        }

        #endregion

        #region Specific Members

        void SetObject()
        {
            object o = Parameters;
            if (o == null)
            {
                return;
            }
            if (o is IPositionObject)
            {
                IPositionObject po = o as IPositionObject;
                po.Position = this;
            }
        }

        #endregion
    }
}
