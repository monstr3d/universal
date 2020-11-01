using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event.Log.Database.UI.UserControls
{
    public partial class UserControlDatabaseSelectEdit : UserControl
    {

        UserControlDataBaseTreeSelect select;
        UserControlEditDatadase edit;

        public UserControlDatabaseSelectEdit()
        {
            InitializeComponent();
        }

        private void UserControlDatabaseSelectEdit_Load(object sender, EventArgs e)
        {
            
            select = new UserControlDataBaseTreeSelect();
            edit = new UserControlEditDatadase();
            select.Dock = DockStyle.Fill;
            panelCenterSelect.Controls.Add(select);
            edit.Dock = DockStyle.Fill;
            panelCenterEdit.Controls.Add(edit);
            tabControl.SelectedIndex = 1;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (select != null)
            {
                select.Fill();
            }
        }
    }
}
