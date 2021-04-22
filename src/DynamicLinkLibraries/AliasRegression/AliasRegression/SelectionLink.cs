using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI.Labels;

using DataPerformer;
using DataPerformer.Interfaces;

namespace Regression
{

    /// <summary>
    /// Link of selection
    /// </summary>
    [Serializable()]
    public class SelectionLink : Portable.SelectionLink, ISerializable
    {
 

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SelectionLink()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SelectionLink(SerializationInfo info, StreamingContext context)
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
          //  info.AddValue("A", a);
        }

        #endregion
    }

}
