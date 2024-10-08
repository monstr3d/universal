using System;
using System.Runtime.Serialization;


namespace Regression
{
    /// <summary>
    /// Combined selection
    /// </summary>
    [Serializable()]
    public class CombinedSelection : Portable.CombinedSelection, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CombinedSelection()
        {

        }

        /// <summary>
        /// Deserializable constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected CombinedSelection(SerializationInfo info, StreamingContext context)
        {
            num = info.GetValue("Num", num.GetType()) as int[,];
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Num", num, num.GetType());
        }

        #endregion

    }
}
