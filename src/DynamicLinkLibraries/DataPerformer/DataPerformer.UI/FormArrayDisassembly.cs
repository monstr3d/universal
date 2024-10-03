using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using DataPerformer;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

namespace DataPerformer.UI
{
    /// <summary>
    /// Editor of array disassembly properties
    /// </summary>
    public partial class FormArrayDisassembly : Form, IUpdatableForm
    {
        private IObjectLabel label;

        private ArrayDisassembly array;

        private FormArrayDisassembly()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormArrayDisassembly(IObjectLabel label)
            : this()
        {
            this.label = label;
            UpdateFormUI();
            array = label.Object as ArrayDisassembly;
            List<string> l = array.Measures;
            comboBoxArray.FillCombo(l);
            comboBoxArray.SelectCombo(array.Measure);
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

        void accept()
        {
            if (comboBoxArray.SelectedItem == null)
            {
                return;
            }
            array.Measure = comboBoxArray.SelectedItem + "";
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            accept();
        }
    }
}