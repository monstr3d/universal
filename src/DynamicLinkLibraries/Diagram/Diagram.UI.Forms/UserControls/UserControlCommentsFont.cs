using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Comments with Font component
    /// </summary>
    public partial class UserControlCommentsFont : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCommentsFont()
        {
            InitializeComponent();
        }


    /*    /// <summary>
        /// Accepts comments
        /// </summary>
        public event AcceptComments AcceptComments
        {
            add
            {
                userControlComments.AcceptComments += value;
            }
            remove
            {
                userControlComments.AcceptComments -= value;
            }
        }
        */

        /// <summary>
        /// Autosave sign
        /// </summary>
        public bool AutoSave
        {
            get
            {
                return userControlComments.AutoSave;
            }
            set
            {
                userControlComments.AutoSave = value;
            }
        }

        private void toolStripButtonFont_Click(object sender, EventArgs e)
        {
            userControlComments.SetFont();
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            userControlComments.Controls.Clear();
        }
    }
}
