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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using Diagram.UI;

using Diagram.Data.WpfData;

using HTMLConverter;
using System.Xml;

namespace Celestrak.NORAD.Satellites.Wpf.UI.UserControls
{
    /// <summary>
    /// Celestrak page
    /// </summary>
    public partial class UserControlCelestrakPage : UserControl
    {
        #region Fields

        SatelliteData data;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCelestrakPage()
        {
            InitializeComponent();
            WebRequest request = WebRequest.Create("http://celestrak.com/NORAD/elements/");
            try
            {
                WebResponse resp = request.GetResponse();
                using (TextReader reader = new StreamReader(resp.GetResponseStream()))
                {
                    string xaml = HtmlToXamlConverter.ConvertHtmlToXaml(reader.ReadToEnd(), true);
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.LoadXml(xaml);
                    XmlNodeList nl = doc.GetElementsByTagName("Hyperlink");
                    List<XmlElement> ln = new List<XmlElement>();
                    foreach (XmlElement e in nl)
                    {
                        ln.Add(e);
                    }
                    foreach (XmlElement e in ln)
                    {
                        string s = e.GetAttribute("NavigateUri");
                        if (s.Contains('@'))
                        {
                            e.ParentNode.RemoveChild(e);
                        }
                    }
                    xaml = doc.OuterXml;
                    object el = XamlReader.Parse(xaml);
                    Content = el;
                    this.RecursiveAction<Hyperlink>(ProcessLink);
                }
            }
            catch (Exception exception)
            {
                exception.ShowError(10);
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Satellite data
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
            }
        }

        #endregion

        #region Private

        void ProcessLink(Hyperlink link)
        {
            Uri uri = link.NavigateUri;
            string s = uri.OriginalString;
            if (System.IO.Path.GetExtension(s).Contains("txt"))
            {
                link.Click += LinkClick;
            }
        }

        #endregion

        #region Event handlers

        void LinkClick(object sender, RoutedEventArgs e)
        {
            Hyperlink l = sender as Hyperlink;
            Uri uri = l.NavigateUri;
            data.Url = "http://celestrak.com/NORAD/elements/" + uri.OriginalString;
        }

        #endregion
    }
}
