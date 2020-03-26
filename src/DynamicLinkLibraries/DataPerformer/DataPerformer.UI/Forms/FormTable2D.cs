using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Labels;
using DataPerformer;
using Diagram.UI;
using DataPerformer.UI.Labels;
using CategoryTheory;
using Diagram.UI.Interfaces;

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of 2D table
    /// </summary>
    public partial class FormTable2D : Form, IUpdatableForm, ISaveComments
    {
        #region Fields

        private IObjectLabel label;
        
        private Table2D table;
 
        #endregion


        private FormTable2D()
        {
            InitializeComponent();
        }

        internal FormTable2D(IObjectLabel label, Action action, Table2D table)
            : this()
        {
            userControlTable2DTab.Action = action;
            this.label = label;
            this.table = table;
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

        #region Event Handlers


        private void FormTable2D_Load(object sender, EventArgs e)
        {
            userControlTable2DTab.Table = table;
            this.SetComments(table.Comments);
        }

        void ISaveComments.Save()
        {
            table.Comments = this.GetComments() as System.Collections.ArrayList;
        }

        /*!!!! COMMENTS    private void FormTable2D_FormClosing(object sender, FormClosingEventArgs e)
            {
                userControlTable2DTab.SaveComments();
            }
            */

        #endregion




    }
}
