using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for generating char by number
    /// </summary>
    public partial class UserControlCharNumber : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCharNumber()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string Char
        {
            get
            {
                return labelChar.Text;
            }
            set
            {
                labelChar.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int Value
        {
            get
            {
                return (int)numericUpDownNumber.Value;
            }
            set
            {
                numericUpDownNumber.Value = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int Minimum
        {
            get
            {
                return (int)numericUpDownNumber.Minimum;
            }
            set
            {
                numericUpDownNumber.Minimum = value;
            }
        }
    }
}