using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;

using SerializationInterface;

using DataPerformer.Interfaces;
using ErrorHandler;

namespace DataPerformer.Advanced.Accumulators
{
    /// <summary>
    /// Base class for all accumulatotrs
    /// </summary>
    public abstract class AccumulatorBase : Portable.Advanced.Accumulators.AccumulatorBase,
        ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected AccumulatorBase() : base()
        {
            children[0] = new Runtime.EventBlock();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected AccumulatorBase(SerializationInfo info, StreamingContext context)
            : this()
        {
            try
            {
                isSerialized = true;
                Degree = (int)info.GetValue("Degree", typeof(int));
                children[0] = info.Deserialize<Runtime.EventBlock>("EventBlock");
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }


        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Degree", degree, typeof(int));
            info.Serialize("EventBlock", children[0] as Runtime.EventBlock);
        }

        #endregion

    }
}