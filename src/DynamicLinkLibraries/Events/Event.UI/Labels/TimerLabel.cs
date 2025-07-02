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

using Event.Interfaces;
using Event.UI.UserControls;


namespace Event.UI.Labels
{
    /// <summary>
    /// Label of timer
    /// </summary>
    [Serializable()]
    public class TimerLabel : UserControlBaseLabel
    {
        #region Fields

        UserControlTimer uc;

        ITimerEvent timer;

        Form form = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public TimerLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected TimerLabel(SerializationInfo info, StreamingContext context)
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
                uc = new UserControlTimer();
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
                return timer as ICategoryObject;
            }
            set
            {
                timer = value.GetObject<ITimerEvent>();
                if (uc != null)
                {
                    uc.Timer = value as ITimerEvent;
                }
             }
        }

        /// <summary>
        /// Associated form
        /// </summary>
        public override object Form
        {
            get
            {
                return null;
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
