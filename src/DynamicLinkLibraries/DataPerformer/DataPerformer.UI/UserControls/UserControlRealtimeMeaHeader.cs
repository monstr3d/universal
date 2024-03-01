using System;
using System.Collections.Generic;
using System.Drawing;

using System.Windows.Forms;

using DataPerformer.Interfaces;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Header of realtime
    /// </summary>
    public partial class UserControlRealtimeMeaHeader : UserControl
    {
        #region Fields

        Dictionary<string, IMeasurement> dictionary = new Dictionary<string,IMeasurement>();

        Dictionary<string, Tuple<Color[], bool, double[]>> dic;
        #endregion

        #region Ctor
        /// <summary>
        /// Defualt constructor
        /// </summary>
        public UserControlRealtimeMeaHeader()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal & Private Members

        internal UserControlRealtimeMeasureContainer UserControlRealtimeMeasureContainer
        {
            get
            {
                return userControlRealtimeMeasureContainer;
            }
        }

        internal void Set(IDataConsumer consumer, IMeasurements measurements, 
            Dictionary<string, Tuple<Color[], bool, double[]>> dic)
        {
            this.dic = dic;
            int count = measurements.Count;
            for (int i = 0; i < count; i++)
            {
                IMeasurement m = measurements[i];
                dictionary[m.Name] = m;
            }
            int h = userControlTopObject.Height;
            userControlTopObject.Set(consumer, measurements);
            int dh = userControlTopObject.Height - h;
            panelTop.Height += dh;
            Height += dh;
            userControlTopObject.Dock = DockStyle.Fill;
            h = userControlRealtimeMeasureContainer.Height;
            userControlRealtimeMeasureContainer.Set(consumer, measurements, dic);
            dh = userControlRealtimeMeasureContainer.Height - h;
            panelBottom.Height += dh;
            Height += dh;
            userControlRealtimeMeasureContainer.Dock = DockStyle.Fill;
            Dictionary<IMeasurement, Tuple<Color[], bool, double[]>>
            d = new Dictionary<IMeasurement, Tuple<Color[], bool, double[]>>();
            foreach (string m in dic.Keys)
            {
                if (dictionary.ContainsKey(m))
                {
                    d[dictionary[m]] = dic[m];
                }
            }
            userControlRealtimeMeasureContainer.Dictionary = d;

        }

        #endregion
    }
}
