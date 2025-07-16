using System;
using System.ComponentModel;
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


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            var a = () =>
            {
                textBox.Enabled = !obj;
            };
            this.InvokeIfNeeded(a);
        }


        private void Sensor_OnValueChange(object[] obj)
        {
            this.InvokeIfNeeded(ChangeValue, obj);
        }

        private void ChangeValue(object[] value)
        {
            double a = (double)value[0];
            term.Set((float)a);
        }


        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (sensor.Position == textBox.Text)
            {
                return;
            }
            sensor.Position = textBox.Text;
        }
    }
}
