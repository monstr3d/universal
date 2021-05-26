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

namespace Gravity36.Wrapper.UI.UserControls
{
    /// <summary>
    /// Edit control
    /// </summary>
    public partial class UserControlEdit : UserControl
    {
        #region Fields

        Gravity36.Wrapper.Gravity grav;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region Members

        internal Gravity36.Wrapper.Gravity Gravity
        {
            set
            {
                if (value == null)
                {
                    return;
                 }
                grav = value;
                textBoxUrl.Text = (grav as Web.Interfaces.IUrlProvider).Url;
                refresh();
            }
        }


        private void refresh()
        {
            textBoxR.Text = grav.GravityField.MUR[0] + "";
            textBoxMu.Text = grav.GravityField.MUR[1] + "";
            textBoxMu1.Text = grav.GravityField.MUR[2] + "";
            numericUpDownM.Value = grav.GravityField.NK;
            numericUpDownN.Value = grav.GravityField.N0;
            double[] C = grav.GravityField.Cnm;
            double[] S = grav.GravityField.Snm;
            int k = 0;
            int n0 = grav.GravityField.N0;

            listViewHarm.Items.Clear();
            for (int i = 0; i <= n0; i++)
            {
                int p = i;
                if (p < 2)
                {
                    p = 2;
                }
                for (int j = p; j <= n0; j++)
                {
                    ListViewItem it = new ListViewItem(new string[] { i + "", j + "", C[k] + "", S[k] + "" });
                    listViewHarm.Items.Add(it);
                    ++k;
                }
            }
        }

        #endregion

        #region Event Hamdlers

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogField.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            grav.LoadFromFile(openFileDialogField.FileName);
            refresh();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }


        private void buttonAccept_Click(object sender, EventArgs e)
        {
            (grav as Web.Interfaces.IUrlConsumer).Url =
                textBoxUrl.Text;
            grav.GravityField.N0 = (int)numericUpDownN.Value;
            grav.GravityField.NK = (int)numericUpDownM.Value;
            refresh();
        }

 
        private void textBoxUrl_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                (grav as Web.Interfaces.IUrlConsumer).Url =
                    textBoxUrl.Text;
                refresh();
            }
            catch (Exception exception)
            {
                exception.ShowError(10);
            }
        }

        #endregion
    }
}
