using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;
using ErrorHandler;

namespace DataPerformer.UI
{
    /// <summary>
    /// Editor of properties of iterator filter
    /// </summary>
    public partial class FormIteratorFilter : Form, IUpdatableForm
    {
        private IObjectLabel label;

        private FormulaFilterIterator filter;

        private PanelFormula panel;


        private PanelConsumer pConsumer;

        private FormIteratorFilter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label</param>
        public FormIteratorFilter(IObjectLabel label)
        {
            InitializeComponent();
            this.label = label;
            filter = label.Object as FormulaFilterIterator;
            Text = label.Name;
            dataGridViewConst.DataSource = dataSetConst.Tables[0];
            Prepare();
        }

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        /// <summary>
        /// Prepares itself
        /// </summary>
        protected void Prepare()
        {
            panel = new PanelFormula("Condition", this, splitContainerMain.Panel1.Width, 200,
                    "abcdfghijklmnopqrstuvwxyz", false, null, null);
            panel.Dock = DockStyle.Fill;
            splitContainerMain.Panel1.Controls.Add(panel);
            panel.Formula = filter.Formula;
            check();
            pConsumer = new PanelConsumer(filter, filter.VariableDictionary, filter.Variables);
            panelMeaCenter.Controls.Add(pConsumer);
            fillConst();
        }

        private void buttonAcceptForm_Click(object sender, EventArgs e)
        {
            try
            {
                filter.Formula = panel.Formula;
                check();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        private void check()
        {
            string s = filter.AllVariables;
            string check = filter.Constants;
            checkedListBoxConst.CheckList(s, check);

        }

        private void buttonAcceptPar_Click(object sender, EventArgs e)
        {
            try
            {
                filter.VariableDictionary = pConsumer.Selected; 
   
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }



        private void buttonAcceptConst_Click(object sender, EventArgs e)
        {
            filter.Constants = checkedListBoxConst.GetCheckedString();
            pConsumer.Vars = filter.Variables;

            fillConst();
        }


        private void fillConst()
        {
            Dictionary<string, object> l = new Dictionary<string, object>();
            DataTable t = dataSetConst.Tables[0];
            foreach (DataRow row in t.Rows)
            {
                l["" + row[0]] = row[1];
            }
            t.Rows.Clear();
            Dictionary<string, object> consts = filter.ConstDictionary;
            foreach (string key in consts.Keys)
            {
                object o = consts[key];
                if (l.ContainsKey(key))
                {
                    o = l[key];
                }
                t.Rows.Add(new object[] {key, o});
            }
            dataGridViewConst.Refresh();
        }

        private void buttonAcceptValues_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            DataTable t = dataSetConst.Tables[0];
            foreach (DataRow row in t.Rows)
            {
                string key = row[0] + "";
                d[key] = (double)row[1];
            }
            filter.ConstDictionary = d;
        }
    }
}