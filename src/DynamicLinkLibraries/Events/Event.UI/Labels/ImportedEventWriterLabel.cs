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
    /// Label of remoting event
    /// </summary>
    [Serializable()]
    public class ImportedEventWriterLabel : UserControlBaseLabel
    {
        #region Fields

        UserControlRemoteOutput uc;

        ImportedEventWriter writer;

        Form form = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public ImportedEventWriterLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ImportedEventWriterLabel(SerializationInfo info, StreamingContext context)
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
                uc = new UserControlRemoteOutput();
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
                return writer;
            }
            set
            {
                writer = value.GetObject<ImportedEventWriter>();
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
        /// Post operation
        /// </summary>
        public override void Post()
        {
            uc.Writer = writer;
            IAssociatedObject ao = this.Object;
            object o = ao.Object;
            if (o is UserControlLabel)
            {
                UserControlLabel ucl = o as UserControlLabel;
                ucl.SetImage(Properties.Resources.SeverEvent.ToBitmap());
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
