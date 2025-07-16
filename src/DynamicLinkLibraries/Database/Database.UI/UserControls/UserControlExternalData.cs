using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataSetService;
using DataSetService.Forms;

namespace Database.UI.UserControls
{
    public partial class UserControlExternalData : UserControl
    {
        #region Fields

        IDataSetProvider provider;

        #endregion

        public UserControlExternalData()
        {
            InitializeComponent();
        }

        #region Internal Members

        internal void Add(Control control)
        {
            control.Dock = DockStyle.Fill;
            panelSource.Controls.Add(control);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IDataSetProvider Provider
        {
            get
            {
                return provider;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                provider = value;
            }
        }

        #endregion

        #region Private Members

        private void ShowTable()
        {
            IDataSetProvider p = provider;
            DataSet dataSet = p.DataSet;
            if (dataSet.Tables.Count == 0)
            {
                return;
            }
            int n = dataSet.Tables[0].Rows.Count;
            labelNumber.Text = ResourceService.Resources.GetControlResource("Number of rows: ",
                Database.UI.Utils.ControlUtilites.Resources) + n;
 //           showNumberDelegate();
            if (!checkBoxShowData.Checked)
            {
                dataGridViewTable.DataSource = null;
                return;
            }
            if (dataSet != null)
            {
                if (dataSet.Tables.Count > 0)
                {
                    dataGridViewTable.DataSource = dataSet.Tables[0];
                }
                else
                {
                    dataGridViewTable.DataSource = null;
                }
            }
      //      showTableDelegate(checkBoxShowData.Checked);
        }

        private void SaveData()
        {
            IDataSetProvider p = provider;
            this.FindForm().SaveDataSet(p.DataSet);
        }


        #endregion

        #region Event handlers

        private void checkBoxShowData_CheckedChanged(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        #endregion
    }
}
