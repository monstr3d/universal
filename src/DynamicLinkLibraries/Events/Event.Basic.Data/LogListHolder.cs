using System;
using System.Runtime.Serialization;

namespace Event.Basic.Data
{
    /// <summary>
    /// Holder of log list
    /// </summary>
    [Serializable]
    public class LogHolder : Portable.LogHolder, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LogHolder()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected LogHolder(SerializationInfo info, StreamingContext context)
        {
            try
            {
                begin = info.GetUInt32("Begin");
                end = info.GetUInt32("End");
            }
            catch
            {

            }
            Url = info.GetString("Url");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Url", Url);
            info.AddValue("Begin", begin);
            info.AddValue("End", end);
        }

        #endregion

        static LogHolder()
        {

        }

    }
}
