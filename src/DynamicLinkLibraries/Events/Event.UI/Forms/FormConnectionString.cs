using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;

namespace Event.UI.Forms
{
    public partial class FormConnectionString : Form
    {
        public FormConnectionString()
        {
            InitializeComponent();
            textBox.Text = Log.Database.StaticExtensionEventLogDatabase.ConnectionString;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string conn = textBox.Text;
            if (conn.Equals(Log.Database.StaticExtensionEventLogDatabase.ConnectionString))
            {
                MessageBox.Show(this, "Connection is already established");
                return;
            }
            try
            {
                Log.Database.StaticExtensionEventLogDatabase.ConnectionString = conn;
                Close();
            }
            catch (Exception exception)
            {
                Log.Database.StaticExtensionEventLogDatabase.ConnectionString = "";
                exception.ShowError();
            }
        }
            
     

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
