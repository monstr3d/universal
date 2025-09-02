using Chart;
using DataPerformer.Interfaces;
using Diagram.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace DataPerformer.UI.UserControls
{
    public partial class UserControlMeasurement : UserControl
    {
        public UserControlMeasurement()
        {
            InitializeComponent();
            this.Execute<Control>((c) => c.ContextMenuStrip = contextMenuStrip);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color[] Color
        {
            get => checkBoxName.Checked ? [comboBoxColorPicker.Color] : null;
            set => SetColor(value);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IMeasurement Measurement { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MeasurementName
        {
            set => checkBoxName.Text = value;
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
