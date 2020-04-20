using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Event.UI.UserControls
{
    public partial class UserControlFileLog : UserControl
    {
        public UserControlFileLog()
        {
            InitializeComponent();
        }

        internal string FileName
        {
            set
            {
                if (File.Exists(value))
                {
                    labelFile.Text = value;
                }
                else
                {
                    labelFile.Text = "Drag log file here";
                }
            }
        }
    }
}
