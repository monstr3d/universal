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

namespace Internet.Meteo.UI.UserControls
{
    public partial class UserControlTemperatureFull : UserControl
    {

        TextBox[] children = new TextBox[5];

        SensorLabel sensorLabel;

        Sensor sensor;
        public UserControlTemperatureFull()
        {
            InitializeComponent();
            for (int i = 0; i < children.Length; i++)
            {
                var t = new TextBox();
                t.BorderStyle = BorderStyle.FixedSingle;
                children[i] = t;
            }
            userControlListItems.Children = children;
            children[0].UseSystemPasswordChar = true;
            children[0].PasswordChar = '*';
        }

        internal void Set(SensorLabel sensorLabel)
        {
            this.sensorLabel = sensorLabel;
            sensor = sensorLabel.Object as Sensor;
            children[0].Text = sensor.Key;
            children[1].Text = sensor.Position;
            children[2].Text = sensorLabel.Min + "";
            children[3].Text = sensorLabel.Max + "";
            children[4].Text = sensorLabel.Step + "";
        }

        internal void Set()
        {
            sensor.Key = children[0].Text;
            sensor.Position = children[1].Text;
            float a;
            if (float.TryParse(children[2].Text, out a))
            {
                sensorLabel.Min = a;
            }
            if (float.TryParse(children[3].Text, out a))
            {
                sensorLabel.Max = a;
            }
            if (float.TryParse(children[4].Text, out a))
            {
                sensorLabel.Step = a;
            }
         }
    }
}
