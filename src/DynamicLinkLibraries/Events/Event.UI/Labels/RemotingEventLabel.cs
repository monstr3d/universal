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

using Event.UI.UserControls;

namespace Event.UI.Labels
{
    /// <summary>
    /// Label of remoting event
    /// </summary>
    [Serializable()]
    public class RemotingEventLabel : UserControlBaseLabel
    {
        #region Fields

        UserControlRemotingEvent uc;

        Event.Basic.Events.ImportedEvent be;

//!!!REMOVED Event.Remote.RemoteEvent re;

        Form form = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public RemotingEventLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected RemotingEventLabel(SerializationInfo info, StreamingContext context)
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
                uc = new UserControlRemotingEvent();
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
                return be;
            }
            set
            {
                be = value.GetObject<Event.Basic.Events.ImportedEvent>();
       /*         !!!REMOVED         re = be.Event as Event.Remote.RemoteEvent;
                uc.Event = re;*/
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
            form = new Forms.FormEventRemoting(this);
        }

        #endregion
    }
}
