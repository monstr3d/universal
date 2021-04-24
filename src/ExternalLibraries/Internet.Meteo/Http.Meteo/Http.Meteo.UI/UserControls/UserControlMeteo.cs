using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Http.Meteo.UI.UserControls
{
    public partial class UserControlMeteo : UserControl
    {
        #region Fields

        object obj;

        PropertyInfo pi;

        PropertyInfo pin;

        PropertyInfo pt;

        string html;

        static private readonly DateTime baseTime = new DateTime(2000, 1, 1);

        #endregion


        #region Ctor

        public UserControlMeteo()
        {
            InitializeComponent();

        }

        #endregion


        #region Members


        internal object Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
                pi = obj.GetType().GetProperty("Url");
                pin = obj.GetType().GetProperty("Html");
                pt = obj.GetType().GetProperty("TimeSpan");
                TimeSpan ts = (TimeSpan)pt.GetValue(obj);
                textBoxInterval.Text = ts + "";
                webBrowser.Url = new Uri(Url);

            }
        }

        string Url
        {
            get
            {
                return pi.GetValue(obj, null) + "";
            }
            set
            {
                pi.SetValue(obj, value, null);
            }
        }

        #endregion

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string s = webBrowser.Url + "";
            if (s.Equals(Url))
            {
                return;
            }
            string html = webBrowser.Document.Body.InnerHtml;
            pin.SetValue(obj, html, null);
            Url = s;
        }


        private void textBoxInterval_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    pt.SetValue(obj, TimeSpan.Parse(textBoxInterval.Text));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
