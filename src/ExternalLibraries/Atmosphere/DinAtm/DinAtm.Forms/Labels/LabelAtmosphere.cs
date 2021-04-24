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
using DinAtm.Forms.FormUI;
using DinAtm.Forms.UserControls;
//using Gravity_36_36.Wrapper.UI.Forms;
//using Gravity_36_36.Wrapper.UI.UserControls;

namespace DinAtm.Forms.Labels
{
    /// <summary>
    /// Label for gravity
    /// </summary>
    [Serializable]
    public class LabelAtmosphere : UserControlBaseLabel
    {
        #region Fields

        /// <summary>
        /// User control of frame data
        /// </summary>
        protected UserControlAtmosphere uc;

        DimAtm.Serializable.Atmosphere atmosphere;
        //private DinAtm.

        //Serializable.Atmosphere atmosphere;

  
        Form form;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelAtmosphere() : this(typeof(DimAtm.Serializable.Atmosphere), "", 
            Properties.Resources.Atmosphere.ToBitmap())
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public LabelAtmosphere(Type type, string kind, Image icon)
                : base(type, kind, icon)
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected LabelAtmosphere(SerializationInfo info, StreamingContext context)
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

                uc = new UserControlAtmosphere();
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
        public override ICategoryObject Object
        {
            get
            {
                return atmosphere;
            }
            set
            {
                if (!(value is DimAtm.Serializable.Atmosphere))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                atmosphere = value as DimAtm.Serializable.Atmosphere;
                uc.Atmosphere = atmosphere;
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
            form = new FormAtmosphere(atmosphere);
        }

        #endregion
    }
}
