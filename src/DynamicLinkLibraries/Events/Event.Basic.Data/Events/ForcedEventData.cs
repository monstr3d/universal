using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BaseTypes;

using SerializationInterface;

namespace Event.Basic.Data.Events
{
    /// <summary>
    /// Forced event data
    /// </summary>
    [Serializable()]
    public class ForcedEventData : Portable.Events.ForcedEventData, ISerializable
    {
 
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ForcedEventData()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ForcedEventData(SerializationInfo info, StreamingContext context)
        {
            Types = info.Deserialize<List<Tuple<string, object>>>("Types");
            Initial = info.Deserialize<object[]>("Initial");
            for (int i = 0; i < Initial.Length; i++)
            {
                if (Initial[i] == null)
                {
                    Initial[i] = types[i].Item2.GetDefaultValue();
                }
            }
            Array.Copy(Initial, Data, Data.Length);
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<List<Tuple<string, object>>>("Types", types);
            info.Serialize<object[]>("Initial", Initial);
        }

        #endregion

   }
}
