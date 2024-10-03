using CategoryTheory;
using Diagram.UI.Labels;
using Event.Portable;
using Event.UI.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event.UI.Labels
{
    /// <summary>
    /// Label of log iterator
    /// </summary>
    [Serializable()]
    class LogIteratorLabel : UserControlBaseLabel
    {

        #region Fields

        UserControlLogIterator uc;

        LogIterator iterator;

        Form form = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LogIteratorLabel() : this(typeof(Basic.Data.LogIterator), "", 
            Properties.Resources.logIterator.ToBitmap())
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public LogIteratorLabel(Type type, string kind, Image icon)
                : base(type, kind, icon)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected LogIteratorLabel(SerializationInfo info, StreamingContext context)
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
                uc = new UserControlLogIterator();
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
                return iterator;
            }
            set
            {
                iterator = value.GetObject<LogIterator>();
                if (uc != null)
                {
                    uc.Iterator = iterator;
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
