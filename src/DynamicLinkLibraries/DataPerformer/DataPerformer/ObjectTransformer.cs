using System;
using System.Collections.Generic;
using System.Runtime.Serialization;




namespace DataPerformer
{
    /// <summary>
    /// Transformer of objects
    /// </summary>
    [Serializable()]
    public class ObjectTransformer : Portable.ObjectTransformer, ISerializable
    {

        #region Constructros

        /// <summary>
        /// Default constructor
        /// </summary>
        public ObjectTransformer()
        {
         
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public ObjectTransformer(SerializationInfo info, StreamingContext context)
            : base()
        {
            isSerialized = true;
            links = info.GetValue("Links", typeof(Dictionary<string, string>))
                as Dictionary<string, string>;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Links", links, typeof(Dictionary<string, string>));
        }

        #endregion

 
    }
}
