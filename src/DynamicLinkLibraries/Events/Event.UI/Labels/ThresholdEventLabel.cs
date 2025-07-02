using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Labels;

using Event.Basic.Events;

using Event.UI.UserControls;

namespace Event.UI.Labels
{
    /// <summary>
    /// Threshold event
    /// </summary>
    [Serializable()]
    public class ThresholdEventLabel : UserControlBaseLabel
    {
        #region Fields

        UserControlThreshold uc;

        ThresholdEvent threshold;

        Form form = null;

        internal bool isSerialized = false;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public ThresholdEventLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {
            BorderStyle = BorderStyle.FixedSingle;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ThresholdEventLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            BorderStyle = BorderStyle.FixedSingle;
            isSerialized = true;
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
                uc = new UserControlThreshold();
                return uc;
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        protected override ICategoryObject Object
        {
            get
            {
                return threshold;
            }
            set
            {
                threshold = value.GetObject<ThresholdEvent>();
                uc.Event = threshold;
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
