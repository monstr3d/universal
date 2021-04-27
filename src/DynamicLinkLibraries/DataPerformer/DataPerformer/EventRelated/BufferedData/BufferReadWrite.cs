using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;

namespace DataPerformer.EventRelated.BufferedData
{
    /// <summary>
    /// Buffer read and write
    /// </summary>
    [Serializable]
    public class BufferReadWrite : 
        Event.Portable.Objects.BufferedData.BufferReadWrite, ISerializable, IPostSetObject
    {
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BufferReadWrite()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected BufferReadWrite(SerializationInfo info, StreamingContext context)
            : this()
        {
            url = info.GetString("Url");
            input = info.GetValue("Input", typeof(List<string>)) as List<string>;
            directoryIteration = info.GetBoolean("DirectoryIteration");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Url", url);
            info.AddValue("Input", input, typeof(List<string>));
            info.AddValue("DirectoryIteration", directoryIteration);
        }

        #endregion

        #region IPostSetObject Members

        void IPostSetObject.PostSetObject()
        {
            Url = url;
        }

        #endregion


    }
}