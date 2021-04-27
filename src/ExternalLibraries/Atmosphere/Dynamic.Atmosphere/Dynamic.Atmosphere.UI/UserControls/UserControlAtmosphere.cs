using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;

namespace Dynamic.Atmosphere.UI.UserControls
{
    public partial class UserControlAtmosphere : UserControl
    {
        Portable.Atmosphere atmosphere;

        private TextBox[] tb;


        public UserControlAtmosphere()
        {
            InitializeComponent();
            tb = new TextBox[] { textBox1, textBox2, textBox3 };
        }

        internal Portable.Atmosphere Atmosphere
        {
            set
            {
                atmosphere = value;
                int[] iff = atmosphere.If;
                for (int i = 0; i < iff.Length; i++)
                {
                    tb[i].Text = iff[i] + "";
                }
            }
        }


        void Accept()
        {
            try
            {
                int[] k = new int[3];
                for (int i = 0; i < k.Length; i++)
                {
                    k[i] = Int32.Parse(tb[i].Text);
                }
                atmosphere.If = k;
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
           Accept();
        }
    }
}
