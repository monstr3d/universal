using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Utils;
using DataPerformer.Interfaces;
using DataPerformer.Portable;


namespace DataPerformer.UI
{
    /// <summary>
    /// Colored chooser of collection points
    /// </summary>
    public partial class ColoredChooser : UserControl, IPointCollecionChooser
    {
        #region Fields
        private ComboBox[] boxes;

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ColoredChooser Object = new ColoredChooser();

        #endregion

        #region Ctor

        internal ColoredChooser()
        {
            InitializeComponent();
            boxes = new ComboBox[] { comboBoxX, comboBoxY, comboBoxR, comboBoxG, comboBoxB, comboBoxS };
        }

        #endregion

        #region IPointCollecionChooser Members

        List<string> IPointCollecionChooser.Measurements
        {
            get
            {
                List<string> l = new List<string>();
                foreach (ComboBox box in boxes)
                {
                    string s = box.SelectedItem + "";
                    if (s.Length == 0)
                    {
                        throw new Exception("Undefined measure");
                    }
                    l.Add(s);
                }
                return l;
            }
            set
            {
                for (int i = 0; i < value.Count & i < boxes.Length; i++)
                {
                    boxes[i].SelectCombo(value[i]);
                }
            }
        }

        IDataConsumer IPointCollecionChooser.Consumer
        {
            set 
            {
                Double a = 0;
                List<string> mea = value.GetAllMeasurements(a);
                foreach (ComboBox box in boxes)
                {
                    box.FillCombo(mea);
                }
            }
        }

        #endregion
    }
}
