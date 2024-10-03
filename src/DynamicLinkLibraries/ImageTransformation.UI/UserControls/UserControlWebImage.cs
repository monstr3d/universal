using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageTransformations.UserControls
{
    public partial class UserControlWebImage : UserControl
    {
        #region Fields

        event Action<string> setUrl;

        #endregion

        public UserControlWebImage()
        {
            InitializeComponent();
            setUrl += UpdateUrl;
        }


        public event Action<string> SetUrl
        {
            add
            {
                setUrl += value;
            }
            remove
            {
                setUrl -= value;
            }
        }

        public string Url
        {
            get
            {
                return textBoxUrl.Text;
            }
            set
            {
                textBoxUrl.Text = value;
                if (value.Length > 0)
                {
                    webBrowser.Url = new Uri(value);
                }
            }
        }

        private void textBoxUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                setUrl(textBoxUrl.Text);
            }
        }


        private void UpdateUrl(string text)
        {
            if (text.Length > 0)
            {
                webBrowser.Url = new Uri(text);
            }
        }
    }
}
