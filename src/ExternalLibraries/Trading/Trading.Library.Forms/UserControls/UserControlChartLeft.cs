using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trading.Library.Forms.UserControls
{
    public partial class UserControlChartLeft : UserControl
    {
        public UserControlChartLeft()
        {
            InitializeComponent();
        }

        private void panelCenter_Resize(object sender, EventArgs e)
        {
            panelChart.Width = Width;
            panelChart.Height = Height;
        }
    }
}
