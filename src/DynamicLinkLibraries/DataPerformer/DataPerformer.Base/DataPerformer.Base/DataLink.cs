using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;


using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;

namespace DataPerformer
{
    /// <summary>
    /// The link between data provider and data consumer
    /// </summary>
    [Serializable()]
    public class DataLink : DataPerformer.Portable.DataLink, ISerializable,
        IRemovableObject, IDataLinkFactory
    {

        #region Fields

   
  

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataLink()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DataLink(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }


        #endregion

        #region ICategoryArrow Members

 
        #endregion
    }
}
