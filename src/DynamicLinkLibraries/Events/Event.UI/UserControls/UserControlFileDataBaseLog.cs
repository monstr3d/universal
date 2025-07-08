using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Event.Log.Database.UI.UserControls;

namespace Event.UI.UserControls
{
    public partial class UserControlFileDataBaseLog : UserControl
    {
        UserControlDataBaseTreeSelect uc;
        public UserControlFileDataBaseLog()
        {
            InitializeComponent();
        }

        private void UserControlFileDataBaseLog_Load(object sender, EventArgs e)
        {
            UserControlDataBaseTreeSelect uc = new UserControlDataBaseTreeSelect();
            uc.Dock = DockStyle.Fill;
            panelDataBase.Controls.Add(uc);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string FileName
        {
            set
            {
                userControlFileLog.FileName = value;
                if (File.Exists(value))
                {
                    tabControl.SelectedTab = tabPageFile;
                }
                else
                {
                    tabControl.SelectedTab = tabPageDatabase;
                }
            }
        }
    }
}
