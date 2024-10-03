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

using DataPerformer.UI.UserControls;


namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of accumulator
    /// </summary>
    public partial class FormFuncAccumulator : Form, IUpdatableForm
    {
        #region Fields

        UserControlFuncAccumulator uc;

        IObjectLabel l;

        #endregion


        private FormFuncAccumulator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="l">Label of object</param>
        public FormFuncAccumulator(IObjectLabel l)
            : this()
        {
            this.l = l;
            userControlFuncAccumulatorFull.Function = l.Object as DataPerformer.FunctionAccumulator;
            UpdateFormUI();
        }

        internal FormFuncAccumulator(IObjectLabel l, UserControlFuncAccumulator uc)
            : this()
        {
            this.uc = uc;
            this.l = l;
            userControlFuncAccumulatorFull.Function = 
                l.Object as DataPerformer.FunctionAccumulator;
            userControlFuncAccumulatorFull.OnSave += () =>
                {
                    uc.Post();
                };
            UpdateFormUI();
        }

        #region IUpdatableForm Members


        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = l.Name;
        }

        #endregion
    }
}
