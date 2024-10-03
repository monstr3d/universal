using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;
using Diagram.UI;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Container of measurements
    /// </summary>
    public partial class UserControlMeasureContainer : UserControl
    {
        #region Fields 

        private List<UserControlMeasure> list;

        private IMeasurements measurements;

        private IDataConsumer consumer;

        private string name;

        private Dictionary<IMeasurement, UserControlMeasure> dict;

 
        #endregion

        #region Ctor

        /// <summary>
        /// Defaut constructor
        /// </summary>
        public UserControlMeasureContainer()
        {
            InitializeComponent();
            list = new List<UserControlMeasure>();
            dict = new Dictionary<IMeasurement, UserControlMeasure>();
        }


        internal void SetAll(IDataConsumer consumer, IMeasurements measurements)
        {
            if (measurements.Count == 0)
            {
                panelTop.Controls.Clear();
                return;
            }
            UserControlMeasureContainer uc = this;
            uc.Set(consumer, measurements);
            for (int i = 0; i < measurements.Count; i++)
            {
                uc.Add();
                //uc.Measure = measurements[i];
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Creates container
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="consumer">Data consumer</param>
        /// <returns>The container</returns>
        public static UserControlMeasureContainer Create(IMeasurements measurements, IDataConsumer consumer)
        {
            if (measurements.Count == 0)
            {
                return null;
            }
            UserControlMeasureContainer uc = new UserControlMeasureContainer();
            uc.Set(consumer, measurements);
            for (int i = 0; i < measurements.Count; i++)
            {
                uc.Add();
            }
            return uc;
        }

        #endregion

        #region Internal Members

        internal void Add(Dictionary<IMeasurement, Color[]> d)
        {
            foreach (UserControlMeasure c in list)
            {
                c.Add(d);
            }
        }

        internal void Add(Dictionary<string, IMeasurement> d)
        {
            foreach (UserControlMeasure uc in list)
            {
                IMeasurement m = uc.Measure;
                if (m == null)
                {
                    continue;
                }
                string n = consumer.GetName(m);
                d[n] = m;
            }
        }

        internal Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
            Dictionary<string, string>, string[], int[],
             Tuple<double[],
            Dictionary<string, Dictionary<string,
            Tuple<Color[], bool, double[]>>>>[]> Data
        {
            set
            {
                foreach (UserControlMeasure uc in list)
                {
                    uc.Data = value;
                }
 
            }
        }
 
        void add(Dictionary<string, IMeasurement> d)
        {
            IMeasurement m = null;// Measure;
            if (m == null)
            {
                return;
            }
            string n = consumer.GetName(m);
            d[n] = m;
        }
 
       internal Dictionary<IMeasurement, object> Dictionary
        {
            set
            {
                foreach (UserControlMeasure uc in list)
                {
                    uc.Dictionary = value;
                }
            }
        }

        #endregion

       #region Private Members

       private void Add()
       {
           int n = list.Count;
           UserControlMeasure uc = new UserControlMeasure();
           uc.ParentName = name;
           uc.Left = 0;
           int y = 0;

           //  uc.dict = dict;
           //   uc.Set(consumer, measurements);
           uc.Measure = measurements[n];
           for (int i = 0; i < n; i++)
           {
               y += list[i].Height; ;
           }
           uc.Top = y;
           panelTop.Controls.Add(uc);
           list.Add(uc);
           panelTop.Height = uc.Bottom;
           Height = panelTop.Bottom + 2;
       }

       void Set(IDataConsumer consumer, IMeasurements measurements)
        {
            this.consumer = consumer;
            this.measurements = measurements;
            name = consumer.GetMeasurementsName(measurements);
        }

       #endregion

       #region Event Handlers

       private void panelTop_Resize(object sender, EventArgs e)
        {
            foreach (UserControlMeasure uc in list)
            {
                uc.Width = panelTop.Width - 2;
            }

        }
        
       #endregion

    }
}
