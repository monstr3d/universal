using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using DataPerformer;
using DataPerformer.Interfaces;

namespace DataPerformer.UI
{
    /// <summary>
    /// Panel for measure text
    /// </summary>
    public partial class PanelMeasureText : Panel
    {

        private string name;
        private IDataConsumer consumer;

        private PanelMeasureText()
        {
            InitializeComponent();
        }

        private PanelMeasureText(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="measurements">Measurements</param>
        /// <param name="width">Width</param>
        /// <param name="dic">Ditionary</param>
        /// <param name="name">Name</param>
        /// <param name="selected">The "selected" sign</param>
        public PanelMeasureText(IDataConsumer consumer, IMeasurements measurements, int width, Dictionary<TextBox, IMeasurement> dic, string name,
            Dictionary<string, string> selected)
        {
            this.consumer = consumer;
            this.name = name;
            int y = 0;
            Width = width;
            Panel p = new Panel();
            p.BackColor = Color.Black;
            p.Width = width;
            p.Height = 2;
            p.Left = 0;
            p.Top = y;
            Controls.Add(p);
            y = p.Bottom + 5;
            Control panel = HeaderControl.Object.GetHeaderControl(consumer, measurements);
            panel.Top = y;
            Controls.Add(panel);
            y = panel.Bottom;
            for (int i = 0; i < measurements.Count; i++)
            {
                IMeasurement m = measurements[i];
                Label l = new Label();
                l.Top = y;
                string na = m.Name;
                l.Text = na;
                l.Left = 20;
                Controls.Add(l);
                string sel = name + "." + na;
                y = l.Bottom + 5;
                TextBox tb = new TextBox();
                if (selected.ContainsKey(sel))
                {
                    tb.Text = selected[sel];
                }
                dic[tb] = m;
                tb.Top = l.Top;
                tb.Left = width / 2;
                Controls.Add(tb);
            }
            Height = y;
        }

        /// <summary>
        /// Name of measure
        /// </summary>
        public string MeasureName
        {
            get
            {
                return name;
            }
        }
    }
}
