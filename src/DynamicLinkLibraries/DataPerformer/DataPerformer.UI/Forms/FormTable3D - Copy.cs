using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataPerformer;

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of properties of 3D table
    /// </summary>
    public partial class FormTable3D : Form, IUpdatableForm, ISaveComments
    {
        #region Fields

        IObjectLabel label;

        Table3D table;

        #endregion

        #region Ctor

        internal FormTable3D()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label of object</param>
        public FormTable3D(IObjectLabel label)
            : this()
        {
            this.LoadResources();
            this.label = label;
            table = label.Object as Table3D;
            UpdateFormUI();
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

    

        private void FormTable3D_Load(object sender, EventArgs e)
        {
         
            userControlTable3D.Table = table;
            this.SetComments(table.Comments);
        }

        void ISaveComments.Save()
        {
            table.Comments = this.GetComments() as System.Collections.ArrayList;
        }
    }
}
