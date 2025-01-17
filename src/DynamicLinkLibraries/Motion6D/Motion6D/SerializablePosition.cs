using System;
using System.Runtime.Serialization;


using Diagram.UI;
using ErrorHandler;

namespace Motion6D
{
    /// <summary>
    /// Serializable position
    /// </summary>
    [Serializable()]
    public class SerializablePosition : Portable.SerializablePosition, ISerializable
    {

        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        protected object obj;

        private object properties;

        private byte[] bytes;

        /// <summary>
        /// Allows code creation
        /// </summary>
        protected bool allowCodeCreation = false;


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

        #region IProperties Members

        /// <summary>
        /// Properties
        /// </summary>
        public override object Properties
        {
            get => PureDesktopPeer.GetProperties(properties, bytes);
            set => base.Properties = value;
        }

        #endregion

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
            }
        }

    }
}
