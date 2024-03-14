using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control of collection of measurements
    /// </summary>
    public partial class UserControlMeasurementCollection : UserControl, IColorDictionary
    {
        Dictionary<string, UserControlMeasurements> measurementList = 
            new ();


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlMeasurementCollection()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Series
        /// </summary>
        public Dictionary<IMeasurement, Chart.Drawing.Interfaces.ISeries> Series
        {
            set
            {
                foreach (var item in measurementList.Values)
                {
                    item.Series = value;
                }
            }
        }

        /// <summary>
        /// Measurements
        /// </summary>
        public IEnumerable<IMeasurements> Measurements
        {
            set
            {
                int t = 0;
                foreach (var measurement in value)
                {
                    var uc = new UserControlMeasurements();
                    var name = DataConsumer.GetRelativeMeasurementsName(measurement);
                    uc.DataConsumer = DataConsumer;
                    uc.Measurements = measurement;
                    measurementList[name] = uc;
                    uc.Top = t;
                    var h = uc.Height;
                    Height += h;
                    uc.BorderStyle = BorderStyle.FixedSingle;
                    t += h;
                    Controls.Add(uc);
                }
                Resize += UserControlMeasurementCollection_Resize;
            }
        }

        public IDataConsumer DataConsumer { get; set; }
        
        Dictionary<string, Dictionary<string, Color>> IColorDictionary.ColorDictionary 
        { 
            get => dictionary; 
            set => Set(value); 
        }

        private void Set(Dictionary<string, Dictionary<string, Color>>  dictionary)
        {
            foreach (var key in dictionary.Keys)
            {
                if (!measurementList.ContainsKey(key))
                {
                    continue;
                }
                measurementList[key].Dictionary = dictionary[key];
            }
        }

        Dictionary<string, Dictionary<string, Color>> dictionary
        {
            get
            {
                Dictionary<string, Dictionary<string, Color>> d = 
                    new Dictionary<string, Dictionary<string, Color>>();
                foreach (var key in measurementList.Keys)
                {
                    var dd = measurementList[key].Dictionary;
                    if (dd != null)
                    {
                        d[key] = dd;
                    }

                }
                return d;
            }
        }
   
        private void UserControlMeasurementCollection_Resize(object sender, EventArgs e)
        {
            foreach (var measurements in measurementList.Values)
            {
                measurements.Width = Width - 30;

            }
        }

    }
}
