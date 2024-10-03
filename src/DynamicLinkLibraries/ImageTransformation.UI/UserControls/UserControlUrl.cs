using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;

namespace ImageTransformations.UserControls
{
    public partial class UserControlUrl : UserControl
    {
        public UserControlUrl()
        {
            InitializeComponent();
        }

        public string Url
        {
            set
            {
                if (!value.IsEmpty())
                {
                   webBrowser.Url = new Uri(value);
                }
            }
        }
    }
}
