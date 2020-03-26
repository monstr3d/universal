using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Diagram.UI
{
    /// <summary>
    /// Data table form
    /// </summary>
    public partial class FormDataTable : Form
    {
        #region Fields

        private DataTable table;


        #endregion

        #region Ctor

        private FormDataTable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor from table
        /// </summary>
        /// <param name="table">The table</param>
        public FormDataTable(DataTable table)
        {
            InitializeComponent();
            this.table = table;
            Set();
        }

        /// <summary>
        /// Constructor from xml element
        /// </summary>
        /// <param name="e">The element</param>
        /// <param name="tag">Taf of row</param>
        /// <param name="attributes">Attributes of columns</param>
        public FormDataTable(XmlElement e, string tag, string[] attributes)
        {
            InitializeComponent();
            table = e.CreateTable(tag, attributes);
            Set();
        }

        #endregion

        /// <summary>
        /// Associated table
        /// </summary>
        public DataTable Table
        {
            get { return table; }
        }


        private void Set()
        {
            dataGridViewTable.DataSource = table;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}