using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Labels;

using Event.Log.Database;
using Event.UI.UserControls;

namespace Event.UI.Labels
{
    /// <summary>
    /// UI Label of log object
    /// </summary>
    [Serializable()]
    public class LogLabel : UserControlBaseLabel
    {
        #region Fields

        /// <summary>
        /// User control of frame data
        /// </summary>
        protected UserControlLog uc;

        private Portable.LogHolder log;

        List<string> history = new List<string>();

        Form form;

        Size formSize = new Size(0, 0);

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LogLabel() : this(typeof(Basic.Data.LogHolder), "", Properties.Resources.log.ToBitmap())
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public LogLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private LogLabel(SerializationInfo info, StreamingContext context)
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
            try
            {
                history = info.GetValue("History", typeof(List<string>)) as List<string>;
                formSize = (Size)info.GetValue("FormSize", typeof(Size));
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {

                uc = new UserControlLog(history);
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
                return log;
            }
            set
            {
                if (!(value is Portable.LogHolder))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                log = value as Portable.LogHolder;
                uc.Log = log;
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
            if (StaticExtensionEventLogDatabase.ConnectionString.Length == 0)
            {
                form = null;
            }
            else
            {
                form = new Forms.FormLogEdit(this);
                if (formSize.Width > 0)
                {
                    form.Size = formSize;
                }
                else
                {
                    formSize = form.Size;
                }
                form.Resize += (object sender, EventArgs e) =>
                {
                    formSize = form.Size;
                };
            }
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context) 
        {
            base.GetObjectData(info, context);
            info.AddValue("History", history, typeof(List<string>));
            info.AddValue("FormSize", formSize, typeof(Size));
        }

        #endregion
    }
}
