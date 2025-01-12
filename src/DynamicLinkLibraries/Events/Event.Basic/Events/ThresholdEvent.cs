using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Event.Basic.Events
{
    /// <summary>
    /// Threshold Event
    /// </summary>
    [Serializable]
    public class ThresholdEvent : Portable.Events.ThresholdEvent, ISerializable
    {
        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public ThresholdEvent() : base()
        {
        }

        private ThresholdEvent(SerializationInfo info, StreamingContext context) : this()
        {
            Measurement = info.GetString("Measurement");
            Type = info.GetValue("Type", typeof(object));
            Decrease = info.GetBoolean("Decrease");
        }

        #endregion

        #region ISerializable Members
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Measurement", Measurement);
            info.AddValue("Type", Type, typeof(object));
            info.AddValue("Decrease", Decrease);
        }

        #endregion
    }
}
