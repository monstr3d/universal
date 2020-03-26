using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataPerformer.Advanced;
using DataPerformer.UI.UserControls;

namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label for delay accumulator
    /// </summary>
    [Serializable()]
    public class DelayAccumulatorLabel : UserControlBaseLabel
    {

        #region Fields

        DynamicFunction func;

       UserControlDelayAccumulator userControlDelayAccumulator;
 
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DelayAccumulatorLabel()
            : base(typeof(DynamicFunction), "", ResourceImage.AccumulatorDelay.ToBitmap())
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DelayAccumulatorLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Overriden


        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get 
            {
                userControlDelayAccumulator = new UserControlDelayAccumulator();
                return userControlDelayAccumulator;
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return func;
            }
            set
            {
                if (!(value is DynamicFunction))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                func = value as DynamicFunction;
                userControlDelayAccumulator.Function = func;
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
        }

        #endregion
    }
}
