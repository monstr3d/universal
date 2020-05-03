using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


using CategoryTheory;
using Diagram.UI;


using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Wrapper of mechanical aggregate
    /// </summary>
    [Serializable()]
    public class AggregableWrapper : Portable.AggregableWrapper, ISerializable
    {
 
        #region Ctor

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="aggregate">Prototype</param>
        public AggregableWrapper(IAggregableMechanicalObject aggregate)
        {
            if (!(aggregate is ISerializable) &
                ((aggregate as CategoryTheory.IAssociatedObject).GetObject<IPropertiesEditor>() == null))
            {
                throw new Exception();
            }
            this.aggregate = aggregate;
            Prepare();
        }

        /// <summary>
        /// Deserialization construcror
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected AggregableWrapper(SerializationInfo info, StreamingContext context)
        {
            byte[] b = info.GetValue("Buffer", typeof(byte[])) as byte[];
            MemoryStream stream = new MemoryStream(b);
            BinaryFormatter bf = new BinaryFormatter();
            aggregate = bf.Deserialize(stream) as IAggregableMechanicalObject;
            Prepare();
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, aggregate);
            byte[] b = stream.GetBuffer();
            info.AddValue("Buffer", b, typeof(byte[]));
        }

        #endregion

    }
}
