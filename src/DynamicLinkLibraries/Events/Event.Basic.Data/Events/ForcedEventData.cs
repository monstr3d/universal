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
            initial = info.Deserialize<object[]>("Initial");
            data = new object[initial.Length];
            for (int i = 0; i < initial.Length; i++)
            {
                if (initial[i] == null)
                {
                    initial[i] = types[i].Item2.GetDefaultValue();
                }
            }
            Array.Copy(initial, data, data.Length);
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<List<Tuple<string, object>>>("Types", types);
            info.Serialize<object[]>("Initial", initial);
        }

        #endregion

   }
}
