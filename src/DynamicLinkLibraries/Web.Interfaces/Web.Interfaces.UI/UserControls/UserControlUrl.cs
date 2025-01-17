using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;
using ErrorHandler;

namespace Web.Interfaces.UI.UserControls
{
    /// <summary>
    /// Url user control
    /// </summary>
    public partial class UserControlUrl : UserControl, IConstantUrl
    {

        #region Fields

        private Uri uri = null;

        event Action<string> change = (string url) => { };

        object obj = new object();


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlUrl()
        {
            InitializeComponent();
        }

        #endregion

        #region IUrlProvider Members

        string IUrlProvider.Url
        {
            get 
            {
                if (webBrowserResult.Url != null)
                {
                    return webBrowserResult.Url.AbsoluteUri;
                }
                return "";
            }
        }

        event Action<string> IUrlProvider.Change
        {
            add { change += value; }
            remove { change -= value; }
        }

        #endregion

        #region IUrlConsumer Members

        string IUrlConsumer.Url
        {
            set 
            {
                if (value == null)
                {
                    return;
                }
                if (value.Length == 0)
                {
                    return;
                }
                try
                {
                    webBrowserResult.Url = new Uri(value);
                }
                catch (Exception exception)
                {
                    exception.ShowError();
                }
            }
        }

        event Action<string> IUrlConsumer.Change
        {
            add {  }
            remove {  }
        }

        #endregion

        #region IConstantUrl Members

        string IConstantUrl.ConstantUrl
        {
            get
            {
                if (uri == null)
                {
                    return null;
                }
                return uri + "";
            }
            set
            {
                if (uri != null)
                {
                    return;
                }
                uri = new Uri(value);
                webBrowserSearch.Url = uri;
            }
        }

        #endregion
 
        #region Event handlers

        private void webBrowserSearch_DocumentCompleted(object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath.Equals("blank"))
            {
                return;
            }
            if (e.Url.Equals(uri))
            {
                return;
            }
            lock (obj)
            {
                webBrowserResult.Url = e.Url;
                change(e.Url.AbsoluteUri);
                webBrowserSearch.Url = uri;
            }
        }

        private void copyUrlToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageSearch)
            {
                Clipboard.SetDataObject(webBrowserSearch.Url.AbsoluteUri);
                return;
            }
            Uri uri = webBrowserResult.Url;
            if (uri != null)
            {
                Clipboard.SetDataObject(uri.AbsoluteUri);
            }
        }

        #endregion

    }
}