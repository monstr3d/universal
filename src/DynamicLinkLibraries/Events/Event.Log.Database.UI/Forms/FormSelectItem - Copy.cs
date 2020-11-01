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
using Event.Log.Database.Interfaces;
using Event.Log.Database.UI.UserControls;

namespace Event.Log.Database.UI.Forms
{
    public partial class FormSelectItem : Form
    {
        ILogData selected = null;

        public FormSelectItem()
        {
            InitializeComponent();
            Icon = StaticExtensionEventLogDatabaseUI.ImageList.Images[3].ToIcon();
        }

        public FormSelectItem(bool files) : 
            this()
        {
            UserControlDataBaseTreeSelect uc = new UserControlDataBaseTreeSelect(true);
            uc.ChangeNode += ChangeNode;
            uc.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(uc);
       }

        public ILogData Selected
        {
            get
            {
                return selected;
            }
        }

        void ChangeNode(TreeNode node)
        {
            selected = node.Tag as ILogData;
            buttonOK.Enabled = (selected != null);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            selected = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
