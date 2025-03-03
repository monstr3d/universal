using System;
using System.Runtime.Serialization;


using Diagram.UI;
using ErrorHandler;

namespace DataPerformer
{
    /// <summary>
    /// Object which assemblies variables to vector
    /// </summary>
    [Serializable()]
    public class VectorAssembly : Portable.VectorAssembly, ISerializable
    { 
 
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VectorAssembly() : base()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private VectorAssembly(SerializationInfo info, StreamingContext context)
            : this()
        {
            try
            {
                names = info.GetValue("Names", typeof(string[])) as string[];
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (names == null)
            {
                return;
            }
            info.AddValue("Names", names, typeof(string[]));
        }

        #endregion

   
    }
}
