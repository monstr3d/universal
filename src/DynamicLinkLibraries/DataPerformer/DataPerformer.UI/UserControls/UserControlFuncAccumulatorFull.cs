﻿using System;
using System.Windows.Forms;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Full control of function accumulator
    /// </summary>
    public partial class UserControlFuncAccumulatorFull : UserControl
    {
        #region Fields

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlFuncAccumulatorFull()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members

        internal FunctionAccumulator Function
        {
            get
            {
                return userControlFuncAccumulator.Function;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                userControlFuncAccumulator.Function = value;
                userControlEventBlock.Block = value;
            }
        }


        internal event Action OnSave
        {
            add
            {
                userControlFuncAccumulator.OnSave += value;
            }
            remove
            {
                userControlFuncAccumulator.OnSave -= value;
            }
        }

        #endregion
    }
}
