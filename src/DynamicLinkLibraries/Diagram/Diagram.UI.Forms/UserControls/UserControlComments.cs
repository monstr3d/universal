using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ToolBox;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Comments user control
    /// </summary>
    public partial class UserControlComments : UserControl
    {
        #region Fields

        private Action<ICollection> acceptComments = (ICollection comments) =>
        {
        };

        private bool autoSave = true;

        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlComments()
        {
            InitializeComponent();
            ControlPanel.AddDrag(this);
        }

        /// <summary>
        /// Sets font
        /// </summary>
        public void SetFont()
        {
            TextBox box = ControlPanel.GetActiveTextBox(this);
            if (box == null)
            {
                return;
            }
            FontDialog dlg = new FontDialog();
            dlg.ShowDialog(this);
            Font font = dlg.Font;
            box.Font = font;
        }

        /// <summary>
        /// Comments
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ICollection Comments
        {
            get
            {
                return ControlPanel.GetControls(this);
            }
            set
            {
                ControlPanel.LoadControls(this, value);
            }

        }

        /// <summary>
        /// Accepts comments
        /// </summary>
        public event Action<ICollection> AcceptComments
        {
            add
            {
                acceptComments += value;
            }
            remove
            {
                acceptComments -= value;
            }
        }

        /// <summary>
        /// Autosave sign
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoSave
        {
            get
            {
                return autoSave;
            }
            set
            {
                autoSave = value;
            }
        }

        /// <summary>
        /// Saves comments
        /// </summary>
        public void Save()
        {
            acceptComments(Comments);
        }
    }
}
