using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI;

using DataPerformer;

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of vector consumer
    /// </summary>
    public partial class FormVectorConsumer : Form, IUpdatableForm, ISaveComments
    {

        #region Fields

        private VectorFormulaConsumer consumer;
        private IObjectLabel label;


        #endregion

        #region Ctor

        private FormVectorConsumer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label</param>
        public FormVectorConsumer(IObjectLabel label)
            : this()
        {
            this.label = label;
            consumer = label.Object as VectorFormulaConsumer;
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

        private void FormVectorConsumer_Load(object sender, EventArgs e)
        {
            userControlFormulaEditor.Consumer = consumer;
            userControlFormulaEditor.Load();
            this.SetComments(consumer.Comments);
        }

        void ISaveComments.Save()
        {
            consumer.Comments = this.GetComments() as System.Collections.ArrayList;
        }
        /*
       private void FormVectorConsumer_FormClosing(object sender, FormClosingEventArgs e)
       {
           userControlFormulaEditor.SaveComments();
       }

       private void FormVectorConsumer_FormClosed(object sender, FormClosedEventArgs e)
       {
           userControlFormulaEditor.SaveComments();
       }
       */
    }
}
