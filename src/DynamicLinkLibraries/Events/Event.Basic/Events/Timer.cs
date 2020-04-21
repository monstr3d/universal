using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using CategoryTheory;

using DataPerformer.Interfaces;

using Event.Interfaces;

namespace Event.Basic.Events
{
    /// <summary>
    /// Timer
    /// </summary>
    [Serializable()]
    public class Timer : Portable.Events.Timer, ISerializable
    {
 
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Timer() : base()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Timer(SerializationInfo info, StreamingContext context)
            : this()
        {
            (this as ITimerEvent).TimeSpan = (TimeSpan)info.GetValue("TimeSpan", typeof(TimeSpan));
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TimeSpan", timeSpan, typeof(TimeSpan));
        }

        #endregion

    }
}
