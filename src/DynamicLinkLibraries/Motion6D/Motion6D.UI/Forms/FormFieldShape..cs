using System.Windows.Forms;


using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using NamedTree.Interfaces;


namespace Motion6D.UI.Forms
{
    /// <summary>
    /// Editor of field shape
    /// </summary>
    public partial class FormFieldShape : Form, IUpdatableForm
    {

        IObjectLabel label;

        internal FormFieldShape()
        {
            InitializeComponent();
            this.LoadControlResources(Motion6D.UI.Utils.ControlUtilites.Resources);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label</param>
        public FormFieldShape(IObjectLabel label)
            : this()
        {
            Set(label);
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="ao">Associated object</param>
        public FormFieldShape(IAssociatedObject ao)
            : this()
        {
            Set(ao.Object as IObjectLabel);
        }

        private FormFieldShape(FieldConsumer3D consumer)
            : this()
        {
            IAssociatedObject ao = consumer as IAssociatedObject;
            Set(ao.Object as IObjectLabel);
        }

        private void userControlFieldShape_Close()
        {
            Close();
        }

        private void Set(IObjectLabel label)
        {
            this.label = label;
            userControlFieldShape.Label = label;
            UpdateFormUI();
        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            if (label == null)
            {
                return;
            }
            Text = label.Name;
        }

        #endregion
    }
}
