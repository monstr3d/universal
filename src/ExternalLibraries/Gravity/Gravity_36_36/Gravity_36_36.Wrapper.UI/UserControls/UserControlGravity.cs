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
using ErrorHandler;

namespace Gravity_36_36.Wrapper.UI.UserControls
{
    /// <summary>
    /// User control for gravity
    /// </summary>
    public partial class UserControlGravity : UserControl
    {

        #region Fields

        Serializable.Gravity gravity;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlGravity()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal and Private Members

        internal Serializable.Gravity Gravity
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                gravity = value;
                textBoxUrl.Text = (gravity as Web.Interfaces.IUrlProvider).Url;
                refresh();
            }
        }


        private void refresh()
        {
            textBoxR.Text = gravity.MUR[0] + "";
            textBoxMu.Text = gravity.MUR[1] + "";
            textBoxMu1.Text = gravity.MUR[2] + "";
            numericUpDownM.Value = gravity.NK;
            numericUpDownN.Value = gravity.N0;
            double[] C = gravity.Cnm;
            double[] S = gravity.Snm;
            int k = 0;
            int n0 = gravity.N0;
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
            gravity.LoadFromFile(openFileDialogField.FileName);
            refresh();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }


        private void buttonAccept_Click(object sender, EventArgs e)
        {
            (gravity as Web.Interfaces.IUrlConsumer).Url =
                textBoxUrl.Text;
            gravity.N0 = (int)numericUpDownN.Value;
            gravity.NK = (int)numericUpDownM.Value;
            refresh();
        }


        private void textBoxUrl_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                (gravity as Web.Interfaces.IUrlConsumer).Url =
                    textBoxUrl.Text;
                refresh();
            }
            catch (Exception exception)
            {
                exception.HandleException(10);
            }
        }

        #endregion

    }
}
