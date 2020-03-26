using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using CategoryTheory;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using Motion6D;
using Motion6D.Interfaces;


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
                e.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            accept();
        }
    }
}