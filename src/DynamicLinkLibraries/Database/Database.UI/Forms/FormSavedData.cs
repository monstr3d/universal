using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


using DataSetService;
using Diagram.UI.Labels;
using Diagram.UI;
using DataSetService.Forms;
using ResourceService;
using DataPerformer.UI;
using Diagram.UI.Interfaces;


namespace Database.UI.Forms
{
    public partial class FormSavedData : Form, IUpdatableForm
    {

        #region Fields
        IObjectLabel label;

        SavedDataProvider provider;

        Action showNumberDelegate;

        Action<bool> showTableDelegate;

        private bool show;


        #endregion

        #region Ctor

        private FormSavedData()
        {
            InitializeComponent();
        }

        public FormSavedData(IObjectLabel label, bool show,
            Action showNumber, Action<bool> showTable)
            : this()
        {
            ResourceService.Resources.LoadControlResources(this, 
                Database.UI.Utils.ControlUtilites.Resources);
            this.label = label;
            provider = label.Object as SavedDataProvider;
            this.showNumberDelegate = showNumber;
            this.showTableDelegate = showTable;
            UpdateFormUI();
            this.show = show;
            tabControlMain.TabPages.RemoveAt(0);
            checkBoxShowData.Checked = show;
        }


        #endregion

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        private void accept()
        {
            IDataSetProvider p = provider;
            DataSet dataSet = p.DataSet;
            if (dataSet == null)
            {
                return;
            }
            showTable();
        }

        private void showTable()
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
            showNumberDelegate();
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
            showTableDelegate(checkBoxShowData.Checked);
        }



        void LoadData()
        {
            DataSet dataSet = this.LoadDataSet();
            if (dataSet == null)
            {
                return;
            }
            provider.Set(dataSet);
            accept();
        }

        private void SaveData()
        {
            IDataSetProvider p = provider;
            this.SaveDataSet(p.DataSet);
        }

        private void checkBoxShowData_CheckedChanged(object sender, EventArgs e)
        {
            showTable();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}