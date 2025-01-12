using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Drawing;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Labels;

using DataPerformer.Python.Objects;
using DataPerformer.Python.UI.UserControls;

namespace DataPerformer.Python.UI.Labels
{
    /// Python data performer label
    /// </summary>
    [Serializable()]
    public class DataPerformerLabel : UserControlBaseLabel
    {
        #region Fields

        UserControlDataPefrormer uc;

        PythonTransformer transformer;

        Form form = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public DataPerformerLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {
            BorderStyle = BorderStyle.FixedSingle;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private DataPerformerLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            BorderStyle = BorderStyle.FixedSingle;
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
                uc = new UserControlDataPefrormer();
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
                return transformer;
            }
            set
            {
                transformer = value.GetObject<PythonTransformer>();
                uc.Transformer = transformer;
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
