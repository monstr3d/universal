using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.UserControls;


using DataPerformer;
using DataPerformer.Interfaces;


using Regression;



namespace DataPerformer.UI
{
    /// <summary>
    /// Editor of properties of combined selection
    /// </summary>
    public partial class FormCombinedSelection : Form, IUpdatableForm
    {
        #region

        IObjectLabel label;

        Panel panelSel;

        Panel panelWeight;

        CombinedSelection selection;

        #endregion

        #region Ctor

        private FormCombinedSelection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormCombinedSelection(IObjectLabel label)
            : this()
        {
            this.LoadResources();
            this.label = label;
            selection = label.Object as CombinedSelection;
            Text = label.Name;
            panelSel = panelCenter;
            panelWeight = panelDesktopCenter;
            fill(panelSel, true);
            fill(panelWeight, false);
        }

        #endregion

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        #region Specific Members

        private void radioButtonSel_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked)
            {
                return;
            }
            object[] o = rb.Tag as object[];
            IStructuredSelectionCollection coll = o[0] as IStructuredSelectionCollection;
            int n = (int)o[1];
            bool b = (bool)o[2];
            selection.Set(coll, n, b);
        }

        private void fill(Panel p, bool b)
        {
            int k = b ? 0 : 1;
            int[,] num = selection.Numbers;
            int n = num[k, 0];
            int m = num[k, 1];
            IList<IStructuredSelectionCollection> l = selection.Selections;
            int y = 0;
            for (int i = 0; i < l.Count; i++)
            {
                IStructuredSelectionCollection coll = l[i];
                CategoryTheory.IAssociatedObject ao = coll as CategoryTheory.IAssociatedObject;
                IObjectLabel lab = ao.Object as IObjectLabel;
                UserControlObject op = new UserControlObject(null, lab);
                op.Left = 0;
                op.Top = y;
                p.Controls.Add(op);
                y = op.Bottom + 5;
                int nSel = coll.Count;
                for (int j = 0; j < nSel; j++)
                {
                    IStructuredSelection sel = coll[j];
                    RadioButton rb = new RadioButton();
                    rb.CheckedChanged += radioButtonSel_CheckedChanged;
                    rb.Text = sel.Name;
                    rb.Tag = new object[] { coll, j, b };
                    if (n == i & m == j)
                    {
                        rb.Checked = true;
                    }
                    rb.Left = 5;
                    rb.Top = y;
                    p.Controls.Add(rb);
                    y = rb.Bottom + 5;
                }
                Panel bl = new Panel();
                bl.BackColor = Color.Black;
                bl.Width = p.Width - 10;
                bl.Left = 0;
                bl.Top = y;
                bl.Height = 2;
                p.Controls.Add(bl);
                y = bl.Bottom + 5;
            }
        }

        #endregion


    }
}