using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DataPerformer;
using DataPerformer.Interfaces;


using Chart.Drawing.Series;

using Chart;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for measure
    /// </summary>
    public partial class UserControlMeasure : UserControl
    {

        #region Fields

        Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
            Dictionary<string, string>, string[], int[], Tuple<double[],
            Dictionary<string, Dictionary<string,
            Tuple<Color[], bool, double[]>>>>[]> data = null;

        IMeasurement measure;

        private Dictionary<IMeasurement, object> dict;

        private string parent;

  
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlMeasure()
        {
            InitializeComponent();
            this.LoadResources();
        }

        #endregion

        #region Internal Members

        internal Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
            Dictionary<string, string>, string[], int[],
             Tuple<double[],
            Dictionary<string, Dictionary<string,
            Tuple<Color[], bool, double[]>>>>[]> Data
        {
            set
            {
                if (data != null)
                {
                    throw new ErrorHandler.OwnException();
                }
                data = value;
                string s = parent + "." + measure.Name;
                if (value.Item1.ContainsKey(s))
                {
                    Color[] c = value.Item1[s];
                    comboBoxColorPicker.Color = c[0];
                    checkBoxMeasure.Checked = true;
                }
                 if (value.Item2.ContainsKey(s))
                {
                    checkBoxStep.Checked = value.Item2[s];
                }

            }
        }

        internal string ParentName
        {
            set
            {
                parent = value;
            }
        }

        internal IMeasurement Measure
        {
            get
            {
                return measure;
            }
            set
            {
                measure = value;
                checkBoxMeasure.Text = measure.Name;
            }
        }

        internal Dictionary<IMeasurement, object> Dictionary
        {
            set
            {
                dict = value;
            }
        }

        internal void Add(Dictionary<IMeasurement, Color[]> d)
        {
            if (measure == null)
            {
                return;
            }
            string s = parent + "." + measure.Name;
            if (checkBoxMeasure.Checked)
            {
                Color[] col = new Color[] { comboBoxColorPicker.Color };
                d[measure] = col;
                data.Item1[s] = col;
                data.Item2[s] = checkBoxStep.Checked;
                return;
            }
            if (!d.ContainsKey(measure))
            {
                d.Remove(measure);
                if (data.Item1.ContainsKey(s))
                {
                    data.Item1.Remove(s);
                }
                if (data.Item2.ContainsKey(s))
                {
                    data.Item2.Remove(s);
                }
            }
        }
      
        internal void Add(Dictionary<string, IMeasurement> d)
        {
            string s = parent + "." + measure.Name;
            d[s] = measure;
        }

        #endregion

        #region Private Members

        private DataPerformer.Series PrivateSeries
        {
            get
            {
                if (dict == null)
                {
                    "Series is not calculated yet".ShowLocalized();
                    return null;
                }
                if (!dict.ContainsKey(measure))
                {
                    return null;
                }
                object o = dict[measure];
                if (o == null)
                {
                    return null;
                }
                if (o is DataPerformer.Series)
                {
                    return o as DataPerformer.Series;
                }
                return null;
            }
        }

        #endregion

        #region Event Handlers

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrivateSeries != null)
            {
                StaticExtensionDataPerformerUI.CopyToClipboard(PrivateSeries);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrivateSeries != null)
            {
                StaticExtensionDataPerformerUI.Save(PrivateSeries, this);
            }
        }

        #endregion

    }
}
