using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using Scada.Interfaces;

using Scada.Wpf.Common.Convertes;

using Web.Interfaces;


namespace Scada.WPF.UI.ScadaControls
{
    /// <summary>
    /// Interaction logic for UserControlExternalImage.xaml
    /// </summary>
    public partial class UserControlWebPage : UserControl, IScadaConsumer
    {
        #region Fields

        Action<NavigationEventArgs> onLoadBrowser = (NavigationEventArgs args) => { };

        IScadaInterface scada;

        IUrlConsumer consumer;

        Action<string> change = (string url) => { };

        bool isEnabled = false;

        string currentUrl;

       
 
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlWebPage()
        {
            InitializeComponent();
        }

        #endregion

        #region IScadaConsumer Members

        IScadaInterface IScadaConsumer.Scada
        {
            get
            {
                return scada;
            }
            set
            {
                scada = value;
                IUrlConsumer c = scada.GetObject<IUrlConsumer>(Consumer);
                if (c == consumer)
                {
                    return;
                }
                try
                {
                    consumer.Change -= change;
                }
                catch (Exception)
                {

                }
                consumer = c;
                consumer.Change += change;
                consumer.Change += (string url) => { Browser.Navigate(url); };
                if (consumer is IUrlProvider)
                {
                    string s = (consumer as IUrlProvider).Url;
                    if (s.Equals(currentUrl))
                    {
                        return;
                    }
                    currentUrl = s;
                    Browser.Navigate(s);
                    if (!s.Equals(Url.Text))
                    {
                        Url.Text = s;
                    }
                }
            }
        }

        bool IScadaConsumer.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
                IsEnabled = !value;
               // Url.IsReadOnly = !isEnabled;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Url
        /// </summary>
        [Browsable(true)]
        [TypeConverter(typeof(UrlConsumerConverter))]
        [Category("SCADA"), Description("Consumer name"), DisplayName("URL Consumer")]
        public string Consumer
        {
            get;
            set;
        }

        /// <summary>
        /// Url Consumer
        /// </summary>
        public IUrlConsumer UrlConsumer
        {
            get
            {
                return consumer;
            }
        }

        /// <summary>
        /// Change Event
        /// </summary>
        public event Action<string> Change
        {
            add { change += value; }
            remove { change -= value; }
        }

        #endregion

        #region Event Handlers

       private void Browser_LoadCompleted(object sender, NavigationEventArgs e)
       {
       }

       private void Url_KeyUp(object sender, KeyEventArgs e)
       {
           if (e.Key == Key.Enter)
           {
               string s = Url.Text;
               try
               {
                   WebRequest request = WebRequest.Create(s);
                   WebResponse resp = request.GetResponse();
                   using (System.IO.Stream stream = resp.GetResponseStream())
                   {
                       stream.ReadByte();
                       consumer.Url = s;
                       return;
                   }
               }
               catch (Exception exception)
               {
                   exception.ShowError();
               }
               Url.Text = (consumer as IUrlProvider).Url;
           }
        }

        #endregion
    }
}
