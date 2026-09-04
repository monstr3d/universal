using System.Windows.Forms;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using Motion6D.Interfaces;
using NamedTree.Interfaces;


namespace WpfInterface.UI.Forms
{
    public partial class FormDeformed : Form, IUpdatableForm
    {
        #region Fields

        IObjectLabel label;


        #endregion


        private FormDeformed()
        {
            InitializeComponent();
        }


        public FormDeformed(IPosition p, IVisible v)
            : this()
        {
            userControlDeformed.Set(p, v);
            IAssociatedObject ao = p as IAssociatedObject;
            label = ao.Object as IObjectLabel;

            UpdateFormUI();
        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            if (label != null)
            {
                Text = label.Name;
            }
        }

        #endregion
    }

}
