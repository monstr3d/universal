using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataWarehouse.Forms
{
    /// <summary>
    /// Form for connection string
    /// </summary>
    public partial class FormConnectionString : Form
    {
        #region Fields

        string cs;

        #endregion

        /// <summary>
        /// Constructos
        /// </summary>
        /// <param name="conns">All connection strings</param>
        /// <param name="conn">Connection string</param>
        public FormConnectionString(List<string> conns, string conn)
        {
            InitializeComponent();
            ResourceService.Resources.LoadControlResources(this,
                DataWarehouse.Utils.ControlUtilites.Resources);
            foreach (string s in conns)
            {
                comboBoxCS.Items.Add(s);
            }
            comboBoxCS.Text = conn;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxCS.SelectedItem != null)
            {
                cs = comboBoxCS.SelectedItem + "";
            }
            else
            {
                cs = comboBoxCS.Text;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Connection string
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return cs;
            }
        }

    }
}