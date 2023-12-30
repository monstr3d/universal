using DataPerformer.Base.Filters;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Filters;
using Diagram.UI.Interfaces;
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
    public partial class UserControlAverage : UserControl, IPostSet
    {
        Base.Filters.FilterWrapper filterWrapper;

  
        public UserControlAverage()
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
                if (filterWrapper.Kind != "Average") { throw new Exception(); }
           }
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
            var meas = filterWrapper.GetAllMeasurements((double)0);
            comboBoxInput.Items.AddRange(meas.ToArray());
            for (int i = 0; i < meas.Count; i++)
            {
                if (meas[i] != filterWrapper.Input)
                {
                    comboBoxInput.SelectedIndex = i;
                    break;
                }
            }
            comboBoxInput.SelectedIndexChanged += ComboBoxInput_SelectedIndexChanged;
            numericUpDownCount.ValueChanged += NumericUpDownCount_ValueChanged;
        }
    }
}
