using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI;

using DataPerformer.Interfaces;

using Event.Interfaces;

namespace Event.Portable.Events
{
    /// <summary>
    /// Imported event with reading data
    /// </summary>
    public class ImportedEventReader : CategoryObject, IEvent, INativeEvent,
       IMeasurements, IChildrenObject, IRemovableObject
    {

        #region Fields

        /// <summary>
        /// Imported event
        /// </summary>
        protected IEventReader actual;


        protected IEventReader eventReader;

        protected List<Tuple<string, object>> types = new List<Tuple<string, object>>();

        protected string eventName = "";

        private Action ev = () => { };

 
        object[] data = new object[0];

        IMeasurement[] measurements = new IMeasurement[0];
   
        IAssociatedObject[] children = new IAssociatedObject[0];

        bool isEnabled = false;


        bool shouldUpdate = true;

        List<Action> events = new List<Action>();


        Action update = () => { };

        IMeasurements child = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of imported object</param>
        public ImportedEventReader(string type)
        {
            if (type.Length == 0)
            {
                return;
            }
            string[] s = type.Split(";".ToCharArray());
            eventReader = s.GetConstructorComposition() as IEventReader;
            if (eventReader is IAssociatedObject)
            {
                children = new IAssociatedObject[] { eventReader as IAssociatedObject };
            }
            eventReader.Change += Change;
            PostCreate();
        }

        static ImportedEventReader()
        {
            /*
            Func<object, bool> f = (object obj) =>
            {
                if (obj is ImportedEventReader)
                {
                    ImportedEventReader r = obj as ImportedEventReader;
                    return r.eventReader.HasAttribute<NativeObjectAttribute>();
                }
                return false;
            };
            f.AddNativeDetector();
            */
        }
        
        #endregion

        #region IEvent Members

        event Action IEvent.Event
        {
            add
            {
                events.Add(value);
                if (isEnabled)
                {
                    ev += value;
                }
            }
            remove
            {
                events.Remove(value);
                if (isEnabled)
                {
                    ev -= value;
                }
            }
        }

        bool IEvent.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                { return; }
                isEnabled = value;
                if (value)
                {
                    foreach (Action act in events)
                    {
                        ev += act;
                    }
                    return;
                }
                 foreach (Action act in events)
                {
                    ev -= act;
                }
            }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measurements.Length; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return measurements[number]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
           // update();
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return true;
            }
            set
            {
      
            }
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return children; }
        }

        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            if (actual != null)
            {
                (this as IEvent).IsEnabled = false;
                actual.EventData -= PostEvent;
            }
            actual = null;
            if (eventReader != null)
            {
                eventReader.Change -= Change;
                eventReader.DisdposeItself();
            }
            eventReader = null;
        }

        #endregion

        #region INativeEvent Members

        void INativeEvent.Force()
        {
            ev();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Name of event
        /// </summary>
        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                CreateActual();
            }
        }

        /// <summary>
        /// Event
        /// </summary>
        public IEventReader EventReader
        {
            get
            {
                return eventReader;
            }
        }

        #endregion

        #region Protected And Private Members

        /// <summary>
        /// Called afrer constucor
        /// </summary>
        protected void PostConstructor()
        {
            if (eventReader is IAssociatedObject)
            {
                children = new IAssociatedObject[] { eventReader as IAssociatedObject };
            }
            eventReader.Change += Change;
            PostCreate();
        }


        private void PostCreate()
        {
            CreateActual();
            CreateMeasurements();
        }

        private void PostEvent(object[] data)
        {
            shouldUpdate = false;
            this.data = data;
            ev();
            shouldUpdate = true;
        }

        private void CreateActual()
        {
            IEventReader a;
            if (eventName.Length == 0)
            {
                if (eventReader.EventNames != null)
                {
                    if (eventReader.EventNames.Length == 1)
                    {
                        eventName = eventReader.EventNames[0];
                    }
                }
            } 
            if (eventName.Length != 0)
            {
                a = eventReader[eventName];
            }
            else
            {
                a = eventReader;
            }
            if (actual == a)
            {
                return;
            }
            if (actual != null)
            {
                actual.EventData -= PostEvent;
            }
            actual = a;
            List<Tuple<string, object>> at = actual.Types;
            if (actual is IAssociatedObject & children[0] != actual)
            {
                children = new IAssociatedObject[] { actual as IAssociatedObject };
            }
            types = at;
            actual.EventData += PostEvent;
            if (actual is IMeasurements)
            {
                child = actual as IMeasurements;
                update = () =>
                    {
                        if (shouldUpdate)
                        {
                            child.IsUpdated = false;
                            child.UpdateMeasurements();
                        }
                    };
            }
        }

        private void Change()
        {
            try
            {
                CreateActual();
                if (actual.Types != null)
                {
                    List<Tuple<string, object>> t = actual.Types;
                    if (!types.Equals(t))
                    {
                        types = t;
                        int n = t.Count;
                        data = new object[n];
                        measurements = new IMeasurement[n];
                        for (int i = 0; i < n; i++)
                        {
                            measurements[i] = new DataMeasurement(this, i);
                            data[i] = t[i].Item2;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        void CreateMeasurements()
        {
            CreateActual();
            int n = types.Count;
            data = new object[n];
            measurements = new IMeasurement[n];
            for (int i = 0; i < n; i++)
            {
                measurements[i] = new DataMeasurementReplace(this, i);
                data[i] = types[i].Item2;
            }
        }

        #endregion

        #region DataMeasure Class

        class DataMeasurement : IMeasurement
        {
            #region Fields

            protected Func<object> par;

            string name;

            object type;

            #endregion

            #region Ctor

            internal DataMeasurement(ImportedEventReader data, int i)
            {
                Tuple<string, object> t = data.types[i];
                name = t.Item1.Replace('/', '_').Replace('.', '_');
                if (data.eventName.Length > 0)
                {
                    name = data.eventName + "_" + name;
                }
                type = t.Item2;
                par = () => { return data.data[i]; };
            }

            #endregion

            #region IMeasurement Members

            Func<object> IMeasurement.Parameter
            {
                get { return par; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return type; }
            }

            #endregion
        }

        class DataMeasurementReplace : DataMeasurement, IReplacedMeasurementParameter
        {
            #region Fields

            Func<object> ownParameter;

            #endregion

            #region Ctor

            internal DataMeasurementReplace(ImportedEventReader data, int i) : base(data, i)
            {
      
            }

            #endregion

            #region IReplacedMeasureParameter Members

            void IReplacedMeasurementParameter.Replace(Func<object> parameter)
            {
                if (ownParameter != null)
                {
                    throw new Exception();
                }
                ownParameter = par;
                par = parameter;
            }

            void IReplacedMeasurementParameter.Reset()
            {
                if (ownParameter == null)
                {
                    throw new Exception();
                }
                par = ownParameter;
                ownParameter = null;
            }

            #endregion

        }

        #endregion

    }
}