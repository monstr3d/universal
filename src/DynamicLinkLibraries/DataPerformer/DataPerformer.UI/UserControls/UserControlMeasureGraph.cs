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
    /// User control for measure graph
    /// </summary>
    public partial class UserControlMeasureGraph : UserControl
    {

        #region Fields
        List<IMeasurements> measurements;


        List<UserControlMeasureGraph> list;

        private IDataConsumer consumer;

        Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
            Dictionary<string, string>, string[], int[],
             Tuple<double[],
            Dictionary<string, Dictionary<string,
            Tuple<Color[], bool, double[]>>>>[]> data;
  
    
        #endregion


        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlMeasureGraph()
        {
            InitializeComponent();
            list = new List<UserControlMeasureGraph>();
            list.Add(this);
        }

        private UserControlMeasureGraph(List<IMeasurements> measurements, List<UserControlMeasureGraph> list)
        {
            InitializeComponent();
            this.measurements = measurements;
            this.list = list;
            Dock = DockStyle.Top;
        }

        void Set(IMeasurements measurements, IDataConsumer consumer)
        {
            int h = userControlMeaHeader.Height;
            userControlMeaHeader.Set(consumer, measurements);
            int dh = userControlMeaHeader.Height - h;
            panelTop.Height += dh;
            Height += dh;
        }

        internal Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
            Dictionary<string, string>, string[], int[],
             Tuple<double[],
            Dictionary<string, Dictionary<string,
            Tuple<Color[], bool, double[]>>>>[]>
           Data
        {
            set
            {
                if (data != null)
                {
                    throw new Exception();
                }
                data = value;
                foreach (UserControlMeasureGraph gr in list)
                {
                    gr.userControlMeaHeader.Data = value;
                }
            }
        }

  
        internal Dictionary<IMeasurement, Color[]> Dictionary
        {
            get
            {
                Dictionary<IMeasurement, Color[]> d = new Dictionary<IMeasurement, Color[]>();
                foreach (UserControlMeasureGraph uc in list)
                {
                    uc.userControlMeaHeader.Add(d);
                }
                return d;
            }
        }

        internal Dictionary<string, IMeasurement> MeasureByName
        {
            get
            {
                Dictionary<string, IMeasurement> d = new Dictionary<string, IMeasurement>();
                foreach (UserControlMeasureGraph uc in list)
                {
                    uc.userControlMeaHeader.Add(d);
                }
                return d;
            }
        }


  
        private void Add()
        {
            UserControlMeasureGraph uc = new UserControlMeasureGraph(measurements, list);
            uc.consumer = consumer;
            int n = list.Count;
            uc.Set(measurements[n], consumer);
            foreach (UserControlMeasureGraph c in list)
            {
                c.Height = c.Height + uc.Height;
            }
            list[n - 1].panelCenter.Controls.Add(uc);
            list.Add(uc);
        }

        internal Dictionary<IMeasurement, object> ObjectDictionary
        {
            set
            {
                foreach (UserControlMeasureGraph g in list)
                {
                    g.userControlMeaHeader.Dictionary = value;
                }
            }
        }

 
        /// <summary>
        /// Creates control from consumer
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <returns>The control</returns>
        public static UserControlMeasureGraph Create(IDataConsumer consumer)
        {
            if (consumer.Count == 0)
            {
                return null;
            }
            List<IMeasurements> l = new List<IMeasurements>();
            for (int i = 0; i < consumer.Count; i++)
            {
                l.Add(consumer[i]);
            }
            UserControlMeasureGraph uc = new UserControlMeasureGraph();
            uc.consumer = consumer;
            uc.measurements = l;
            uc.Set(l[0], consumer);
            for (int i = 1; i < l.Count; i++)
            {
                uc.Add();
            }
            return uc;
        }
    }
}
