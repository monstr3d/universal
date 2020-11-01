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
    public class ReferenceFrameDataPitchRollHunting : ReferenceFrameDataBase
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReferenceFrameDataPitchRollHunting()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private ReferenceFrameDataPitchRollHunting(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }



        #endregion

        #region Overriden Members

        /// <summary>
        /// Count of input parametese
        /// </summary>
        protected override int ParametersCount
        {
            get
            {
                return 6;
            }
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
                if (value.Count != 6)
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

