using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Diagram.UI.Utils;

using DataPerformer.Portable;
using DataPerformer.Event.Portable.Objects;

namespace DataPerformer.UI.UserControls
{

    /// <summary>
    /// Editor of TimeSeriesMedian
    /// </summary>
    public partial class UserControlTimeSeriesMedian : UserControl
    {
        bool block = false;

        DataPerformer.Interfaces.IDataConsumer dc;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlTimeSeriesMedian()
        {
            InitializeComponent();
        }

        internal TimeSeriesMedian TimeSeriesMedian
        {
            set
            {
                try
                {
                    IList<string> l = value.GetAllMeasurementsType(false);
                    comboBox.Items.Clear();
                    comboBox.FillCombo(l);
                    string s = value.Condition;
                    comboBox.SelectCombo(s);
                    if (dc == null)
                    {
                        comboBox.SelectedIndexChanged += (object sender, EventArgs args) =>
                        {
                            if (block)
                            {
                                return;
                            }
                            object o = comboBox.SelectedItem;
                            if (o == null)
                            {
                                value.Condition = "";
                                return;
                            }
                            value.Condition = o + "";
                        };
                    }
                    dc = value;
                    dc.OnChangeInput += Fill;
                }
                catch
                {

                }
            }
        }

        void Fill()
        {
            block = true;
            IList<string> l = dc.GetAllMeasurementsType(false);
            comboBox.Items.Clear();
            comboBox.FillCombo(l);
            comboBox.SelectCombo((dc as TimeSeriesMedian).Condition);
            block = false;
        }
    }
}