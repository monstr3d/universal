using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Collada.FileLoader
{
    public partial class FormScale : Form
    {
        double scale = 1;
        public FormScale()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal new double Scale
        {
            get
            {
                return scale;
            }
        }

        private void FormScale_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                scale = Double.Parse(textBox.Text);
            }
            finally
            {
            }
        }
    }
}
