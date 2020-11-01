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
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using Event.Log.Database.UI.UserControls;

namespace Event.UI.Forms
{
    public partial class FormLogEdit : Form, IUpdatableForm
    {
        IObjectLabel label;

        Portable.LogHolder log;

        public FormLogEdit()
        {
            InitializeComponent();
            FormClosed += FormLogEdit_FormClosed;
            Load += FormLogEdit_Load;
        }

     
        internal FormLogEdit(IObjectLabel label) : this()
        {
            this.label = label;
            log = label.Object as Portable.LogHolder;
        }

        public void UpdateFormUI()
        {
            if (label != null)
            {
                Text = label.Name;
            }
        }

        private void FormLogEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (label is Control)
            {
                UserControlDataBaseTreeSelect sel =
                    (label as Control).FindChild<UserControlDataBaseTreeSelect>();
                if (sel != null)
                {
                    sel.Fill();
                }
            }
        }

        private void FormLogEdit_Load(object sender, EventArgs e)
        {
            
            UserControlDataBaseTreeSelect sel =
                   this.FindChild<UserControlDataBaseTreeSelect>();
            if (sel != null)
            {
                sel.Log = log;
                sel.Fill();
            }
        }

    }
}
