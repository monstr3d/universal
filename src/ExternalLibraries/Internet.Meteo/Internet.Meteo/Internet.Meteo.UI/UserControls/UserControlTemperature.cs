using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsExtensions;

namespace Internet.Meteo.UI.UserControls
{
    public partial class UserControlTemperature : UserControl
    {

        Wrapper.Sensor sensor;


        bool changing = false;

        float min, max, step;
        public UserControlTemperature(float min, float max, float step)
        {
            InitializeComponent();
            this.min = min;
            this.max = max;
            this.step = step;
        }


        internal Wrapper.Sensor Sensor
        {
            get => sensor;
            set
            {
                sensor = value;
                textBox.Text = sensor.Position;
                sensor.OnValueChange += Sensor_OnValueChange;
                sensor.OnEnabledChange += Sensor_OnEnabledChange;
            }

        }

        private void Sensor_OnEnabledChange(bool obj)
        {
            textBox.Enabled = !obj;
        }


        private void Sensor_OnValueChange(double obj)
        {
            this.InvokeIfNeeded(ChangeValue, obj);
        }

        private void ChangeValue(double value)
        {
            term.Set((float)value);
        }


        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (changing)
            {
                return;
            }
            int i = 0;
            sensor.Position = textBox.Text;
            changing = true;
            changing = false;
        }
    }
}
