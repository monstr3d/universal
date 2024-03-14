using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using DataPerformer.Interfaces;

using Chart;
using Diagram.UI;


namespace DataPerformer.UI.UserControls
{
    public partial class UserControlMeasurement : UserControl
    {
        public UserControlMeasurement()
        {
            InitializeComponent();
            this.Execute<Control>((c) => c.ContextMenuStrip = contextMenuStrip);
        }

        public Color[] Color
        {
            get => checkBoxName.Checked ? [comboBoxColorPicker.Color] : null;
            set => SetColor(value);
        }

        internal IMeasurement Measurement { get; set; }

        public string MeasurementName
        {
            set => checkBoxName.Text = value;
        }


        public Dictionary<IMeasurement, Chart.Drawing.Interfaces.ISeries> Series
        { get; set; }

        void SetColor(Color[] color)
        {
            if (color == null)
            {
                checkBoxName.Checked = false;
                return;
            }
            checkBoxName.Checked = true;
            comboBoxColorPicker.Color = color[0];
        }

        private void copyChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Series != null)
            {
                if (Series.ContainsKey(Measurement))
                {
                    var s = Series[Measurement];
                    s.CopyToClipboard();
                }
            }
        }
    }

}
