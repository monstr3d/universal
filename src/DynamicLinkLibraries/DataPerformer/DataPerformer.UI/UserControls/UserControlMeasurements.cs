using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlMeasurements : UserControl
    {
        /// <summary>
        /// Data Consumer
        /// </summary>
        public IDataConsumer DataConsumer { get; set; }

   
        Dictionary<string, UserControlMeasurement> measurements =
            new Dictionary<string, UserControlMeasurement>();

        public UserControlMeasurements()
        {
            InitializeComponent();
        }

        public Dictionary<IMeasurement, Chart.Drawing.Interfaces.ISeries> Series
        {
            set
            {
                foreach (var item in measurements.Values)
                {
                    item.Series = value;
                }
            }
        }

        public IMeasurements Measurements
        {
            set => Set(value);
        }

        void Set(IMeasurements value)
        {
            var image = value.GetImage();
            int w = image.Width;
            int h = image.Height;
            var c = pictureBoxMeasurement.Parent;
            c.Width = w;
            c.Height = h;
            pictureBoxMeasurement.Width = w;
            pictureBoxMeasurement.Height = h;
            pictureBoxMeasurement.Image = image;
            panelTop.Height += h - 50;
            this.Height += image.Height - 50;
            var name = DataConsumer.GetRelativeMeasurementsName(value);
            labelName.Text = name;
            int top = 0;
            foreach (var measurement in value.GetMeasurementObjects())
            {
                var mName = measurement.Name;
                var uc = new UserControlMeasurement();
                uc.Measurement = measurement;
                uc.MeasurementName = mName;
                var ht = uc.Height;
                panelMeasurements.Height += ht;
                uc.Top = top;
                top += ht;
                Height += ht;
                panelMeasurements.Controls.Add(uc);
                measurements[mName] = uc;
            }
            Resize += UserControlMeasurements_Resize;
        }

        private void UserControlMeasurements_Resize(object sender, EventArgs e)
        {
            foreach (var c in measurements.Values)
            {
                c.Width = Width -3;
            }
        }

        /// <summary>
        /// Dictionary 
        /// </summary>
        public Dictionary<string, Color> Dictionary
        {
            get
            {
                Dictionary<string, Color> d = null;
                foreach (var item in measurements.Keys) 
                { 
                var c = measurements[item];
                    var color = c.Color;
                    if (color != null)
                    {
                        if (d == null)
                        {
                            d = new Dictionary<string, Color>();

                        }
                        d[item] = color[0];
                    }
                }
                return d;
            }
            set
            {
                if (value == null) return;
                foreach (var item in value.Keys)
                {
                    if (measurements.ContainsKey(item))
                    {
                        measurements[item].Color = [value[item]];
                    }
                }
            }
        }
    }
}