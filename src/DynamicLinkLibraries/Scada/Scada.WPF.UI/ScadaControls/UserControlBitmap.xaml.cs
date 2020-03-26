using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
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
using Scada.Interfaces;
using Scada.WPF.UI.Convertes;

namespace Scada.WPF.UI.ScadaControls
{
   
    /// <summary>
    /// Bitmap indication control
    /// </summary>
    public partial class UserControlBitmap : UserControl, IScadaConsumer
    {
        #region Fields

        IScadaInterface scada;

        IEvent eventObject;

        bool isEnabled = false;



        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlBitmap()
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
                if (value == null)
                {
                    return;
                }
                if (Visibility != Visibility.Visible)
                {
                    return;
                }
                scada = value;
                if (eventObject != null)
                {
                    if (isEnabled)
                    {
                        eventObject.Event -= Set;
                    }
                }
                eventObject = scada[Event];
                scada.AddEventOutput(Event, Output);
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
                if (eventObject == null)
                {
                    return;
                }
                if (value)
                {
                    eventObject.Event += Set;
                }
                else
                {
                    eventObject.Event -= Set;
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Event
        /// </summary>
        [Browsable(true)]
        [TypeConverter(typeof(EventConverter))]
        [Category("SCADA"), Description("Event name"), DisplayName("Event")]
        public string Event
        {
            get;
            set;
        }

        /// <summary>
        /// Output
        /// </summary>
        [Browsable(true)]
        [TypeConverter(typeof(OutputBitmapConverter))]
        [Category("SCADA"), Description("Output name"), DisplayName("Output")]
        public string Output
        {
            get;
            set;
        }

        #endregion

        #region Private Mebmers

        void Set()
        {
            Dispatcher.Invoke(SetPrivate);
        }


        void SetPrivate()
        {
            Bitmap bitmap = scada.GetOutput(Output)() as Bitmap;
            if (bitmap == null)
            {
                return;
            }
            Bitmap bmp = new Bitmap(bitmap);
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            stream.Position = 0;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            image.Source = bitmapImage;
        }


        #endregion
    }
}
