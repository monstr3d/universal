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

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Editor of proterties of Funcrion accumulor
    /// </summary>
    public partial class UserControlFuncAccumulator : UserControl
    {
        #region Fields

        private FunctionAccumulator acc;

        TextBox start;
        TextBox step;
        TextBox stepCount;

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
        public FunctionAccumulator Function
        {
            get
            {
                return acc;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (acc != null)
                {
                    throw new Exception();
                }
                acc = value;
                Post();
            }
        }


        #endregion

        #region Private Members


        void Create()
        {
            Type tt = typeof(TextBox);
            Type[] t = new Type[] { tt, tt, tt, typeof(NumericUpDown) };
            Diagram.UI.UserControls.UserControlEditList u = userControlEditList;
            u.Types = t;
            start = u.GetControl<TextBox>(0);
            step = u.GetControl<TextBox>(1);
            stepCount = u.GetControl<TextBox>(2);
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
            double[] arg = acc.Arguments;
            if (arg == null)
            {
                return;
            }
            start.Text = arg[0] + "";
            step.Text = (arg[1] - arg[0]) + "";
            stepCount.Text = arg.Length + "";
            intDeg.Value = acc.Degree;
        }


        private void Save()
        {
            try
            {
                double st = Double.Parse(start.Text);
                double s = Double.Parse(step.Text);
                int n = Int32.Parse(stepCount.Text);
                double[] arg = new double[n];
                for (int i = 0; i < arg.Length; i++)
                {
                    arg[i] = st + i * s;
                }
                acc.Arguments = arg;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
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

