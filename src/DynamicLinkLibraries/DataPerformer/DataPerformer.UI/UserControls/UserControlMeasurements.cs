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

        public IMeasurements Measurements
        {
            set => Set(value);
        }

        void Set(IMeasurements value)
        {
            var image = value.GetImage();
            int w = image.Width;
            int h = image.Height;
            var c = pictureBox.Parent;
            c.Width = w;
            c.Height = h;
            pictureBox.Width = w;
            pictureBox.Height = h;
            pictureBox.Image = image;
            this.Height += image.Height;
            var name = DataConsumer.GetRelativeMeasurementsName(value);
            labelName.Text = name;
            int top = 0;
            foreach (var measurement in value.GetMeasurementObjects((double)0))
            {
                var mName = measurement.Name;
                var uc = new UserControlMeasurement();
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