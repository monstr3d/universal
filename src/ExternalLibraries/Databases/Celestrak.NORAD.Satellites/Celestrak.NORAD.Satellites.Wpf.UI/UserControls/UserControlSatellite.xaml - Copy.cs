using System;
using System.Collections.Generic;
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

using Diagram.UI;

namespace Celestrak.NORAD.Satellites.Wpf.UI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlSatellite.xaml
    /// </summary>
    public partial class UserControlSatellite : UserControl
    {
        #region Fields

        SatelliteData data;

        bool block = false;
        #endregion

        #region Ctor

        public UserControlSatellite()
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
                return data;
            }
            set
            {
                data = value;
                FillCombo(data.Url);
                ShowData(data.Satellite);
                value.OnChangeUrl += FillCombo;
                value.OnChangeSatellite += ShowData;
            }
        }

        #endregion

        #region Private

        void FillCombo(string url)
        {
            string[] s = data.Satellites;
            Satellites.Items.Clear();
            if (s != null)
            {
                foreach (string ss in s)
                {
                    Satellites.Items.Add(ss);
                }
            }
        }

        void ShowData(string satellite)
        {
            string m = data.Satellite;
            if (m.Length == 0)
            {
                return;
            }
            if (!block)
            {
                for (int i = 0; i < Satellites.Items.Count; i++)
                {
                    string s = Satellites.Items[i] + "";
                    if (s.Equals(m))
                    {
                        Satellites.SelectedIndex = i;
                        break;
                    }
                }
            }
            sData.DataContext = data.DataConext;
        }

        #endregion

        #region Internal

        internal void Delete()
        {
            data.OnChangeUrl -= FillCombo;
            data.OnChangeSatellite -= ShowData;
        }


        #endregion

        #region Event Handlers

        void Select_Satellite(object sender, SelectionChangedEventArgs args)
        {
            object o = Satellites.SelectedItem;
            if (o == null)
            {
                return;
            }
            block = true;
            try
            {
                data.Satellite = o + "";
            }
            catch (Exception exception)
            {
                exception.ShowError(10);
            }

        }


        #endregion
    }
}
