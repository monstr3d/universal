using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


using CategoryTheory;

using Diagram.UI;

using SerializationInterface;


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
        /// <param name="aggregateType">Type of aggregate</param>
        public AggregableWrapper(string aggregateType) : base(aggregateType)
        {

        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="aggregate">Prototype</param>
        public AggregableWrapper(IAggregableMechanicalObject aggregate) : base(aggregate)
        {

        }

        /// <summary>
        /// Deserialization construcror
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected AggregableWrapper(SerializationInfo info, StreamingContext context)
        {
            aggregate = info.Deserialize<IAggregableMechanicalObject>("Aggregate");
            Prepare();
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize("Aggregate", aggregate);
        }

        #endregion

    }
}
