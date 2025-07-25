﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;

using DataPerformer;
using ErrorHandler;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Editor of proterties of Funcrion accumulor
    /// </summary>
    public partial class UserControlFuncAccumulator : UserControl
    {
        #region Fields

        private FunctionAccumulator Acc
        {
            get;
            set;
        }

        TextBox start;
        TextBox step;
        
        
        NumericUpDown stepCount;

        NumericUpDown intDeg;

        event Action save;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlFuncAccumulator()
        {
            InitializeComponent();
            Create();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Accumulator
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FunctionAccumulator Function
        {
            get
            {
                return Acc;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (Acc != null)
                {
                    throw new ErrorHandler.OwnException("Accumulator exception");
                }
                Acc = value;
                Post();
            }
        }


        #endregion

        #region Private Members


        void Create()
        {
            var tb = typeof(TextBox);
            var nud = typeof(NumericUpDown);
            Type[] t = new Type[] { tb, tb, nud, nud };
            Diagram.UI.UserControls.UserControlEditList u = userControlEditList;
            u.Types = t;
            start = u.GetControl<TextBox>(0);
            step = u.GetControl<TextBox>(1);
            stepCount = u.GetControl<NumericUpDown>(2);
            stepCount.Maximum = 100000000;
            intDeg = u.GetControl<NumericUpDown>(3);
        }

        internal event Action OnSave
        {
            add
            {
                save += value;
            }
            remove
            {
                save -= value;
            }
        }

        internal void Post()
        {
            double[] arg = Acc.Arguments;
            if (arg == null)
            {
                return;
            }
            start.Text = arg[0] + "";
            if (arg.Length > 1)
            {
                step.Text = (arg[1] - arg[0]) + "";
            }
            stepCount.Value = arg.Length;
            intDeg.Value = Acc.Degree;
        }


        private void Save()
        {
            try
            {
                double st = Double.Parse(start.Text);
                double s = Double.Parse(step.Text);
                int n = (int)stepCount.Value;
                double[] arg = new double[n];
                for (int i = 0; i < arg.Length; i++)
                {
                    arg[i] = st + i * s;
                }
                Acc.Arguments = arg;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
        }

        #endregion

        #region Event Handlers

         private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            Save();
            if (save != null)
            {
                save();
            }
        }

        #endregion
    }
}

