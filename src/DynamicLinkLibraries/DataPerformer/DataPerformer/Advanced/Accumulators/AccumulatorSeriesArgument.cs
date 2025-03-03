using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Diagram.UI;
using ErrorHandler;

namespace DataPerformer.Advanced.Accumulators
{
    /// <summary>
    /// Accumulator with series argument
    /// </summary>
    [Serializable()]
    public class AccumulatorSeriesArgument : AccumulatorBase
    {
 
       #region Fields

        string argument;
  
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AccumulatorSeriesArgument()
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected AccumulatorSeriesArgument(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            try
            {
                argument = info.GetString("Argument");
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }


        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (argument != null)
            {
                info.AddValue("Argument", argument);
             }
        }

        #endregion


        #region Overriden members

        /// <summary>
        /// Post operation
        /// This funtion is called afrer editing of propreties
        /// </summary>
        protected override void Post()
        {
            if (argument == null)
            {
                return;
            }
            Array ar = this.GetOneDimensionRealArray(argument);
            if (ar == null)
            {
                argument = null;
            }
            arg = new double[ar.Length];
            for (int i = 0; i < arg.Length; i++)
            {
                arg[i] = (double)ar.GetValue(i);
            }
            base.Post();
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Argument
        /// </summary>
        public string Argument
        {
            get
            {
                return argument;
            }
            set
            {
                argument = value;
                Post();
            }
        }

        #endregion



    }
}
