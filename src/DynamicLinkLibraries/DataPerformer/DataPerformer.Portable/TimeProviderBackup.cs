using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using DataPerformer.Interfaces;

using Diagram.UI;
using Diagram.UI.Interfaces;

namespace DataPerformer.Portable
{

    /// <summary>
    /// Backup of time provider
    /// </summary>
    public class TimeProviderBackup : IDisposable
    {
        #region Fields

        Dictionary<ITimeMeasureConsumer, IMeasurement> dictionary = new Dictionary<ITimeMeasureConsumer, IMeasurement>();

        IDataConsumer consumer;

        IComponentCollection collection;

        IDataRuntime runtime;

        IDifferentialEquationProcessor processor;

        List<IMeasurements> measurements = null;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="provider">Time provider</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        public TimeProviderBackup(IComponentCollection collection, ITimeMeasureProvider provider,
           int priority, string reason)
        {
            this.collection = collection;
            CreateMeasurements(priority, reason);
            runtime = StaticExtensionDataPerformerPortable.Factory.Create(collection, priority, reason);
            SetTimeProvider(collection, provider, dictionary);
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="provider">Time provider</param>
        /// <param name="processor">Differential equation processor</param>
        /// <param name="reason">Reason</param>
        /// <param name="priority">Priority</param>
        public TimeProviderBackup(IDataConsumer consumer, ITimeMeasureProvider provider, IDifferentialEquationProcessor processor, string reason, int priority)
        {
            this.consumer = consumer;
            collection = consumer.GetDependentCollection(priority);
            SetTimeProvider(collection, provider, dictionary);
            CreateMeasurements(priority, null);
            runtime = consumer.CreateRuntime(reason, priority);
            this.processor = processor;
            if (processor != null)
            {
                processor.Set(collection); // !!! added to allow buffer processing, as no IDifferentialEquationProcessoris required there
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="provider">Time provider</param>
        /// <param name="processor">Differential equation processor</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        public TimeProviderBackup(IComponentCollection collection, ITimeMeasureProvider provider,
            IDifferentialEquationProcessor processor, int priority, string reason)
        {
            this.collection = collection;
            CreateMeasurements(priority, reason);
            runtime = StaticExtensionDataPerformerPortable.Factory.Create(collection, priority);
            SetTimeProvider(collection, provider, dictionary);
            this.processor = processor;
            processor.Set(collection);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        public TimeProviderBackup(IComponentCollection collection, int priority, string reason)
        {
            this.collection = collection;
            CreateMeasurements(priority, reason);
            runtime = StaticExtensionDataPerformerPortable.Factory.Create(collection, priority);
            SetTimeProvider(collection, StaticExtensionDataPerformerPortable.Factory.TimeProvider, dictionary);
            processor = DifferentialEquationProcessors.DifferentialEquationProcessor.Processor;
            processor.Set(collection);
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (collection != null)
            {
                collection.ForEach<IStopped>((IStopped stop) => { stop.Stop(); });
                Reset(collection);
                dictionary.Clear();
                return;
            }
            Reset(consumer);
            dictionary.Clear();
            if (runtime is IDisposable)
            {
                IDisposable d = runtime as IDisposable;
                d.Dispose();
            }
            if (processor != null)
            {
                processor.Clear();
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Runtime
        /// </summary>
        public IDataRuntime Runtime
        {
            get
            {
                return runtime;
            }
        }

        /// <summary>
        /// Measurements
        /// </summary>
        public List<IMeasurements> Measurements
        {
            get
            {
                return measurements;
            }
        }


        static void SetTimeProvider(object o, ITimeMeasureProvider provider, IDictionary<ITimeMeasureConsumer, IMeasurement> dictionary)
        {
            ITimeMeasureConsumer tc = o.GetLabelObject<ITimeMeasureConsumer>();
            if (tc != null)
            {
                if (dictionary.ContainsKey(tc))
                {
                    if (tc.Time != provider.TimeMeasurement)
                    {
                        dictionary[tc] = tc.Time;
                        tc.Time = provider.TimeMeasurement;
                    }
                }
                else
                {
                    dictionary[tc] = tc.Time;
                    tc.Time = provider.TimeMeasurement;
                }
            }
            IChildrenObject co = o.GetLabelObject<IChildrenObject>();
            if (co != null)
            {
                IAssociatedObject[] ch = co.Children;
                if (ch != null)
                {
                    foreach (object ob in ch)
                    {
                        SetTimeProvider(ob, provider, dictionary);
                    }
                }
            }
        }


        private static void SetTimeProvider(IComponentCollection collection,
            ITimeMeasureProvider provider, IDictionary<ITimeMeasureConsumer, IMeasurement> dictionary)
        {
            IEnumerable<object> c = collection.AllComponents;
            foreach (object o in c)
            {
                SetTimeProvider(o, provider, dictionary);
            }
        }

        private void Reset(object o)
        {
            if (o is ITimeMeasureConsumer)
            {
                ITimeMeasureConsumer tc = o as ITimeMeasureConsumer;
                if (dictionary.ContainsKey(tc))
                {
                    tc.Time = dictionary[tc];
                }
            }
            if (o is IChildrenObject)
            {
                IChildrenObject co = o as IChildrenObject;
                IAssociatedObject[] ch = co.Children;
                foreach (object ob in ch)
                {
                    Reset(ob);
                }
            }
        }


        private void Reset(IDesktop desktop)
        {
            IEnumerable<ICategoryObject> co = desktop.CategoryObjects;
            foreach (object o in co)
            {
                Reset(o);
            }
        }


        /// <summary>
        /// Sets time provider to data consumer and all dependent objects
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="provider">Data provider</param>
        /// <param name="dictionary">Backup dictionary</param>
        private static void SetTimeProvider(IDataConsumer consumer,
            ITimeMeasureProvider provider, IDictionary<ITimeMeasureConsumer, IMeasurement> dictionary)
        {
            if (consumer is ITimeMeasureConsumer)
            {
                ITimeMeasureConsumer tc = consumer as ITimeMeasureConsumer;
                if (dictionary.ContainsKey(tc))
                {
                    if (tc.Time != provider.TimeMeasurement)
                    {
                        dictionary[tc] = tc.Time;
                        tc.Time = provider.TimeMeasurement;
                    }
                }
                else
                {
                    dictionary[tc] = tc.Time;
                    tc.Time = provider.TimeMeasurement;
                }
            }
            // IDataRuntime dr = consumer.CreateRuntime();
        }

        static void SetTimeProvider(IChildrenObject co, ITimeMeasureProvider provider, IDictionary<ITimeMeasureConsumer, IMeasurement> dictionary)
        {
            IAssociatedObject[] ao = co.Children;
            foreach (object o in ao)
            {
                if (o is IDataConsumer)
                {
                    IDataConsumer dc = o as IDataConsumer;
                    SetTimeProvider(dc, provider, dictionary);
                }
                else if (o is IMeasurements)
                {
                    IMeasurements mea = o as IMeasurements;
                    SetTimeProvider(mea, provider, dictionary);
                }
                if (o is IChildrenObject)
                {
                    IChildrenObject cho = o as IChildrenObject;
                    SetTimeProvider(cho, provider, dictionary);
                }
            }
        }

        static void SetTimeProvider(IMeasurements m, ITimeMeasureProvider provider, IDictionary<ITimeMeasureConsumer, IMeasurement> dictionary)
        {
            if (m is ITimeMeasureConsumer)
            {
                ITimeMeasureConsumer mc = m as ITimeMeasureConsumer;
                if (dictionary.ContainsKey(mc))
                {
                    if (mc.Time != provider.TimeMeasurement)
                    {
                        dictionary[mc] = mc.Time;
                        mc.Time = provider.TimeMeasurement;
                    }
                }
                else
                {
                    dictionary[mc] = mc.Time;
                    mc.Time = provider.TimeMeasurement;
                }
            }
            if (m is IDataConsumer)
            {
                IDataConsumer dc = m as IDataConsumer;
                SetTimeProvider(dc, provider, dictionary);
            }
            if (m is MeasurementsWrapper)
            {
                MeasurementsWrapper mw = m as MeasurementsWrapper;
                int n = mw.Count;
                for (int i = 0; i < n; i++)
                {
                    SetTimeProvider(mw[i], provider, dictionary);
                }
            }
        }

        private void Reset(IDataConsumer consumer)
        {
            if (consumer is ITimeMeasureConsumer)
            {
                ITimeMeasureConsumer tc = consumer as ITimeMeasureConsumer;
                if (dictionary.ContainsKey(tc))
                {
                    tc.Time = dictionary[tc];
                }
            }
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                if (m is ITimeMeasureConsumer)
                {
                    ITimeMeasureConsumer mc = m as ITimeMeasureConsumer;
                    if (dictionary.ContainsKey(mc))
                    {
                        mc.Time = dictionary[mc];
                    }
                }
                if (m is IDataConsumer)
                {
                    IDataConsumer dc = m as IDataConsumer;
                    Reset(dc);
                }
            }
        }

        private void CreateMeasurements(int priority, string reason)
        {
            List<IMeasurements> l = new List<IMeasurements>();
            collection.ForEach<IDataConsumer>((IDataConsumer c) =>
            {
                if (c.SatisfiesReason(reason))
                {
                    for (int i = 0; i < c.Count; i++)
                    {
                        IMeasurements m = c[i];
                        if (!l.Contains(m))
                        {
                            l.Add(m);
                        }
                    }
                }
            });
            collection.ForEach<IMeasurements>((IMeasurements m) =>
            {

                if (priority == 0)
                {
                    if (!l.Contains(m))
                    {
                        l.Add(m);
                    }
                }
                else
                {
                    int n = m.GetPriority();
                    if (n == 0)
                    {
                        l.Add(m);
                    }
                    else
                    {
                        if (n < priority)
                        {
                            l.Add(m);
                        }
                    }
                }
            }
            );
            List<IMeasurements> add = new List<IMeasurements>();
            l.Sort(StaticExtensionDiagramUI.ObjectComparer);
            measurements = l;
            measurements.SortMeasurements();
        }

        #endregion
    }

}
