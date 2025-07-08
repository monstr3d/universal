using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Utils;

using DataPerformer;
using DataPerformer.Advanced.Accumulators;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Editor of properties of accumulator series
    /// </summary>
    public partial class UserControlAccumulatorSeriesArgument : UserControl
    {
        #region Fields

        NumericUpDown ndeg;

        ComboBox cb;

        AccumulatorSeriesArgument acc;

        #endregion
        
        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlAccumulatorSeriesArgument()
        {
            InitializeComponent();
            userControlEditList.Types = new Type[] { typeof(ComboBox), typeof(NumericUpDown) };
            cb = userControlEditList.GetControl<ComboBox>(0);
            ndeg = userControlEditList.GetControl<NumericUpDown>(1);
            cb.Text = "<Points>";
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Accumulator
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AccumulatorSeriesArgument Accumulator
        {
            get
            {
                return acc;
            }
            set
            {
                acc = value;
                Fill();
            }
        }


        #endregion


        #region Private Members

        internal void Fill()
        {
            if (cb.Items.Count == 0)
            {
                if (acc != null)
                {
                    string[] s = acc.GetOneDimensionRealArrays();
                    if (s.Length > 0)
                    {
                        cb.FillCombo(s);
                        if (acc.Argument != null)
                        {
                            cb.SelectCombo(acc.Argument);
                        }
                        cb.SelectedValueChanged += (object ob, EventArgs e) =>
                            {
                                object o = cb.SelectedItem;
                                if (o != null)
                                {
                                    acc.Argument = o + "";
                                }
                            };
                        ndeg.Value = acc.Degree;
                        ndeg.ValueChanged += (object ob, EventArgs e) =>
                        {
                            acc.Degree = (int)ndeg.Value;
                       };
                    }
                }
            }
        }

        #endregion

   
        #region Event Handlers

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            Fill();
        }

        #endregion

    }
}
