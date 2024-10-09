using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;

using Event.Interfaces;

namespace DataPerformer.Event.Portable.Objects
{
    /// <summary>
    /// Time series median
    /// </summary>
    public class TimeSeriesMedian : CategoryObject, IDataConsumer, IMeasurements, IRealTimeStartStop
    {
        #region Fields

        List<IMeasurement> measurements = new List<IMeasurement>();

        List<IMeasurements> external = new List<IMeasurements>();

        bool isUpdated = false;

        protected IDataConsumer consumer;

        protected IMeasurement condition;

        private string conditionName = "";

        List<double>[] list;

        double[] medians;

        IMeasurement[] input;

        event Action onChangeInput = () => { };

        /// <summary>
        /// The "is loaded" sign
        /// </summary>
        protected bool isLoaded = false;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TimeSeriesMedian()
        {
            consumer = this;
        }

        #endregion

        #region IDataConsumer Members

        IMeasurements IDataConsumer.this[int number]
        {
            get
            {
                return external[number];
            }
        }

        int IDataConsumer.Count
        {
            get
            {
                return external.Count;
            }
        }

        event Action IDataConsumer.OnChangeInput
        {
            add
            {
                onChangeInput += value;
            }

            remove
            {
                onChangeInput -= value;
            }
        }

        void IDataConsumer.Add(IMeasurements measurements)
        {
            external.Add(measurements);
            if (!isLoaded)
            {
                return;
            }
            CreateMesurements();
            onChangeInput?.Invoke();
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            external.Remove(measurements);
            CreateMesurements();
            onChangeInput();
        }

        void IDataConsumer.Reset()
        {

        }

        void IDataConsumer.UpdateChildrenData()
        {

        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get
            {
                return measurements.Count;
            }
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }

            set
            {
                isUpdated = value;
            }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get
            {
                return measurements[number];
            }
        }

        void IMeasurements.UpdateMeasurements()
        {
            if (isUpdated)
            {
                return;
            }
            if (condition != null)
            {
                if (!(bool)condition.Parameter())
                {
                    isUpdated = true;
                    return;
                }
            }
            Update();
            isUpdated = true;
        }

        #endregion

        #region IRealTimeStartStop Members

        event Action IRealTimeStartStop.OnStart
        {
            add
            {

            }

            remove
            {

            }
        }

        event Action IRealTimeStartStop.OnStop
        {
            add
            {

            }

            remove
            {

            }
        }

        void IRealTimeStartStop.Start()
        {
            Reset();
        }

        void IRealTimeStartStop.Stop()
        {

        }

        #endregion

        #region Public Members

        /// <summary>
        /// Name of condition
        /// </summary>
        public string Condition
        {
            get { return conditionName; }
            set
            {
                conditionName = value;
                IAssociatedObject ass = this;
                if (ass.Object != null)
                {
                    condition = this.FindMeasurement(conditionName, true);
                }
            }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Creates Mesurements
        /// </summary>
        protected void CreateMesurements()
        {
            isLoaded = true;
            measurements.Clear();
            Dictionary<string, IMeasurement> d = this.GetAllMeasurementsByName((double)0);
            List<string> l = new List<string>(d.Keys);
            l.Sort();
            medians = new double[l.Count];
            condition = null;
            IAssociatedObject ass = this;
            if (ass.Object != null)
            {
                condition = this.FindMeasurement(conditionName, true);
            }
            Dictionary<string, IMeasurement> dp = new Dictionary<string, IMeasurement>();
            int i = 0;
            list = new List<double>[l.Count];
            input = new IMeasurement[l.Count];
            foreach (string key in d.Keys)
            {
                int[] p = new int[] { i };
                string k = key.Replace('.', '_').Replace('/', '_');
                IMeasurement m = new Measurement(
                    () => 
                    {
                        return medians[p[0]];
                    }, 
                    k, this);
                measurements.Add(m);
                list[i] = new List<double>();
                input[i] = d[key];
                ++i;
             }
        }

        #endregion

        #region Private Members

        void Update()
        {
            int n = list.Length;
            for (int i = 0; i < n; i++)
            {
                List<double> l = list[i];
                l.Add((double)input[i].Parameter());
                double k = l.Count / 2;
                int m = (int)k;
                if (m < l.Count)
                {
                    l.Sort();
                    medians[i] = l[m];
                }
            }
        }

        void Reset()
        {
            if (condition == null)
            {
                conditionName = "";
            }
            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].Clear();
                    medians[i] = 0;
                }
            }
        }

        #endregion

    }
}
