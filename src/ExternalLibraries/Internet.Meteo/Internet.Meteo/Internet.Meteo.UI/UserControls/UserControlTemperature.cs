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
    public partial class UserControlTemperature : UserControl
    {

        Wrapper.Sensor sensor;
        public UserControlTemperature()
        {
            InitializeComponent();
        }


        internal Wrapper.Sensor Sensor
        {
            get => sensor;
            set => sensor = value;

        }
    }
}
