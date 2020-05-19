using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Celestrak.NORAD.Satellites.Wpf.UI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlCelestrak.xaml
    /// </summary>
    public partial class UserControlCelestrak : UserControl, IScadaConsumer
    {
        #region Fields

        IScadaInterface scada;

        bool isEnabled = false;

        #endregion

        #region Ctor

        public UserControlCelestrak()
        {
            InitializeComponent();
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
                return Group.Data;
            }
            set
            {
                Group.Data = value;
                Page.Data = value;
                Satellite.Data = value;
            }
        }

        /// <summary>
        /// Deletes itself
        /// </summary>
        public void Delete()
        {
            Group.Delete();
            Satellite.Delete();
        }


        #region Edited Prprerties

        [Browsable(true)]
        [TypeConverter(typeof(Converters.SatelliteDataConverter))]
        [Category("SCADA"), Description("Satellite Name"), DisplayName("Satellite")]
        public string SatelliteName
        {
            get;
            set;
        }


        #endregion

 
   
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
                scada = value;
                Data = scada.GetObject<SatelliteData>(SatelliteName);
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
            }
        }

        #endregion

        #region Event Handlers


        #endregion

    }
}