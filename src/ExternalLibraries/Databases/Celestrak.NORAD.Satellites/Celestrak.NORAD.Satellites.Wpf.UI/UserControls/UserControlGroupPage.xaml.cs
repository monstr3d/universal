using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Diagram.UI;


namespace Celestrak.NORAD.Satellites.Wpf.UI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlGroupPage.xaml
    /// </summary>
    public partial class UserControlGroupPage : UserControl
    {
        #region Fields


        private SatelliteData data;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlGroupPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Public

        /// <summary>
        /// Satillite Data
        /// </summary>
        public SatelliteData Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                string url = data.Url;
                data.OnChangeUrl += Navigate;
                if (url.Length > 0)
                {
                    try
                    {
                        WebRequest req = WebRequest.Create(url);
                        Stream stream = req.GetResponse().GetResponseStream();
                        using (TextReader reader = new StreamReader(stream))
                        {
                            string str = reader.ReadToEnd();
                            Content = str;
                        }
                    }
                    catch (Exception exception)
                    {
                        exception.ShowError(10);
                    }
                }
            }
        }

        /// <summary>
        /// Navigates
        /// </summary>
        /// <param name="url">Navigation url</param>
        public void Navigate(string url)
        {
            try
            {
                string s = data.Text;
                if (s.Length > 0)
                {
                    FlowDocument doc = new FlowDocument();
                    Paragraph p = new Paragraph();
                    p.Inlines.Add(new Run(s));
                    doc.Blocks.Add(p);
                    Content = doc;
                }
            }
            catch (Exception exception)
            {
                exception.ShowError(10);
            }
        }

        #endregion

        #region Internal

        internal void Delete()
        {
            data.OnChangeUrl -= Navigate;
        }

        #endregion

        #region Event Handlers



        #endregion
    }
}
