using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Motion6D.UI.UserControls
{

    /// <summary>
    /// User conrol for quaternion editor
    /// </summary>
    public partial class UserControlQuaternion : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlQuaternion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets Pitch, Roll, Hunting
        /// </summary>
        public void SetPitchRollHunting()
        {
            userControlComboboxListLeft.Count = 3;
            userControlComboboxListLeft.Texts = new string[] { "Pitch", "Roll", "Hunting" };
        }

        internal ComboBox[] Boxes
        {
            get
            {
                return userControlComboboxListLeft.Boxes.ToArray();
            }
        }

    }
}
