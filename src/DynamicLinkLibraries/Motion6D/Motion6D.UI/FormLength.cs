using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using ErrorHandler;
using Motion6D.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Motion6D.UI
{
    /// <summary>
    /// Editor of length
    /// </summary>
    public partial class FormLength : Form, IUpdatableForm
    {
        private IObjectLabel label;

        private ILength length;

        private FormLength()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="length">The length</param>
        public FormLength(ILength length)
            : this()
        {
            this.length = length;
            IAssociatedObject ao = length as IAssociatedObject;
            label = ao.Object as IObjectLabel;
            UpdateFormUI();
            textBoxLength.Text = length.Length + "";
        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        /// <summary>
        /// Header of component
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Header
        {
            set
            {
                labelHead.Text = 
                    ResourceService.Resources.GetControlResource(value, Motion6D.UI.Utils.ControlUtilites.Resources);
            }
        }

        void accept()
        {
            try
            {
                length.Length = Double.Parse(textBoxLength.Text);
            }
            catch (Exception e)
            {
                e.HandleException(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            accept();
        }
    }
}