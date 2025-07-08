using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DataPerformer.Interfaces;

namespace DataPerformer.UI.UserControls
{

    /// <summary>
    /// Header control for measurements
    /// </summary>
    public partial class UserControlMeaHeader : UserControl
    {

        #region Ctor
        /// <summary>
        /// Defualt constructor
        /// </summary>
        public UserControlMeaHeader()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal & Private Members

        internal void Set(IDataConsumer consumer, IMeasurements measurements)
        {
            int h = userControlTopObject.Height;
            userControlTopObject.Set(consumer, measurements);
            int dh = userControlTopObject.Height - h;
            panelTop.Height += dh;
            Height += dh;
            userControlTopObject.Dock = DockStyle.Fill;
            h = userControlMeasureContainer.Height;
            userControlMeasureContainer.SetAll(consumer, measurements);
            dh = userControlMeasureContainer.Height - h;
            panelBottom.Height += dh;
            Height += dh;
            userControlMeasureContainer.Dock = DockStyle.Fill;
        }

        internal void Add(Dictionary<string, IMeasurement> dict)
        {
            userControlMeasureContainer.Add(dict);
        }
        
        internal void Add(Dictionary<IMeasurement, Color[]> dict)
        {
            userControlMeasureContainer.Add(dict);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Dictionary<IMeasurement, object> Dictionary
        {
            set
            {
                userControlMeasureContainer.Dictionary = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
            Dictionary<string, string>, string[], int[],
             Tuple<double[],
            Dictionary<string, Dictionary<string,
            Tuple<Color[], bool, double[]>>>>[]> Data
        {
            set
            {
                userControlMeasureContainer.Data = value;
            }
        }
 
        #endregion

    }
}
