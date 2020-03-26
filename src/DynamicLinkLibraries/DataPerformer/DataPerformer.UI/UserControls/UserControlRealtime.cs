using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;

using Event.Interfaces;


using DataPerformer.Interfaces;

using Event.Portable.Interfaces;


using WindowsExtensions;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Realtime
    /// </summary>
    public partial class UserControlRealtime : UserControl, IRealtimeUpdate, IRealTimeStartStop, ICalculationReason
    {

        #region Fields

        string calculationReason = "";

        private Dictionary<string, object> dObject = new Dictionary<string, object>();

        private Dictionary<string, object[]> dArray = new Dictionary<string, object[]>();

        internal Dictionary<IMeasurement, Portable.MeasurementsDisasseblyWrapper>
        
        disassemblyDictionary = new Dictionary<IMeasurement, Portable.MeasurementsDisasseblyWrapper>();

        Tuple<double[],
                  Dictionary<string,
                  Dictionary<string, Tuple<Color[], bool, double[]>>>> realtime = null;
        /// <summary>
        /// Associated object
        /// </summary>
        private IDataConsumer dataConsumer;

        private IRealtime realTime;

        Dictionary<IMeasurement, object[]> calc = new Dictionary<IMeasurement, object[]>();

        Dictionary<string, IMeasurement> add = new Dictionary<string, IMeasurement>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlRealtime()
        {
            InitializeComponent();
        }

        #endregion

        #region IRealtimeUpdate Members

        Action IRealtimeUpdate.Update
        {
            get
            {
                if (calculationReason.IsRealtimeAnalysis())
                {
                    return () => { };
                }
                return RealtimeUpdate;
            }
        }

        event Action IRealtimeUpdate.OnUpdate
        {
            add { }
            remove { }
        }

        #endregion

        #region IRealTimeStartStop Members


        void IRealTimeStartStop.Start()
        {
            if (calculationReason.IsRealtimeAnalysis())
            {
                return;
            }
            disassemblyDictionary.Clear();
            Dictionary<IMeasurement, BaseTypes.Interfaces.IDisassemblyObject> disassemblyDict =
                dataConsumer.CreateDisassemblyObjectDictionary();
            foreach (IMeasurement key in disassemblyDict.Keys)
            {
                disassemblyDictionary[key] = new
                    Portable.MeasurementsDisasseblyWrapper(disassemblyDict[key], key);
            }
            add.Clear();
            calc.Clear();
            dObject.Clear();
            dArray.Clear();
            performer.Clear();
            performer.Reset();
                 realtime.Item1[0] = double.Parse(textBoxChartInterval.Text);
            performer.Interval = realtime.Item1[0];
            List<Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>> output =
                userControlRealtimeMeasurements.Output;
            List<Tuple<string, object[]>> measurementsList = new List<Tuple<string, object[]>>();
            Dictionary<string, Tuple<Func<object, double>, Tuple<Tuple<string, IMeasurement, object[]>,
                Tuple<Color[], bool, double[]>>>> dd =
                new Dictionary<string, Tuple<Func<object, double>,
                    Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>>>();
            List<IMeasurement> lm = new List<IMeasurement>();
            foreach (Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>> t in output)
            {
                string na = t.Item1.Item1;
                IMeasurement mea = t.Item1.Item2;
                lm.Add(mea);
                measurementsList.Add(new Tuple<string, object[]>(t.Item1.Item1, t.Item1.Item3));
                calc[mea] = t.Item1.Item3;
                Func<object, double> f = mea.GetDoubleFunction();
                if (f == null)
                {
                    add[t.Item1.Item1] = mea;
                    continue;
                }
                dd[t.Item1.Item1] = new Tuple<Func<object, double>,
                    Tuple<Tuple<string, IMeasurement, object[]>,
                    Tuple<Color[], bool, double[]>>>(f, t);
                dArray[na] = t.Item1.Item3;
                Color cw = t.Item2.Item1[0];
                System.Windows.Media.Color cp = System.Windows.Media.Color.FromRgb(cw.R, cw.G, cw.B);
                Tuple<System.Windows.Media.Color, bool, double[], Func<object, double>> tp =
                    new Tuple<System.Windows.Media.Color, bool, double[], Func<object, double>>(
                      cp, t.Item2.Item2, t.Item2.Item3, f);
                performer[na] = tp;
            }
            performer.Reset();
            realtime.Item1[0] = double.Parse(textBoxChartInterval.Text);
            userControlRealtimeList.Set(measurementsList);
            Labels.GraphLabel lab = this.FindParent<Labels.GraphLabel>();
            lab.data.Item6[0] = realtime;
            UserControlGraph uc = this.FindParent<UserControlGraph>();
        }


        void IRealTimeStartStop.Stop()
        {
            if (calculationReason.IsRealtimeAnalysis())
            {
                return;
            }
        }


        event Action IRealTimeStartStop.OnStart
        {
            add { }
            remove { }
        }

        event Action IRealTimeStartStop.OnStop
        {
            add { }
            remove { }
        }

        #endregion

        #region Internal Members

        internal void SaveSettings()
        {
            realtime.Item1[0] = double.Parse(textBoxChartInterval.Text);
            List<Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>> output =
           userControlRealtimeMeasurements.Output;
            List<Tuple<string, object[]>> measurementsList = new List<Tuple<string, object[]>>();
            Dictionary<string, Tuple<Func<object, double>, Tuple<Tuple<string, IMeasurement, object[]>,
                Tuple<Color[], bool, double[]>>>> dd =
                new Dictionary<string, Tuple<Func<object, double>,
                    Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>>>();
            List<IMeasurement> lm = new List<IMeasurement>();
            foreach (Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>> t in output)
            {
                string na = t.Item1.Item1;
                IMeasurement mea = t.Item1.Item2;
                lm.Add(mea);
                measurementsList.Add(new Tuple<string, object[]>(t.Item1.Item1, t.Item1.Item3));
                calc[mea] = t.Item1.Item3;
                Func<object, double> f = mea.GetDoubleFunction();
                if (f == null)
                {
                    add[t.Item1.Item1] = mea;
                    continue;
                }
                dd[t.Item1.Item1] = new Tuple<Func<object, double>,
                    Tuple<Tuple<string, IMeasurement, object[]>,
                    Tuple<Color[], bool, double[]>>>(f, t);
                dArray[na] = t.Item1.Item3;
                Color cw = t.Item2.Item1[0];
                System.Windows.Media.Color cp = System.Windows.Media.Color.FromRgb(cw.R, cw.G, cw.B);
                Tuple<System.Windows.Media.Color, bool, double[], Func<object, double>> tp =
                    new Tuple<System.Windows.Media.Color, bool, double[], Func<object, double>>(
                      cp, t.Item2.Item2, t.Item2.Item3, f);
                performer[na] = tp;
            }
            performer.Reset();
            realtime.Item1[0] = double.Parse(textBoxChartInterval.Text);
            userControlRealtimeList.Set(measurementsList);
            Labels.GraphLabel lab = this.FindParent<Labels.GraphLabel>();
            lab.data.Item6[0] = realtime;
        }

        internal List<IMeasurement> Measurements
        {
            get
            {
                List<Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>> output =
                      userControlRealtimeMeasurements.Output;
                List<Tuple<string, object[]>> measurementsList = new List<Tuple<string, object[]>>();
                Dictionary<string, Tuple<Func<object, double>, Tuple<Tuple<string, IMeasurement, object[]>,
                    Tuple<Color[], bool, double[]>>>> dd =
                    new Dictionary<string, Tuple<Func<object, double>,
                        Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>>>();
                List<IMeasurement> lm = new List<IMeasurement>();
                foreach (Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>> t in output)
                {
                    string na = t.Item1.Item1;
                    IMeasurement mea = t.Item1.Item2;
                    lm.Add(mea);
                }
                return lm;
            }
        }

        internal IRealtime Realtime
        {
            set
            {
                realTime = value;
            }
        }

        string ICalculationReason.CalculationReason
        {
            get
            {
                return calculationReason;
            }

            set
            {
                calculationReason = value;
            }
        }

        internal void Set(IDataConsumer dataConsumer, Tuple<Dictionary<string, Color[]>, Dictionary<string, bool>,
            Dictionary<string, string>, string[], int[],
             Tuple<double[],
            Dictionary<string, Dictionary<string,
            Tuple<Color[], bool, double[]>>>>[]> data)
        {
            this.dataConsumer = dataConsumer;
            realtime = data.Item6[0];
            userControlRealtimeMeasurements.Set(dataConsumer, realtime.Item2);
            textBoxChartInterval.Text = realtime.Item1[0] + "";
        }

        

        internal void FillMeasurements()
        {
            userControlRealtimeMeasurements.FillMeasurements();
        }

       

        #endregion

        #region Private Members

        void RealtimeUpdate()
        {
            try
            {
                foreach (Portable.MeasurementsDisasseblyWrapper wr
                    in disassemblyDictionary.Values)
                {
                    wr.Update();
                }
            }
            catch
            {
                return;
            }
            if (realTime == null)
            {
                return;
            }
            foreach (IMeasurement m in calc.Keys)
            {
                calc[m][0] = m.Parameter();
            }
            userControlRealtimeList.Show();
            foreach (string key in dArray.Keys)
            {
                object o = dArray[key][0];
                dObject[key] = o;
            }
            double time = realTime.Time;
            performer.Write(dObject, time);
            this.InvokeIfNeeded(ShowTime, time);
        }


        void ShowTime(double time)
        {
            labelTime.Text = time + "";
        }

        #endregion

        #region Event Handlers

        private void panelChart_Resize(object sender, EventArgs e)
        {
            performer.Width = elementHost.Width;
            performer.Height = elementHost.Height;
        }

        #endregion
    }
}