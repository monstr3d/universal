using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;



using Diagram.UI.Labels;
using DataPerformer.Advanced.Accumulators;
using DataPerformer.UI.UserControls;
using CategoryTheory;


namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label for accumulator with series argument
    /// </summary>
    [Serializable()]
    public class AccumulatorSeriesArgumentLabel : UserControlBaseLabel
    {
        #region Fields
        AccumulatorSeriesArgument acc;

        UserControlAccumulatorSeriesArgument uc;

        Form form = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AccumulatorSeriesArgumentLabel()
            : base(typeof(AccumulatorSeriesArgument), "", ResourceImage.AccumSeries.ToBitmap())
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected AccumulatorSeriesArgumentLabel(SerializationInfo info, StreamingContext context)
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
                uc = new UserControlAccumulatorSeriesArgument();
                return uc;
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return acc;
            }
            set
            {
                if (!(value is AccumulatorSeriesArgument))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                acc = value as AccumulatorSeriesArgument;
                acc.Object = this;
                uc.Accumulator = acc;
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
            uc.Fill();
        }

        /// <summary>
        /// Creates Form
        /// </summary>
        public override void CreateForm()
        {
           // form = new Forms.FormFuncAccumulator(this.GetRootLabel(), uc);
        }

        /// <summary>
        /// Associated form
        /// </summary>
        public override object Form
        {
            get
            {
                return form;
            }
        }

        #endregion


    }
}
