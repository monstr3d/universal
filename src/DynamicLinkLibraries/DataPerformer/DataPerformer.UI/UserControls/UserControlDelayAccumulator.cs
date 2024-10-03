using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Utils;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Control for delay accumulator
    /// </summary>
    public partial class UserControlDelayAccumulator : UserControl, IPostSetArrow
    {
        #region Fields

        ComboBox cb;

        NumericUpDown count;

        NumericUpDown deg;

        DataPerformer.Advanced.DynamicFunction func;

        private bool postSet = true;

        private bool initEvents = true;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlDelayAccumulator()
        {
            InitializeComponent();
            userControlEditList.Types = new Type[] { typeof(ComboBox), typeof(NumericUpDown), typeof(NumericUpDown) };
            cb = userControlEditList[0] as ComboBox;
            count = userControlEditList[1] as NumericUpDown;
            deg = userControlEditList[2] as NumericUpDown;
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            if (postSet)
            {
                Post();
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Associated function
        /// </summary>
        public DataPerformer.Advanced.DynamicFunction Function
        {
            get
            {
                return func;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (func != null)
                {
                    throw new Exception();
                }
                func = value;
            }
        }

        #endregion

        #region Private

        void Fill()
        {
            postSet = false;
            Double a = 0;
            IDataConsumer dc = func;
            IList<string> l = dc.GetAllMeasurementsType(a);
            cb.Items.Clear();
            cb.FillCombo(l);
        }

        private void InitEvents()
        {
            if (!initEvents)
            {
                return;
            }
            initEvents = false;
            cb.SelectedIndexChanged += SelectedIndexChanged;
            count.ValueChanged += CountChanged;
            deg.ValueChanged += DegreeChanged;
        }

        private void Post()
        {
            if (func == null)
            {
                return;
            }
            Fill();
            cb.SelectCombo(func.Argument);
            count.Value = func.Size;
            deg.Value = func.Degree;
            InitEvents();
        }

        #region Event Handlers

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PerformWithMessageBox(() =>
            {
                object o = cb.SelectedItem;
                if (o == null)
                {
                    return;
                }
                func.Argument = o + "";
            });
        }

        private void CountChanged(object sender, EventArgs e)
        {
            this.PerformWithMessageBox(() => { func.Size = (int)count.Value; });
        }
        
        private void DegreeChanged(object sender, EventArgs e)
        {
            this.PerformWithMessageBox(() => { func.Degree = (int)deg.Value; });
        }

  
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            Fill();
            InitEvents();
        }

        #endregion


        #endregion



    }
}