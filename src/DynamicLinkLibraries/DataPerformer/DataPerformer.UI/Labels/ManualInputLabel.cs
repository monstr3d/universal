using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Labels;

using DataPerformer.Portable.Objects;

using DataPerformer.UI.UserControls;

namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label of manual input
    /// </summary>
    [Serializable]
    public class ManualInputLabel : UserControlBaseLabel
    {
        #region Fields

        UserControlManualInput uc;

        ManualInput input;

        Form form = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ManualInputLabel()
                : base(typeof(EventRelated.BufferedData.BufferReadWrite), "", 
                      ResourceImage._383.ToBitmap())
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public ManualInputLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ManualInputLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
                uc = new UserControlManualInput();
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
                return input;
            }
            set
            {
                input = value.GetObject<ManualInput>();
                uc.Input = input;
            }
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

        /// <summary>
        /// Creates Form
        /// </summary>
        public override void CreateForm()
        {

        }

        #endregion

    }
}
