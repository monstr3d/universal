using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Advanced.Accumulators;
using DataPerformer.Attributes;


namespace DataPerformer
{
    /// <summary>
    /// Accumulator of function
    /// </summary>
    [Serializable()]
    [CalculationPriority(1)]
    public class FunctionAccumulator : AccumulatorBase
    {
        #region Fields

  
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FunctionAccumulator()
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected FunctionAccumulator(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            try
            {
                arg = info.GetValue("Arguments", typeof(double[])) as double[];
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
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
            if (arg != null)
            {
                info.AddValue("Arguments", arg, typeof(double[]));
             }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Array of arguments
        /// </summary>
        public double[] Arguments
        {
            get
            {
                return arg;
            }
            set
            {
                arg = value;
                if (arg != null)
                {
                    Post();
                }
            }
        }

        #endregion

    }

}
