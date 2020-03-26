using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;


using Diagram.UI.Interfaces;
using Diagram.UI;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.DifferentialEquationProcessors;
using DataPerformer.Portable.Measurements;

namespace DataPerformer
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
            SetCollectionHolders();
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
        public TimeProviderBackup(IDataConsumer consumer, ITimeMeasureProvider provider, 
            IDifferentialEquationProcessor processor, string reason, int priority)
        {
            this.consumer = consumer;
            collection = consumer.GetDependentCollection(priority);
            SetCollectionHolders();
            List<object> l = new List<object>(collection.AllComponents);
            if (!l.Contains(consumer))
            {
                l.Add(consumer);
            }
            SetTimeProvider(l, provider, dictionary);
            CreateMeasurements(priority, null);
            runtime = consumer.CreateRuntime(reason, priority);
            if (processor != null)
            {
                this.processor = processor;
                processor.Set(collection);
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
            SetCollectionHolders();
            CreateMeasurements(priority, reason);
            runtime = StaticExtensionDataPerformerPortable.Factory.Create(collection, priority);
            SetTimeProvider(collection.AllComponents, provider, dictionary);
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
            SetCollectionHolders();
            CreateMeasurements(priority, reason);
            runtime = StaticExtensionDataPerformerPortable.Factory.Create(collection, priority);
            SetTimeProvider(collection.AllComponents, StaticExtensionDataPerformerPortable.Factory.TimeProvider, dictionary);
            processor = DifferentialEquationProcessor.Processor;
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

        #region Public Members

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

        #endregion


        #region Internal Members

        internal List<IMeasurements> Measurements
        {
            get
            {
                return measurements;
            }
        }

        #endregion

        #region Private Members

        static void SetTimeProvider(object o, ITimeMeasureProvider provider, IDictionary<ITimeMeasureConsumer, IMeasurement> dictionary)
        {
            ITimeMeasureConsumer tc = o.GetLabelObject<ITimeMeasureConsumer>();
            IMeasurement timeMeasurement = provider.TimeMeasurement;
            if (!(timeMeasurement is TimeMeasurement))
            {
                throw new Exception();
            }
            Func<object> f = timeMeasurement.Parameter;
            if (tc != null)
            {
                TimeMeasurement tmr = tc.Time as TimeMeasurement;
                if (tmr == null)
                {
                    tc.Time = new TimeMeasurement(() => { return (double)0; });
                }
                tmr = tc.Time as TimeMeasurement;
                if (dictionary.ContainsKey(tc))
                {
                    if (tc.Time != provider.TimeMeasurement)
                    {
                        dictionary[tc] = tc.Time;
                        if (tmr != null)
                        {
                            tmr.TimeParameter = f;
                        }
                    }
                }
                else
                {
                    dictionary[tc] = tc.Time;
                    if (tmr != null)
                    {
                        tmr.TimeParameter = f;
                    }
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
     
        private static void SetTimeProvider(IEnumerable<object> c, ITimeMeasureProvider provider, IDictionary<ITimeMeasureConsumer, IMeasurement> dictionary)
        {
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
                IMeasurement m = tc.Time;
                if (m != null)
                {
                    if (dictionary.ContainsKey(tc))
                    {
                        (tc.Time as TimeMeasurement).TimeParameter = dictionary[tc].Parameter;
                    }
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
                IMeasurement timeMeasurement = provider.TimeMeasurement;
                if (!(timeMeasurement is TimeMeasurement))
                {
                    throw new Exception();
                }
                Func<object> f = provider.TimeMeasurement.Parameter;
                if (dictionary.ContainsKey(tc))
                {
                    if (tc.Time != provider.TimeMeasurement)
                    {
                        dictionary[tc] = tc.Time;
                        (tc.Time as TimeMeasurement).TimeParameter = provider.TimeMeasurement.Parameter;
                    }
                }
                else
                {
                    dictionary[tc] = tc.Time;
                    (tc.Time as TimeMeasurement).TimeParameter = provider.TimeMeasurement.Parameter;
                }
            }
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
                        (mc.Time as TimeMeasurement).TimeParameter = provider.TimeMeasurement.Parameter;
                    }
                }
                else
                {
                    dictionary[mc] = mc.Time;
                    (mc.Time as TimeMeasurement).TimeParameter = provider.TimeMeasurement.Parameter;
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
                    (tc.Time as TimeMeasurement).TimeParameter  = dictionary[tc].Parameter;
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
            collection.ForEach((IDataConsumer c) =>
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
            collection.ForEach((IMeasurements m) =>
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

        void SetCollectionHolders()
        {
            collection.ForEach((IComponentCollectionHolder holder) => { holder.ComponentCollection = collection; });
        }


        #endregion
    }
}