using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Internet.Meteo.UI.Labels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internet.Meteo.UI.Forms
{
    public partial class FormTemperature : Form, IUpdatableForm
    {

        SensorLabel sensorLabel;
        public FormTemperature()
        {
            InitializeComponent();
        }

        public FormTemperature(SensorLabel sensorLabel) : this()
        {
            this.sensorLabel = sensorLabel;
            userControlTemperatureFull.Set(sensorLabel);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            userControlTemperatureFull.Set();
        }

        public void UpdateFormUI()
        {
            Text = (sensorLabel as IObjectLabel).Name;
        }
    }
}
