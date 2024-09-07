using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;

using SerializationInterface;

using Event.Interfaces;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

namespace Event.Basic.Data.Events
{
    /// <summary>
    /// Generate event + write
    /// </summary>
    [Serializable()]
    public class ImportedEventWriter : CategoryObject, ISerializable, IChildrenObject,
        IDataConsumer, IRealtimeUpdate, 
        IPostSetArrow, IDisposable
    {

        #region Fields

        IEventWriter eventWriter;

        string condition = "";

        List<string> measurementsList = new List<string>();

        List<IMeasurements> measurements = new List<IMeasurements>();

        event Action change = () => { };

        IMeasurement[] measures;

        IMeasurement conditionMeasure;

        object[] output;

        IAssociatedObject[] children = new IAssociatedObject[0];

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of imported object</param>
        public ImportedEventWriter(string type)
        {
            Type t = Type.GetType(type);
            ConstructorInfo ci = t.GetConstructor(new Type[0]);
            eventWriter = ci.Invoke(new object[0]) as IEventWriter;
            if (eventWriter is IAssociatedObject)
            {
                children = new IAssociatedObject[] 
                    { eventWriter as IAssociatedObject };
            }
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ImportedEventWriter(SerializationInfo info, StreamingContext context)
        {
            eventWriter = info.Deserialize<IEventWriter>("EventWriter");
            condition = info.GetString("Condition");
            measurementsList = info.GetValue("Measurements", typeof(List<string>)) as List<string>;
            if (eventWriter is IAssociatedObject)
            {
                children = new IAssociatedObject[] 
                    { eventWriter as IAssociatedObject };
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<IEventWriter>("EventWriter", eventWriter);
            info.AddValue("Condition", condition);
            info.AddValue("Measurements", measurementsList, typeof(List<string>));
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return children; }
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
            change();
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
            change();
        }

        void IDataConsumer.UpdateChildrenData()
        {
            foreach (IMeasurements m in measurements)
            {
                m.UpdateMeasurements();
            }
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }

        IMeasurements IDataConsumer.this[int number]
        {
            get { return measurements[number]; }
        }

        void IDataConsumer.Reset()
        {
            foreach (IMeasurements m in measurements)
            {
                m.IsUpdated = false;
            }
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { change += value; }
            remove { change -= value; }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            SetAll();
        }

        #endregion

        #region IRealtimeUpdate Members

        Action IRealtimeUpdate.Update
        {
            get
            {
                return RealtimeUpdate;
            }
        }
  
        event Action IRealtimeUpdate.OnUpdate
        {
            add { }
            remove { }
        }

   
        #endregion

        #region IRemovableObject Members

        void IDisposable.Dispose()
        {
            eventWriter.DisdposeItself();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Condition
        /// </summary>
        public string Condition
        {
            get
            {
                return condition;
            }
            set
            {
                condition = value;
                SetAll();
            }
        }

        /// <summary>
        /// Measurements
        /// </summary>
        public List<string> Measurements
        {
            get
            {
                return new List<string>(measurementsList);
            }
            set
            {
                measurementsList = value;
                SetAll();
            }
        }

        /// <summary>
        /// EventWrite object
        /// </summary>
        public IEventWriter EventWriter
        {
            get
            {
                return eventWriter;
            }
        }

        #endregion

        #region Private Members
        
        void RealtimeUpdate()
        {
             if ((bool)conditionMeasure.Parameter())
            {
                int n = output.Length;
                for (int i = 0; i < n; i++)
                {
                    output[i] = measures[i].Parameter();
                }
                eventWriter.OnEvent(output);
            }
        }


        void SetAll()
        {
            try
            {
                conditionMeasure = this.FindMeasurement(condition, true);
                int n = measurementsList.Count;
                output = new object[n];
                measures = new IMeasurement[n];
                List<Tuple<string, object>> types = new List<Tuple<string, object>>();
                for (int i = 0; i < n; i++)
                {
                    string name = measurementsList[i];
                    IMeasurement m = this.FindMeasurement(name, false);
                    measures[i] = m;
                    object t = m.Type;
                    output[i] = t;
                    types.Add(new Tuple<string, object>(name, t));
                }
                eventWriter.Types = types;
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        #endregion

    }
}
