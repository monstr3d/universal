using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Diagram.UI
{
    /// <summary>
    /// Holder of bytes
    /// </summary>
    [Serializable()]
    public class ByteHolder : ISerializable, IDisposable
    {
        #region Fields
       
        byte[] bytes = new byte[0];

        PureDesktopPeer desktop;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ByteHolder()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ByteHolder(SerializationInfo info, StreamingContext context)
        {
            bytes = info.GetValue("Bytes", typeof(byte[])) as byte[];
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bytes", bytes, typeof(byte[]));
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (desktop != null)
            {
                desktop.Dispose();
            }
        }

        #endregion


        #region Fields

        /// <summary>
        /// Bytes
        /// </summary>
        public byte[] Bytes
        {
            get
            {
                return bytes;
            }
            set
            {
                bytes = value;
                desktop = null;
            }
        }

        /// <summary>
        /// Desktop
        /// </summary>
        public PureDesktopPeer Desktop
        {
            get
            {
                if (desktop == null)
                {
                    desktop = new PureDesktopPeer();
                    if (bytes.Length > 0)
                    {
                        desktop.Load(bytes, true);
                    }
                }
                return desktop;
            }
            set
            {
                desktop = null;
                MemoryStream ms = new MemoryStream();
                value.Save(ms);
                bytes = ms.GetBuffer();
            }
        }

        #endregion

    }
}
