using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;

using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;
using Motion6D.Portable;

namespace Motion6D
{
    /// <summary>
    /// Reference frame controlled by data
    /// </summary>
    [Serializable()]
    public class ReferenceFrameDataBase : Portable.ReferenceFrameDataBase
    {

        #region Constructors


        /// <summary>
        /// Default constructor
        /// </summary>

        public ReferenceFrameDataBase()
        {
            ClearAliases();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ReferenceFrameDataBase(SerializationInfo info, StreamingContext context)
        {
            ClearAliases();
            parameters = info.GetValue("Parameters", typeof(List<string>)) as List<string>;
            IsSerialized = true;
        }

        #endregion
 
  
    }
}
