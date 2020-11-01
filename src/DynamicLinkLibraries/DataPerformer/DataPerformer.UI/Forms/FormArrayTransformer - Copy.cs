using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using DataPerformer;

namespace DataPerformer.UI.Forms
{

    /// <summary>
    /// Editor of properties of array transformer
    /// </summary>
    public partial class FormArrayTransformer : Form, IUpdatableForm
    {
        IObjectLabel label;

        private FormArrayTransformer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormArrayTransformer(IObjectLabel label)
            : this()
        {
            this.label = label;
            UpdateFormUI();
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

        private void FormArrayTransformer_Load(object sender, EventArgs e)
        {
            userControlArrayTransformer.Transformer = label.Object as ArrayTransformer;
        }
    }
}
