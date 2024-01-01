using System;
using System.Windows.Forms;

using DataPerformer.Portable;
using DataPerformer.Portable.Filters;
using Diagram.UI.Interfaces;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlDonchian : UserControl, IPostSet
    {
        Base.Filters.FilterWrapper filterWrapper;

        public UserControlDonchian()
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
                filterWrapper = value;
                if (filterWrapper.Kind != "Donchian") { throw new Exception(); }
                filterWrapper.OnChangeInput += FilterWrapper_OnChangeInput;
                numericUpDownCount.Value = filterWrapper.Filter.Count;
                checkBoxMaximum.Checked = (filterWrapper.Filter as Donchian).Max;
            }
        }

        private void CheckBoxMaximum_CheckedChanged(object sender, EventArgs e)
        {
            (filterWrapper.Filter as Donchian).Max = checkBoxMaximum.Checked;
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
            FilterWrapper_OnChangeInput();
            comboBoxInput.SelectedIndexChanged += ComboBoxInput_SelectedIndexChanged;
            numericUpDownCount.ValueChanged += NumericUpDownCount_ValueChanged;
            checkBoxMaximum.CheckStateChanged += CheckBoxMaximum_CheckedChanged;
            Disposed += UserControlDonchian_Disposed;  
        }

        private void UserControlDonchian_Disposed(object sender, EventArgs e)
        {
            filterWrapper.OnChangeInput -= FilterWrapper_OnChangeInput;
        }

        private void FilterWrapper_OnChangeInput()
        {
            var meas = filterWrapper.GetAllMeasurements((double)0);
            comboBoxInput.Items.Clear();
            comboBoxInput.Items.AddRange(meas.ToArray());
            for (int i = 0; i < meas.Count; i++)
            {
                if (meas[i] == filterWrapper.Input)
                {
                    comboBoxInput.SelectedIndex = i;
                    break;
                }
            }

        }
    }
}
