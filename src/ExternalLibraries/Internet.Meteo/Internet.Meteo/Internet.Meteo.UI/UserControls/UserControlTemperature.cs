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
            set => sensor = value;

        }

    }
}
