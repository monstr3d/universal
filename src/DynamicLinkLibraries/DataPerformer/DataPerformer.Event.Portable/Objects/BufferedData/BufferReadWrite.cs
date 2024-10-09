using System;
using System.Collections.Generic;

using CategoryTheory;

using BaseTypes.Attributes;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;
using DataPerformer.Interfaces;
using DataPerformer.Interfaces.BufferedData.Interfaces;
using DataPerformer.Portable.Measurements;

using Event.Interfaces;
using Event.Log.Database.Interfaces;
using Event.Portable;

namespace DataPerformer.Event.Portable.Objects.BufferedData
{

    /// <summary>
    /// Buffer read and write
    /// </summary>
    public class BufferReadWrite : CategoryObject, IDataConsumer, IMeasurements,
        ITimeMeasurementConsumer, IAddRemove, IEventHandler, IIterator, ITimeMeasurementProvider,
        IComponentCollectionHolder, IChangeBufferItem
    {

        #region Fields

        protected List<string> input = new List<string>();

        protected IDataConsumer consumer;

        protected string url = "";

        event Action onChangeInput = () => { };

        IBufferItem item;

        Dictionary<string, object> types = new Dictionary<string, object>();

        IChangeLogItem change = null;

        List<IMeasurements> external = new List<IMeasurements>();

        IBufferDirectory directory;
 
        Dictionary<string, IMeasurement> measurementsWrite;

        ITimeMeasurementConsumer tc;
  
        IMeasurement timeMeasurement;

        Func<object, byte[]> objectToBytes = StaticExtensionDataPerformerInterfaces.ObjectToBytes;

        Func<byte[], object> bytesToObject = StaticExtensionDataPerformerInterfaces.BytesToObject;

        /// <summary>
        /// Add event
        /// </summary>
        protected event Action<IEvent> onAddEvent;

        /// <summary>
        /// Remove event
        /// </summary>
        protected event Action<IEvent> onRemoveEvent;

        List<IMeasurement> measurements = new ();

        protected List<IEvent> events = new ();

        Dictionary<string, object> current = null;

        protected bool directoryIteration = false;

        IEnumerator<object> enumerator;

        double time;

        private readonly DateTime begin = new DateTime();

        IMeasurement timeMeasurementProvider;

        byte[] typeBytes = new byte[0];

        IComponentCollection externalComponentCollection = null;

        IComponentCollection componentCollection = null;

        Action<IBufferItem> changeItem = (IBufferItem item) => { };

        IIterator iterator;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BufferReadWrite()
        {
            consumer = this;
            iterator = this;
            tc = this;

            // !!! The event is added to ensure that the list of inputs is changed as soon as a measurement provider is disconnected; may cause bugs
            // !!! Did cause bugs, because object removal is present in such innocent operation as saving the file. 
            // For that reason, VerifyInput was made non-functional 
            onChangeInput += VerifyInput; 

            timeMeasurementProvider = new TimeMeasurement(() => { return time; });
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
            onChangeInput?.Invoke();
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            external.Remove(measurements);
            onChangeInput?.Invoke();
        }

        void IDataConsumer.Reset()
        {

        }

        void IDataConsumer.UpdateChildrenData()
        {

        }

        #endregion

        #region IAddRemove Members

        void IAddRemove.Add(object obj)
        {

        }

        void IAddRemove.Remove(object obj)
        {

        }

        Type IAddRemove.Type
        {
            get { return typeof(object); }
        }

        event Action<object> IAddRemove.AddAction
        {
            add { }
            remove { }
        }

        event Action<object> IAddRemove.RemoveAction
        {
            add { }
            remove { }
        }

        #endregion

        #region IMeasurements Members

        IMeasurement IMeasurements.this[int number]
        {
            get
            {
                return measurements[number];
            }
        }

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
                return true;
            }

            set
            {

            }
        }

        void IMeasurements.UpdateMeasurements()
        {

        }

        #endregion

        #region IEventHandler Members

        void IEventHandler.Add(IEvent ev)
        {
            events.Add(ev);
            onAddEvent?.Invoke(ev);
        }

        void IEventHandler.Remove(IEvent ev)
        {
            events.Remove(ev);
            onRemoveEvent?.Invoke(ev);
        }

        IEnumerable<IEvent> IEventHandler.Events
        {
            get
            {
                foreach (IEvent ev in events)
                {
                    yield return ev;
                }
            }
        }

        event Action<IEvent> IEventHandler.OnAdd
        {
            add { onAddEvent += value; }
            remove { onAddEvent -= value; }
        }

        event Action<IEvent> IEventHandler.OnRemove
        {
            add { onRemoveEvent += value; }
            remove { onRemoveEvent -= value; }
        }

        #endregion

        #region IChangeBufferItem Members

        event Action<IBufferItem> IChangeBufferItem.Change
        {
            add
            {
                changeItem += value;
            }

            remove
            {
                changeItem -= value;
            }
        }

        #endregion

        #region ITimeMeasurementConsumer Members

        IMeasurement ITimeMeasurementConsumer.Time
        {
            get
            {
                return timeMeasurement;
            }
            set
            {
                timeMeasurement = value;
            }
        }

        #endregion

        #region IIterator Members

        bool IIterator.Next()
        {
            return enumerator.MoveNext();
        }

        void IIterator.Reset()
        {
            IEnumerable<object> enumerable = null;
            if (item is IBufferData)
            {
                enumerable = Enumerable(item as IBufferData);
            }
            else
            {
                directory = item as IBufferDirectory;
                if (directoryIteration)
                {
                    enumerable = DirectoryEnumerable;
                    enumerable.GetEnumerator().MoveNext();
                }
                else
                {
                    enumerable = Enumerable(directory);
                }
            }
            enumerator = enumerable.GetEnumerator();
        }

        #endregion

        #region ITimeMeasureProvider Members
        double ITimeMeasurementProvider.Step
        {
            get
            {
                return 0;
            }

            set
            {
                
            }
        }

        double ITimeMeasurementProvider.Time
        {
            get
            {
                return time;
            }

            set
            {
                
            }
        }

        IMeasurement ITimeMeasurementProvider.TimeMeasurement
        {
            get
            {
                return timeMeasurementProvider;
            }
        }

        #endregion

        #region IComponentCollectionHolder Members

        IComponentCollection IComponentCollectionHolder.ComponentCollection
        {
            get
            {
                return externalComponentCollection;
            }

            set
            {
                externalComponentCollection = value;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// URL 
        /// </summary>
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                try
                {
                    item = value.BufferItemFromUrl();
                    CreateMeasurements();
                }
                catch
                {
                    url = "";
                }
            }
        }

        /// <summary>
        /// Input
        /// </summary>
        public List<string> Input
        {
            get
            {
                return input;
            }
            set
            {
                Dictionary<string, IMeasurement> d = this.GetAllMeasurementsByName();
                foreach (string key in value)
                {
                    if (!d.ContainsKey(key))
                    {
                        ("Illegal measurement: " + key).Show();
                        return;
                    }
                }
                input = value;
            }
        }

        /// <summary>
        /// Creates a file
        /// </summary>
        public void CreateFile()
        {
            WriteTypes();
        }

        /// <summary>
        /// Dictionary of measurements
        /// </summary>
        public Dictionary<string, object> MeasurementsDictionary
        {
            get
            {
                return measurementsWrite.WriteParameters();
            }
        }

        /// <summary>
        /// Performs operation
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <param name="stop">Stop</param>
        public void Perform(Func<object, bool> stop)
        {
            object log = Log;
            object iter = Iterator;
            if (log is ILogReader)
            {
                Perform(log as ILogReader, stop);
            }
            if (iter is IIterator)
            {
                Perform(iter as IIterator, stop);
            }
        }

        /// <summary>
        /// Performs operation
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <param name="stop">Stop</param>
        public void Perform(ILogReader reader, Func<object, bool> stop)
        {
            if (item is IBufferDirectory)
            {
                directory = item as IBufferDirectory;
                WriteTypes();
                IEnumerable<object> en = consumer.RealtimeAnalysisEnumerable(reader, stop,
                    StaticExtensionEventInterfaces.RealtimeLogAnalysis, TimeType.Second, true);
                IEnumerable<byte[]> data = Transform(en);
                IBufferData d = directory.CreateData(data, reader.Name, reader.FileName, "");
                d.Types = typeBytes;
                StaticExtensionDataPerformerInterfaces.Data.SubmitChanges();
            }
        }


        /// <summary>
        /// Performing the log with inprut from an IIterator
        /// </summary>
        /// <param name="iterator"></param>
        /// <param name="stop"></param>
        public void Perform(IIterator iterator, Func<object, bool> stop)
        {
            if (item is IBufferDirectory)
            {
                directory = item as IBufferDirectory;
                WriteTypes();
                /*                StaticExtensionDataPerformerEventPortable.PerformIterator(consumer, iterator as IIterator,
                                    iterator as ITimeMeasureProvider, StaticExtensionEventInterfaces.RealtimeLogAnalysis,
                                    () => { return stop(null); }); */
                IEnumerable<byte[]> data = Transform(iterator, () => {return stop(null); });
                string name;

                if (iterator is BufferReadWrite)
                {
                    name = (iterator as BufferReadWrite).ItemName;
                }
                else
                {
                    name = DateTime.Now.ToString();
                }

                IBufferData d = directory.CreateData(data, name, name, ""); 
                d.Types = typeBytes;
                StaticExtensionDataPerformerInterfaces.Data.SubmitChanges();

            }
        }



        /// <summary>
        /// Writes types
        /// </summary>
        public void WriteTypes()
        {
            measurementsWrite = Measurements;
            Dictionary<string, object> dic = measurementsWrite.WriteTypes();
            typeBytes = objectToBytes(dic);
            object log = Log;
            object iterator = Iterator;
            if (log is ILogReaderCollection | (item is IBufferDirectory & iterator != null))
            {
                directory = (item as IBufferDirectory);               
                directory.Types = typeBytes;
            }
        }

        /// <summary>
        /// Writes itself
        /// </summary>
        public void Write()
        {
            WriteTypes();
            if (!(item is IBufferDirectory))
            {
                "Select directory please".Show();
                return;
            }
            directory = item as IBufferDirectory;
            object log = Log;
            if (log == null)
            {
                    "Select log please".Show();
                return;
            }
            change = GetItem(log);
            if (change != null)
            {
                change.Change += Change;
            }
            componentCollection = this.CreateCollection();
            componentCollection.ForEach((IInitialize initialize) => 
                { initialize.Initialize(); });
            try
            {
                Func<bool> stop = () => { return true; };
                if (log is ILogReaderCollection)
                {
                    ILogReaderCollection c = log as ILogReaderCollection;
                    foreach (ILogReader reader in c.Readers)
                    {
                        Perform(reader);
                    }
                }
                else
                {
                    Perform(log as ILogReader);
                }
                StaticExtensionDataPerformerInterfaces.Data.SubmitChanges();
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
            if (change != null)
            {
                change.Change -= Change;
            }
            change = null;
        }

        /// <summary>
        /// Dorectory iteration
        /// </summary>
        public bool DirectoryIteration
        {
            get { return directoryIteration; }
            set { directoryIteration = value; }
        }

        /// <summary>
        /// Mesurements
        /// </summary>
        public Dictionary<string, IMeasurement> Measurements
        {
            get
            {
                Dictionary<string, IMeasurement> d = new Dictionary<string, IMeasurement>();
                Dictionary<string, IMeasurement> dd = this.GetAllMeasurementsByName();
                foreach (string key in dd.Keys)
                {
                    if (input.Contains(key))
                    {
                        d[key] = dd[key];
                    }
                }
                return d;
            }
        }

        /// <summary>
        /// Provisionary property to name files created from the data from another BufferReadWrite. 
        /// !!! Propose creating a new interface, something like INamedItem to treat both logs and buffers equally.
        ///
        /// </summary>
        public string ItemName
        {
            get
            {
                return item.Name;
            }
        }

        #endregion

        #region Private Members

        void Create(ILogItem item)
        {
            string name = item.Name;
        }

        IChangeLogItem GetItem(object log)
        {
            if (log != null)
            {
                if (log is IChangeLogItem)
                {
                    return log as IChangeLogItem;
                }
            }
            return null;
        }

 
        private object Log
        {
            get
            {
                object l = null;
                IDesktop desktop = this.GetRootDesktop();
                desktop.ForEach((BelongsToCollectionPortable b) =>
                {
                    if (b.Source == consumer)
                    {
                        object o = b.Target;
                        if (o is LogHolder log)
                        {
                            (log as IAssociatedObject).Prepare(true);
                            l = log.Reader;
                        }
                    }
                });
                return l;
            }
        }

        IIterator Iterator
        {
            get
            {
                IIterator iterator = null;
                IDesktop desktop = this.GetRootDesktop();
                desktop.ForEach((BelongsToCollectionPortable b) =>
                {
                    if (b.Source == consumer)
                    {
                        object o = b.Target;
                        if (o is IIterator)
                        {
                            iterator = o as IIterator;
                        }
                    }
                });
                return iterator;
            }
        }


        void Perform(ILogReader reader)
        {
            IEnumerable<object> en = consumer.RealtimeAnalysisEnumerable(reader, Stop,
                StaticExtensionEventInterfaces.RealtimeLogAnalysis, TimeType.Second, true);
            IEnumerable<byte[]> data = Transform(en);
            IBufferData d = directory.CreateData(data, reader.Name, reader.FileName, "");
            d.Types = typeBytes;
        }

        bool Stop(object obj)
        {
            return false;
        }

        void Change(ILogItem item)
        {

        }

        IEnumerable<byte[]> Transform(IEnumerable<object> en)
        {
            foreach (object o in en)
            {
                double t = tc.GetTime();
                DateTime dt = new DateTime();
                dt += TimeSpan.FromSeconds(t);
                object tuple = 
                    new Tuple<DateTime, Dictionary<string, object>>(dt, 
                    measurementsWrite.WriteParameters());
                yield return objectToBytes(tuple);
            }
        }

        IEnumerable<byte[]> Transform(IIterator iterator, Func<bool> stop)
        {
            string reason = StaticExtensionEventInterfaces.RealtimeLogAnalysis;
            using (var backup = 
                new DataPerformer.Portable.Time.TimeProviderBackup(consumer, iterator as ITimeMeasurementProvider, null, reason, 0))
            {
                IDataRuntime runtime = backup.Runtime;
                IStep st = null;
                IMeasurement time = (iterator as ITimeMeasurementProvider).TimeMeasurement;
                if (runtime is IStep)
                {
                    st = runtime as IStep;
                    st.Step = 0;
                }
                iterator.Reset();
                double t = (double)time.Parameter();
                double last = t;
                Action<double, double, long> act = runtime.Step(null,
                    (double timer) =>
                    {
                    }, reason, null);
                int i = 0;
                while (iterator.Next()) //!!! Unifinished?
                {
                    t = (double)time.Parameter();
                    act(last, t, i);
                    ++i;
                    DateTime dt = new DateTime();
                    dt += TimeSpan.FromSeconds(t);
                    object tuple =
                        new Tuple<DateTime, Dictionary<string, object>>(dt,
                        measurementsWrite.WriteParameters());
                    yield return objectToBytes(tuple);
                    if (stop()) break;
                }
            }
        }

        void CreateMeasurements()
        {
            if (item == null)
            {
                return;
            }
            byte[] b = item.Types;
            if (b.Length == 0)
            {
                measurements.Clear();
                return;
            }
            Dictionary<string, object> t = bytesToObject(b) as Dictionary<string, object>;
            if (t.IsEqual(types))
            {
                return;
            }
            types = t;
            measurements.Clear();
            foreach (string key in types.Keys)
            {
                measurements.Add(new Measurement(types[key],
                    () =>
                    {
                        if (current != null)
                        {
                            return current[key];
                        }
                        return null; 
                        /// !!! This line of code throws an exception whenever one tries to call indicators in buffer while no file is added.
                        /// Perhaps change the way the indicators are called, and remove the throw expression altogether; 
                    },
                    key, this));
            }
        }

        IEnumerable<object> PureEnumerable(IBufferData data)
        {
            changeItem(data);
            IEnumerable<byte[]> eb = data.Buffer;
            foreach (byte[] b in eb)
            {
                Tuple<DateTime, Dictionary<string, object>> t
                     = bytesToObject(b) as Tuple<DateTime, Dictionary<string, object>>;
                current = t.Item2;
                time = (t.Item1 - begin).TotalSeconds;
                yield return t;
            }
        }

        IEnumerable<object> Enumerable(IBufferData data)
        {
            changeItem(data);
            IEnumerable<byte[]> eb = data.Buffer;
            bool first = true;
            foreach (byte[] b in eb)
            {
                Tuple<DateTime, Dictionary<string, object>> t
                     = bytesToObject(b) as Tuple<DateTime, Dictionary<string, object>>;
                current = t.Item2;
                time = (t.Item1 - begin).TotalSeconds;
                if (first)
                {
                    if (externalComponentCollection != null)
                    {
                        externalComponentCollection.ForEach((IStarted started) =>
                            { started.Start(time); });
                    }
                    first = false;
                    continue;
                }
                yield return t;
            }
        }
  

        IEnumerable<object> Enumerable(IBufferDirectory directory)
        {
            IEnumerable<IBufferItem> en = directory.FullDirectory();
            foreach (IBufferItem item in en)
            {
                if (item is IBufferData)
                {
                    IBufferData data = item as IBufferData;
                    IEnumerable<object> enu = Enumerable(data);
                    foreach (object o in enu)
                    {
                        yield return o;
                    }
                }
            }
        }

        IEnumerable<object> DirectoryEnumerable
        {
            get
            {                
                IEnumerable<IBufferItem> en = directory.FullDirectory();
                foreach (IBufferItem item in en)
                {
                    if (item is IBufferData)
                    {
                        PerformExternal(item as IBufferData);
                        yield return new object();
                    }
                }
            }
 
        }

        void PerformExternal(IBufferData data)
        {
            string reason = StaticExtensionDataPerformerInterfaces.Calculation;
            IEnumerable<object> en = PureEnumerable(data);
            IEnumerator<object> enumerator = en.GetEnumerator();
            using (var backup = 
                new DataPerformer.Portable.Time.TimeProviderBackup(externalComponentCollection, this, 0, reason))
            {
                enumerator.MoveNext();
                IDataRuntime runtime = backup.Runtime;
                IStep st = null;
                if (runtime is IStep)
                {
                    st = runtime as IStep;
                    st.Step = 0;
                }
                externalComponentCollection.ForEach((IStarted started) => { started.Start(time); });
                double last = time;
                Action<double, double, long> act = runtime.Step(null,
                    (double timer) => { }, reason, null);
                int i = 0;
                while (enumerator.MoveNext())
                {
                    act(last, time, i);
                    ++i;
                    if (st != null)
                    {
                        st.Step = i;
                    }
                    last = time;
                 }
            }
        }

        bool InputExists(string s)
        {
            string str;
            for (int i = 0; i < external.Count; i++)
            {
                str = this.GetMeasurementsName(external[i]);
                for (int j = 0; j < external[i].Count; j++)
                {
                    if (str + "." + external[i][j].Name == s)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        void VerifyInput()
        {
//            input = input.Where<string>(InputExists).ToList();
        }

        #endregion

    }
}
