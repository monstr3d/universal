using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using DataPerformer.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;

namespace Event.Basic.Data
{
    /// <summary>
    /// Iterator of log
    /// </summary>
    [Serializable]
    public class LogIterator : Portable.LogIterator, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LogIterator()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected LogIterator(SerializationInfo info, StreamingContext context)
        {
            try
            {
                isDirectoryOriented = info.GetBoolean("IsDirectoryOriented");
            }
            catch
            {

            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IsDirectoryOriented", isDirectoryOriented);
        }

        #endregion

    }
}
