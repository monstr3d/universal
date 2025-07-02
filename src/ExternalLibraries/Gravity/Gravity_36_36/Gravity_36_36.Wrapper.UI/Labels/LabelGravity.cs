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
using Gravity_36_36.Wrapper.UI.Forms;
using Gravity_36_36.Wrapper.UI.UserControls;

namespace Gravity_36_36.Wrapper.UI.Labels
{
    /// <summary>
    /// Label for gravity
    /// </summary>
    [Serializable]
    public class LabelGravity : UserControlBaseLabel
    {
        #region Fields

        /// <summary>
        /// User control of frame data
        /// </summary>
        protected UserControlGravity uc;

        private Serializable.Gravity gravity;

        List<string> history = new List<string>();

        Form form;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelGravity() : this(typeof(Serializable.Gravity), "", Properties.Resources.EARTH_GRAVITY.ToBitmap())
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public LabelGravity(Type type, string kind, Image icon)
                : base(type, kind, icon)
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected LabelGravity(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Base load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
        }

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {

                uc = new UserControlGravity();
                UserControl cont = new UserControl();
                cont.BorderStyle = BorderStyle.Fixed3D;
                cont.Size = uc.Size;
                uc.Dock = DockStyle.Fill;
                cont.Controls.Add(uc);
                return cont;
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        protected override ICategoryObject Object
        {
            get
            {
                return gravity;
            }
            set
            {
                if (!(value is Serializable.Gravity))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                gravity = value as Serializable.Gravity;
                uc.Gravity = gravity;
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {

        }

        /// <summary>
        /// Label form
        /// </summary>
        public override object Form
        {
            get
            {
                return form;
            }
        }

        /// <summary>
        /// Creates a form
        /// </summary>
        public override void CreateForm()
        {
            form = new FormGravity(gravity);
        }

        #endregion

    }
}