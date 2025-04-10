using System;
using System.Windows.Forms;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;


using DataPerformer.UI.UserControls;


namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label for function accumulator
    /// </summary>
    [Serializable()]
    public class FuncAccumulatorLabel : UserControlBaseLabel
    {

        #region Fields

        FunctionAccumulator acc;

        UserControlFuncAccumulator uc;

        Form form;
 
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FuncAccumulatorLabel()
            : base(typeof(FunctionAccumulator), "", ResourceImage.Accumulator)
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected FuncAccumulatorLabel(SerializationInfo info, StreamingContext context)
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
                uc = new UserControlFuncAccumulator();
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
                if (!(value is FunctionAccumulator))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                acc = value as FunctionAccumulator;
                acc.Object = this;
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
            uc.Function = acc;
            var up = this.FindParent<UserControlBaseLabel>();
            if (up != null)
            {
                up.FirstLoad = false;
            }
        }

        /// <summary>
        /// Creates Form
        /// </summary>
        public override void CreateForm()
        {
            form = new Forms.FormFuncAccumulator(this.GetRootLabel(), uc);
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

        #region Internal


        internal void PostControl()
        {
            uc.Post();
        }

        #endregion
    }
}
