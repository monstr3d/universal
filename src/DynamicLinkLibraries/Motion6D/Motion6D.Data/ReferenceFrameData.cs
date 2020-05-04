using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;

using DataPerformer;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;


namespace Motion6D
{
    /// <summary>
    /// Reference frame controlled by data
    /// </summary>
    [Serializable()]
    public class ReferenceFrameData : Portable.ReferenceFrameDataBase
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReferenceFrameData()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private ReferenceFrameData(SerializationInfo info, StreamingContext context)
        {

        }



        #endregion

        #region Specific Members
  
        /// <summary>
        /// Parameters
        /// </summary>
        new public List<string> Parameters
        {
            get
            {
                return parameters;
            }
            set
            {
                if (value.Count != 7)
                {
                    throw new Exception();
                }
                parameters = value;
                SetParameters();
            }
        }
 
        #endregion
    }
}
