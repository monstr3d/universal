using System;
using System.Windows.Forms;


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
                if (!string.IsNullOrEmpty(value))
                {
                   webBrowser.Url = new Uri(value);
                }
            }
        }
    }
}
