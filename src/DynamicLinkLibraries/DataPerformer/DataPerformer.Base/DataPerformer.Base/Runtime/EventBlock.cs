using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;

using Event.Interfaces;

namespace DataPerformer.Runtime
{
    /// <summary>
    /// Event block
    /// </summary>
    [Serializable()]
    public class EventBlock : Portable.Runtime.EventBlock, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventBlock()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected EventBlock(SerializationInfo info, StreamingContext context)
        {
            names = info.GetValue("Names", typeof(string[])) as string[];
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
            info.AddValue("Names", names, typeof(string[]));
        }

        #endregion

    }
}