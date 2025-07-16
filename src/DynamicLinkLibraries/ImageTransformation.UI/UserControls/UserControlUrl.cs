using System;
using System.Windows.Forms;
using System.ComponentModel;


namespace ImageTransformations.UserControls
{
    public partial class UserControlUrl : UserControl
    {
        public UserControlUrl()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Url
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                   webBrowser.Url = new Uri(value);
                }
            }
        }
    }
}
