using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using DataPerformer.Interfaces;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Realtime measure editor
    /// </summary>
    public partial class UserControlRealtimeMeasure : UserControl
    {
        #region Fields

        IMeasurement measure;

        Dictionary<IMeasurement, Tuple<Color[], bool, double[]>> dictionary;

        TextBox[] boxes;

        string parentName;

  
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlRealtimeMeasure()
        {
            InitializeComponent();
            boxes = new TextBox[]{ textBoxMin, textBoxMax};
            this.LoadResources();
        }

        #endregion

        #region Internal Members

        internal string ParentName
        {
            get
            {
                return parentName;
            }
            set
            {
                parentName = value;
            }
        }

        internal Dictionary<IMeasurement, Tuple<Color[], bool, double[]>> Dictionary
        {
            get
            {
                return dictionary;
            }
            set
            {
                dictionary = value;
                Get();
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
                Get();
            }
        }

        internal void Set()
        {
            if (!checkBox.Checked)
            {
                if (dictionary.ContainsKey(measure))
                {
                    dictionary.Remove(measure);
                }
                return;
            }
            dictionary[measure] = Tuple;
        }

        internal Tuple<Color[],bool,double[]> Tuple
        {
            get
            {
                if (!checkBox.Checked)
                {
                    if (dictionary.ContainsKey(measure))
                    {
                        dictionary.Remove(measure);
                    }
                    return null;
                }
              Tuple<Color[], bool, double[]> t =   new Tuple<Color[], bool, double[]>
                (new Color[] { comboBoxColorPicker.Color }, checkBoxStep.Checked,  new double[]
                { double.Parse(textBoxMin.Text), double.Parse(textBoxMax.Text)});
                dictionary[measure] = t;
                return t;
            }
            set
            {
                checkBox.Checked = true;
                comboBoxColorPicker.Color = value.Item1[0];
                checkBoxStep.Checked = value.Item2;
                double[] d = value.Item3;
                textBoxMin.Text = d[0] + "";
                textBoxMax.Text = d[1] + "";
            }
        }

        void Get()
        {
            if (measure == null)
            {
                return;
            }
            if (dictionary == null)
            {
                return;
            }
            if (dictionary.ContainsKey(measure))
            {
                Tuple = dictionary[measure];
            }
            checkBox.Text = measure.Name;
        }

        #endregion

        #region Event Handlers

        private void panelSpit_Resize(object sender, EventArgs e)
        {
            int k = (splitContainer.Panel1.Width + splitContainer.Panel2.Width);
            splitContainer.SplitterDistance = k / 2;
        }

        #endregion

    }
}
