using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using DataPerformer.Helpers;

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of properties of collection state transformer
    /// </summary>
    public partial class FormDataPerformerCollectionStateTransformer : Form, IUpdatableForm
    {
        #region Fields
        IObjectLabel label;

        DataPerformerCollectionStateTransformer transformer;

        #endregion

        #region Ctor

        internal FormDataPerformerCollectionStateTransformer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">La</param>
        public FormDataPerformerCollectionStateTransformer(IObjectLabel label)
            : this()
        {
            this.label = label;
            transformer = label.Object as DataPerformerCollectionStateTransformer;
            userControlComponentCollectionVariablesFull.Transformer = transformer;
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
    }
}
