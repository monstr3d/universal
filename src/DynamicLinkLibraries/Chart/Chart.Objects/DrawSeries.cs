using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using CategoryTheory;
using Chart.Drawing;
using Chart.Drawing.Interfaces;
using Chart.Drawing.Interfaces.Points;
using DataPerformer;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using NamedTree;

namespace Chart.Objects
{
    [Serializable()]
    public class DrawSeries : CategoryObject, ISerializable, IDataConsumer, ISeries,
        IPostSetArrow, IIteratorConsumer
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        string factoryName;

        List<IIterator> iterators = new List<IIterator>();

        double[,] size = new double[2, 2];

        IPointFactory factory = new PointBaseFactory(6);


        List<string> measurements = new List<string>();

        List<IMeasurement> measures = new List<IMeasurement>();

        List<IMeasurements> measurementsData = new List<IMeasurements>();

        List<IPoint> points = new List<IPoint>();

        IDataConsumer consumer;

        object[] objs;

        #endregion

        #region Ctor

        public DrawSeries()
        {
            consumer = this;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DrawSeries(SerializationInfo info, StreamingContext context)
        {
            consumer = this;
            factoryName = info.GetValue("FactoryName", typeof(string)) as string;
            measurements = info.GetValue("Measurements", typeof(List<string>)) as List<string>;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FactoryName", factoryName, typeof(string));
            info.AddValue("Measurements", measurements, typeof(List<string>));
        }

        #endregion

        #region IDataConsumer Members

        void IChildren<IMeasurements>.AddChild(IMeasurements measurements)
        {
            measurementsData.Add(measurements);
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements measurements)
        {
            measurementsData.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            foreach (IMeasurements m in measurementsData)
            {
                m.UpdateMeasurements();
            }
        }

        int IDataConsumer.Count
        {
            get { return measurementsData.Count; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurementsData[n]; }
        }

        void IDataConsumer.Reset()
        {
            this.FullReset();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region ISeries Members

        double[,] ISeries.Size
        {
            get { return size; }
        }

        IList<IPoint> ISeries.Points
        {
            get { return points; }
        }

        int ISeries.YCount => 1;

        void ISeries.Add(IPoint point)
        {
            points.Add(point);
        }


        #endregion

        #region IIteratorConsumer Members

        void IIteratorConsumer.Add(IIterator iterator)
        {
            iterators.Add(iterator);
        }

        void IIteratorConsumer.Remove(IIterator iterator)
        {
            iterators.Remove(iterator);
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            FactoryName = factoryName;
            Measurements = measurements;
        }

        #endregion

        #region Specific Members

        public IPointFactory Factory
        {
            get
            {
                return factory;
            }
        }

        public List<string> AllMeasures
        {
            get
            {
                return consumer.GetAllMeasurements(null);
            }
        }

        public List<string> Measurements
        {
            get
            {
                return measurements;
            }
            set
            {
                acceptMeasurements(value);
                create();
            }
        }

        public string FactoryName
        {
            get
            {
                return factoryName;
            }
            set
            {
                if (StaticExtensionChartInterfaces.PointFactory != null)
                {
                    factory = StaticExtensionChartInterfaces.PointFactory[value];
                }
                factoryName = value;
            }
        }

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurementsData;

        private void acceptMeasurements(List<string> measurements)
        {
            object[] t = factory.Types;
            objs = new object[t.Length];
            if (t.Length != measurements.Count)
            {
                throw new Exception("Illegal number of measurements");
            }
            for (int i = 0; i < t.Length; i++)
            {
                IMeasurement m = this.FindMeasurement(measurements[i], false);
                if (!t[i].Equals(m.Type))
                {
                    throw new Exception("Illegal measure type");
                }

            }
            this.measurements = measurements;
            measures.Clear();
            foreach (string s in measurements)
            {
                IMeasurement m = this.FindMeasurement(s, false);
                measures.Add(m);
            }
        }

        private void create()
        {
            List<IIterator> it = iterators;
            if (it.Count == 0)
            {
                this.GetIterators(it);
            }
            if (it.Count == 0)
            {
                return;
            }
            foreach (IIterator i in it)
            {
                i.Reset();
            }
            points.Clear();
            while (true)
            {
                iterate:
                foreach (IIterator i in it)
                {
                    if (!i.Next())
                    {
                        StaticExtensionChartInterfaces.GetSize(this, size);
                        return;
                    }
                }
                consumer.Reset();
                consumer.UpdateChildrenData();
                for (int i = 0; i < measures.Count; i++)
                {
                    object o = measures[i].Parameter();
                    if (o == null | o is DBNull)
                    {
                        goto iterate;
                    }
                    objs[i] = o;
                }
                IPoint p = factory.CreatePoint(objs);
                points.Add(p);

             }
        }

        #endregion


    }
}
