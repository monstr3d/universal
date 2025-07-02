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
using Event.Basic.Data.Events;

using Event.UI.UserControls;


namespace Event.UI.Labels
{
    /// <summary>
    /// Label of forced event circilar control
    /// </summary>
    [Serializable()]
    public class TransientProcessEventLabel : UserControlBaseLabel
    {
        #region Fields

       new UserControlTransientProcessEvent control;

        TransientProcessEvent transient;
   
        #endregion

       #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TransientProcessEventLabel()
            : base(typeof(TransientProcessEvent), "", Properties.Resources.JoystickCircular)
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected TransientProcessEventLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                control = new UserControlTransientProcessEvent();
                control.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                Set();
                return control;
            }
        }


        /// <summary>
        /// Object
        /// </summary>
        protected override ICategoryObject Object
        {
            get
            {
                return transient;
            }
            set
            {
                TransientProcessEvent f = value.GetObject<TransientProcessEvent>();
                if (f == null)
                {
                    return;
                }
                transient = f;
                Set();
            }
        }

        /// <summary>
        /// Creates editor form
        /// </summary>
        public override void CreateForm()
        {
           // form = new Forms.FormCircular2DControl(this);
        }

        /// <summary>
        /// Editor form
        /// </summary>
        public override object Form
        {
            get
            {
                return null;
            }
        }

 
        #endregion

        #region Internal Members
 
        #endregion

        #region Private Members


        void Set()
        {
            if ((control == null) | (transient == null))
            {
                return;
            }
            control.Transient = transient;
        }

        #endregion

    }
}
