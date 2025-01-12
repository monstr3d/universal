using System;

using System.Windows.Forms;

namespace Internet.Meteo.UI.UserControls
{
    public partial class UserControlAll : UserControl
    {
        Sensor sensor;

        TextBox key = new TextBox();

        TextBox pos = new TextBox();

        public UserControlAll()
        {
            InitializeComponent();
        }

        internal Sensor Sensor
        {
            set
            {
                sensor = value;
                key.UseSystemPasswordChar = true;
                key.PasswordChar = '*';
                userControlListItems.Children = [key, pos];
                key.Text = sensor.Key;
                key.TextChanged += Key_TextChanged;
                pos.Text = sensor.Position;
                pos.TextChanged += Pos_TextChanged;
                if (sensor.FahrenheitCelsius == FahrenheitCelsius.Fahrenheit)
                {
                    radioButtonFahrenheit.Checked = true;
                }
                else
                {
                    radioButtonCelsius.Checked = true;
                }
                radioButtonCelsius.CheckedChanged += RadioButton_CheckedChanged;
            }
        }

        private void Key_TextChanged(object sender, EventArgs e)
        {
            sensor.Key = key.Text;
        }


        private void Pos_TextChanged(object sender, EventArgs e)
        {
            sensor.Position = pos.Text;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCelsius.Checked)
            {
                sensor.FahrenheitCelsius = FahrenheitCelsius.Celsius;
            }
            else
            {
                sensor.FahrenheitCelsius = FahrenheitCelsius.Fahrenheit;
            }
        }
    }
}