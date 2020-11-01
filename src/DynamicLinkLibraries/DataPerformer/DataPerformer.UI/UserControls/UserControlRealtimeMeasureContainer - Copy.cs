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
    public partial class UserControlRealtimeMeasureContainer : UserControl
    {

        #region Fields

         private List<UserControlRealtimeMeasure> list = new List<UserControlRealtimeMeasure>();

        private IMeasurements measurements;

        private IDataConsumer consumer;

        private Dictionary<string, Tuple<Color[], bool, double[]>> dictionary;

        private string name;
     
        #endregion

        #region Ctor

        /// <summary>
        /// Defaut constructor
        /// </summary>
        public UserControlRealtimeMeasureContainer()
        {
            InitializeComponent();
        }


        #endregion

        #region Public Members


        #endregion

        #region Internal & Private Members

        internal  List<Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>> Output
        {
            get
            {
               UserControlRealtime p =   this.FindParent<UserControlRealtime>();
                
                List<Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>> l =
                    new List<Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>>(); 
                foreach (Control c in Controls)
                {
                    if (!(c is UserControlRealtimeMeasure))
                    {
                        continue;
                    }
                    UserControlRealtimeMeasure uc = c as UserControlRealtimeMeasure;
                    IMeasurement m = uc.Measure;
                    string name = m.Name;
                    Tuple<Color[], bool, double[]> t = uc.Tuple;
                    if (t == null)
                    {
                        if (dictionary.ContainsKey(name))
                        {
                            dictionary.Remove(name);
                        }
                        continue;
                    }
                    dictionary[name] = t;
                    if (p.disassemblyDictionary.ContainsKey(m))
                    {
                        MeasurementsDisasseblyWrapper wr =
                            p.disassemblyDictionary[m];
                        IMeasurement[] mms = wr.Measurements;
                        foreach (IMeasurement mm in mms)
                        {
                            Tuple<string, IMeasurement, object[]> tts = new Tuple<string, IMeasurement, object[]>
                                (this.name + '.' + mm.Name, mm, new object[] { "" });
                            Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>> tus =
                                new Tuple<Tuple<string, IMeasurement, object[]>,
                                    Tuple<Color[], bool, double[]>>(tts, t);
                            l.Add(tus);
                        }
                    }
                    else
                    {
                        Tuple<string, IMeasurement, object[]> tt = new Tuple<string, IMeasurement, object[]>(
                            this.name + '.' + name, m, new object[] { "" });
                        Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>> tu =
                            new Tuple<Tuple<string, IMeasurement, object[]>,
                                Tuple<Color[], bool, double[]>>(tt, t);
                        l.Add(tu);
                    }
                }
                return l;
            }
        }

        internal void Set(IDataConsumer consumer, IMeasurements measurements, 
            Dictionary<string, Tuple<Color[], bool, double[]>> dictionary)
        {
            this.consumer = consumer;
            this.measurements = measurements;
            this.dictionary = dictionary;
            name = consumer.GetMeasurementsName(measurements);
            for (int i = 0; i < measurements.Count; i++)
            {
                Add();
            }
        }

  
        void Add(Dictionary<string, IMeasurement> d)
        {
         /*!!!   IMeasure m = Measure;
            if (m == null)
            {
                return;
            }
            string n = m.Name;
            d[n] = m;*/
        }


        private void Add()
        {
            int y = 2;
            int n = list.Count;
            UserControlRealtimeMeasure uc = new UserControlRealtimeMeasure();
            IMeasurement m = measurements[n];
            uc.Measure = m;
            string name = m.Name;
            if (dictionary.ContainsKey(name))
            {
                uc.Tuple = dictionary[name];
            }
            for (int i = 0; i < n; i++)
            {
                y += uc.Height;
            }
            uc.Top = y;
            Height = uc.Bottom;
            Controls.Add(uc);
            list.Add(uc);
        }

        internal Dictionary<IMeasurement, Tuple<Color[], bool, double[]>> Dictionary
        {
            set
            {
                foreach (UserControlRealtimeMeasure uc in list)
                {
                    uc.Dictionary = value;
                }
            }
        }


        #endregion

        private void UserControlRealtimeMeasureContainer_Resize(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                c.Width = Width - 2;
            }
        }
    }
}
