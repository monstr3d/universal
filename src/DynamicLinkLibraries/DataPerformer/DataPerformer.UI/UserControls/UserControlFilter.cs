﻿using DataPerformer.Base.Filters;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Filters;
using Diagram.UI.Interfaces;
using Diagram.UI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Internal;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlFilter : UserControl, IPostSet
    {
        Base.Filters.FilterWrapper filterWrapper;

  
        public UserControlFilter()
        {
            InitializeComponent();
        }



        internal Base.Filters.FilterWrapper Filter
        {
            get => filterWrapper;
            set
            {
                if (value == null) { return; }
                if (filterWrapper != null) { throw new Exception(); }
                if (!(value is Base.Filters.FilterWrapper)) { throw new Exception(); }
                filterWrapper = value;
                switch (filterWrapper.Kind)
                {
                    case 0: 
                        radioButtonAverage.Checked = true;
                        break;
                    case 1:
                        radioButtonDonchianMaximum.Checked = true;
                        break;
                    case 2:
                        radioButtonDonchianMinimum.Checked = true;
                        break;
                        default: throw new Exception();

                          
                }
                radioButtonAverage.CheckedChanged += CheckedChanged;
                radioButtonDonchianMinimum.CheckedChanged += CheckedChanged;
                radioButtonDonchianMaximum.CheckedChanged += CheckedChanged;
                numericUpDownCount.Value = filterWrapper.Filter.Count;
                filterWrapper.OnChangeInput += FilterWrapper_OnChangeInput;
                Disposed += UserControl_Disposed;
            }
        }

     
        private void CheckedChanged(object sender, EventArgs e)
        {
            int k = radioButtonAverage.Checked ? 0 : radioButtonDonchianMaximum.Checked ? 1 :  2;
            filterWrapper.Kind = k;
        }

        private void NumericUpDownCount_ValueChanged(object sender, EventArgs e)
        {
            filterWrapper.Filter.Count = (int)numericUpDownCount.Value;
        }

        private void ComboBoxInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            var o = comboBoxInput.SelectedItem;
            if (o != null)
            {
                filterWrapper.Input = o.ToString();
            }
        }

        void IPostSet.Post()
        {
            filterWrapper.OnChangeInput -= FilterWrapper_OnChangeInput;
            FillComboBox();
            comboBoxInput.SelectedIndexChanged += ComboBoxInput_SelectedIndexChanged;
            numericUpDownCount.ValueChanged += NumericUpDownCount_ValueChanged;
            filterWrapper.OnChangeInput += FilterWrapper_OnChangeInput;
        }

        private void UserControl_Disposed(object sender, EventArgs e)
        {
            filterWrapper.OnChangeInput -= FilterWrapper_OnChangeInput;
        }

        void SelectComboBox()
        {
            comboBoxInput.SelectCombo(filterWrapper.Input);
        }

        void FillComboBox() 
        {
            var meas = filterWrapper.GetAllMeasurements((double)0);
            comboBoxInput.Items.Clear();
            comboBoxInput.FillCombo(meas);
            SelectComboBox();

        }

        private void FilterWrapper_OnChangeInput()
        {
            FillComboBox();
        }
    }
}