using System;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataPerformer.Interfaces;
using DataPerformer.Interfaces.Attributes;

using ErrorHandler;

using NamedTree.Interfaces;


namespace DataPerformer.Portable.Wrappers
{
    /// <summary>
    /// Wrapper of data consumer
    /// </summary>
    public class DataConsumerWrapper : CommonWrapper
    {
        /// <summary>
        /// The data consumer
        /// </summary>
        public IDataConsumer Consumer { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="consumer"> The data consumer</param>
        public DataConsumerWrapper(IDataConsumer consumer)
        {
            Consumer = consumer;
        }

        #region PefrormIterator

        /// <summary>
        /// Performs iterator
        /// </summary>
        /// <param name="iterator">The iterator</param>
        /// <param name="output">The output map</param>
        /// <param name="cancellation">Cancellation</param>
        /// <param name="stop">Stop function</param>
        /// <param name="preparation">Preparation</param>
        /// <param name="errorHandler">Eroor handler</param>
        /// <returns>Result</returns>
      public async Task<List<Dictionary<string, object>>> PerformIteratorAsync(IIterator iterator,
      Dictionary<string, string> output,
      CancellationToken cancellation,
      Func<bool> stop = null, Action preparation = null,
       IExceptionHandler errorHandler = null)
        {
            var d = new Dictionary<string, IMeasurement>();
            try
            {
                foreach (var entry in output)
                {
                    var m = FindMeasurement(entry.Value);
                    if (m == null)
                    {
                        return null;
                    }
                    d[entry.Key] = FindMeasurement(entry.Value);
                }
            }
            catch (Exception ex)
            {
                errorHandler.HandleException(ex);
                return null;
            }
            return await PerformIteratorAsync(iterator, d, cancellation, stop, 
                preparation, errorHandler);
        }

        /// <summary>
        /// Performs iterator
        /// </summary>
        /// <param name="iterator">The iterator</param>
        /// <param name="stop">The stop</param>
        /// <param name="preparation">The preparation action</param>
        /// <param name="errorHandler">The error handler</param>
        public async Task<List<Dictionary<string, object>>> PerformIteratorAsync(IIterator iterator,
          CancellationToken cancellation,
          Func<bool> stop = null, Action preparation = null,
           IExceptionHandler errorHandler = null)
        {
            var d = performer.GetMeasuremetDictionary(Consumer);
            return await PerformIteratorAsync(iterator, d, cancellation,
           stop, preparation,
             errorHandler);
        }

        /// <summary>
        /// Performs iterator
        /// </summary>
        /// <param name="iterator">The iterator</param>
        /// <param name="output">The output</param>
        /// <param name="stop">The stop</param>
        /// <param name="preparation">The preparation action</param>
        /// <param name="errorHandler">The error handler</param>
        public async Task<List<Dictionary<string, object>>> PerformIteratorAsync(IIterator iterator,
          Dictionary<string, IMeasurement> output, 
          CancellationToken cancellation, 
          Func<bool> stop = null, Action preparation = null,
           IExceptionHandler errorHandler = null)
        {
            Func<bool> st = (stop == null) ? () => false : stop;
            var b = true;
            var l = new List<Dictionary<string, object>>();
            var action = () =>
            {
                var dic = new Dictionary<string, object>();
                foreach (var i in output)
                { 
                    var o = i.Value.Parameter();
                    if (o is ICloneable cl)
                    {
                        o = cl.Clone();
                    }
                    dic[i.Key] = o;
                }
                l.Add(dic);
            };
            await PerformIteratorAsync(iterator, action, cancellation, stop, preparation, errorHandler);
            return l;
        }

        /// <summary>
        /// Performs iterator
        /// </summary>
        /// <param name="iterator">The iterator</param>
        /// <param name="action">The action</param>
        /// <param name="stop">The stop</param>
        /// <param name="preparation">The preparation action</param>
        /// <param name="errorHandler">The error handler</param>
        public async Task PerformIteratorAsync(IIterator iterator,
           Action action, CancellationToken cancellation, Func<bool> stop = null,
           Action preparation = null,
           IExceptionHandler errorHandler = null)
        {
            Func<bool> st = (stop == null) ? () => false : stop;
            var b = true;
            IComponentCollection coll;
            try
            {
                var d = Consumer.GetRootConsumerDesktop();
                await StartAsync(d, cancellation);
                iterator.Reset();
                Consumer.ResetAll();
                var rt = Consumer.CreateRuntime(null);
                coll = Consumer.GetDependentCollection();
                coll.ForEach((IRunning s) => s.IsRunning = true);

                Action act = () =>
                {
                    rt.UpdateAll();
                };
                var attr = CustomAttributeExtensions.GetCustomAttribute<IteratorTypeAttribute>
                    (IntrospectionExtensions.GetTypeInfo(iterator.GetType()));
                if (attr != null)
                {
                    if (attr.Log)
                    {
                        act = () => { };
                    }
                }
                preparation?.Invoke();
                while (true)
                {
                    if (cancellation.IsCancellationRequested)
                    {
                        return;
                    }
                    if (st())
                    {
                        return;
                    }
                    if (!iterator.Next())
                    {
                        return;
                    }
                    act();
                    action?.Invoke();
                }
            }
            catch (Exception e)
            {
                if (errorHandler != null)
                {
                    errorHandler.HandleException(e, null);
                }
                else
                {
                    e.HandleException(null);
                }
            }
            coll = Consumer.GetDependentCollection();
            coll.ForEach((IRunning s) => s.IsRunning = false);
        }


        #endregion

        #region PerformFixed

        void PerformFixed(double start, double step, int count,
                 ITimeMeasurementProvider provider,
                   IDifferentialEquationProcessor processor, string reason,
                  int priority, CancellationToken token, Action action, IMeasurement condition = null,
                 IAsynchronousCalculation asynchronousCalculation = null,
                  IExceptionHandler errorHandler = null)
        {

            Func<bool> stop = () => token.IsCancellationRequested;
            PerformFixed(start, step, count, provider, processor,
                reason, priority, action,
                           condition,
                       stop = null,
             asynchronousCalculation, errorHandler);

        }



        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="provider">Provider of time measure</param>
        /// <param name="processor">Differential equation processor</param>
        /// <param name="reason">Reason</param>
        /// <param name="priority">Priority</param>
        /// <param name="action">Additional action</param>
        /// <param name="stop">Stop function</param>
        /// <param name="asynchronousCalculation">Asynchronous calculation</param>
        /// <param name="errorHandler">Error handler</param>
        void PerformFixed(double start, double step, int count,
                ITimeMeasurementProvider provider,
                  IDifferentialEquationProcessor processor,
                  string reason,
                 int priority,
                 Action action,
                 IMeasurement condition = null,
                 Func<bool> stop = null,
                 IAsynchronousCalculation asynchronousCalculation = null,
                 IExceptionHandler errorHandler = null)
        {
            ITimeMeasurementProvider old = processor.TimeProvider;
            var stp = stop;
            if (stp == null)
            {
                stp = () => false;
            }
            Action acts = action;
            if (condition != null)
            {
                acts = () =>
                {
                    if ((bool)condition.Parameter())
                    {
                        action();
                    }
                };
            }
            try
            {
                using var backup = new TimeProviderBackup(Consumer, provider, processor, reason, priority);
                var p = backup.Processor;
                provider.Time = start;
                IDataRuntime runtime = backup.Runtime;
                runtime.TimeProvider = provider;
                runtime.StartAll(start);
                p.TimeProvider = provider;
                IStep st = null;
                if (runtime is IStep)
                {
                    st = runtime as IStep;
                }
                provider.Time = start;
                double t = start;
                double last = t;
                Action<double, double, long>
                    act = runtime.Step(p,
                    (time) =>
                    {
                        provider.Time = time;
                    }
                    , reason, asynchronousCalculation);
                for (int i = 0; i < count; i++)
                {
                    if (stp())
                    {
                        break;
                    }
                    t = start + i * step;
                    act(last, t, i);
                    last = t;
                    acts?.Invoke();
                }
            }
            catch (Exception ex)
            {
                if (errorHandler != null)
                {
                    int i = 10;
                    object o = i;
                    errorHandler.HandleException<Exception>(ex, o);
                }
                else
                {
                    ex.HandleException(10);
                }
            }
            processor.TimeProvider = old;
        }

  
        public void PerformFixed(double start, double step, int count,
    ITimeMeasurementProvider provider,
    IDifferentialEquationProcessor processor, string reason,
    int priority, Action action, string condition = null, Func<bool> stop = null, IAsynchronousCalculation asynchronousCalculation = null,
    IExceptionHandler errorHandler = null)
        {
            IMeasurement cm = null;
            if (condition != null)
            {
                cm = FindMeasurement(condition);
            }
            PerformFixed(start, step, count,
                provider,
                   processor, reason,
                  priority, action, cm, stop, asynchronousCalculation,
                  errorHandler);
        }


        public void PerformFixed(double start, double step, int count,
            ITimeMeasurementProvider provider,
            IDifferentialEquationProcessor processor, string reason,
            int priority, CancellationToken token,  Action action, string condition = null,  IAsynchronousCalculation asynchronousCalculation = null,
            IExceptionHandler errorHandler = null)
        {
            IMeasurement cm = null;
            if (condition != null)
            {
                cm = FindMeasurement(condition);
            }
            PerformFixed(start, step, count,
                provider,
                   processor, reason,
                  priority, token, action, cm, asynchronousCalculation,
                  errorHandler);
        }


        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="provider">Provider of time measure</param>
        /// <param name="processor">Differential equation processor</param>
        /// <param name="reason">Reason</param>
        /// <param name="priority">Priority</param>
        /// <param name="paramerets">Parameters</param>
        /// <param name="condition">Condition</param>
        /// <param name="stop">Stop function</param>
        /// <param name="errorHandler">Error handler</param>
        /// <param name="asynchronousCalculation">Asynchronous calculation</param>
        /// <param name="errorHandler">Asynchronous calculation</param>
        /// <returns></returns>
        public List<List<object>> PerformFixed(double start, double step, int count,
        ITimeMeasurementProvider provider,
        IDifferentialEquationProcessor processor, string reason,
        int priority, string condition, IEnumerable<string> paramerets, Func<bool> stop = null, IAsynchronousCalculation asynchronousCalculation = null,
        IExceptionHandler errorHandler = null)
        {
            var list = new List<List<object>>();
            var m = new List<IMeasurement>();
            foreach (var s in paramerets)
            {
                m.Add(FindMeasurement(s));
            }
            var measurements = m.ToArray();
            Action action = () =>
            {
                var l = new List<object>();
                foreach (var measurement in measurements)
                {
                    l.Add(measurement.Parameter());
                }
                list.Add(l);
            };
            PerformFixed(start, step, count, provider,
            processor, reason, priority, action, condition, stop,
            asynchronousCalculation, errorHandler);
            return list;
        }

        #endregion

        #region CreateXmlDocument


        ///<summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="iterator">The iterator</param>
        /// <param name="output">Output parameters</param>
        /// <param name="errorHandler">Error handler</param>
        /// <returns>The Xml document</returns>

        public async Task<XmlDocument> CreateXmlDocumentAsync(IIterator iterator, Dictionary<string, string> output,
         CancellationToken token, ITimeMeasurementProvider provider,
        IDifferentialEquationProcessor processor, IExceptionHandler errorHandler = null)
        {
            XmlParameterWriter xpv = new XmlParameterWriter(null);
            IParameterWriter pvv = xpv;
            var d = FindMeasurements(output);
            Action action = () =>
            {
                Dictionary<string, string> dpp = new Dictionary<string, string>();
                foreach (var k in d)
                {
                    object v = k.Value;
                    dpp[k.Key] = v + "";
                }
                pvv.Write(dpp);
            };
            await PerformIteratorAsync(iterator, action, token, null, null, errorHandler);
            return xpv.Document;
        }

        ///<summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="output">Output parameters</param>
        /// <param name="condition">Condition</param>
        /// <param name="stop">Stop function</param>
        /// <param name="start">Start time</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count</param>
        /// <param name="errorHandler">Error handler</param>
        /// <returns>The Xml document</returns>
        public XmlDocument CreateXmlDocument(Dictionary<string, string> output,
             double start, double step, int count, string condition,
         CancellationToken token, ITimeMeasurementProvider provider,
        IDifferentialEquationProcessor processor, IExceptionHandler errorHandler = null)
        {
            var stop = () => token.IsCancellationRequested;
            return CreateXmlDocument(output,
                start,
                step,
                count,
                condition,
                stop,
                provider,
                processor, 
                errorHandler);
        }



        ///<summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="output">Output parameters</param>
        /// <param name="condition">Condition</param>
        /// <param name="stop">Stop function</param>
        /// <param name="start">Start time</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count</param>
        /// <param name="errorHandler">Error handler</param>
        /// <returns>The Xml document</returns>
        public XmlDocument CreateXmlDocument(Dictionary<string, string> output,
             double start, 
             double step, 
             int count, 
             string condition,
         Func<bool> stop, 
         ITimeMeasurementProvider provider,
        IDifferentialEquationProcessor processor, 
        IExceptionHandler errorHandler = null)
        {
            IMeasurement cond = null;
            if (condition != null)
            {
                cond = FindMeasurement(condition);
            }
            var d = FindMeasurements(output);
             XmlParameterWriter xpv = new XmlParameterWriter(null);
            IParameterWriter pvv = xpv;
            Action act = () =>
            {
                Dictionary<string, string> dpp = new Dictionary<string, string>();
                foreach (string k in d.Keys)
                {
                    object v = d[k].Parameter();
                    dpp[output[k]] = v + "";
                }
                pvv.Write(dpp);
            };

            try
            {
                PerformFixed(start, step, count, provider, processor,
                    StaticExtensionDataPerformerInterfaces.Calculation,
                    0, act, cond, stop, null, errorHandler);
            }
            catch (Exception e)
            {
                e.HandleException(10);
            }
            return xpv.Document;
        }

        #endregion

        #region Public members

        /// <summary>
        /// Finds measurements
        /// </summary>
        /// <param name="measurements">Input dictionary</param>
        /// <returns>Output dictionary</returns>
        public Dictionary<string, IMeasurement> FindMeasurements(Dictionary<string, string> measurements)
        {
            var d = new Dictionary<string, IMeasurement>();
            foreach (var a in measurements)
            {
                d[a.Key] = FindMeasurement(a.Value);
            }
            return d;
        }


        /// <summary>
        /// Finds a measurement
        /// </summary>
        /// <param name="measurement">Measurement name</param>
        /// <param name="allowNull">The allow null sign</param>
        /// <returns>The measurement</returns>
        public IMeasurement FindMeasurement(string measurement, bool allowNull = false)
        {
            if (measurement == null)
            {
                if (!allowNull)
                {
                    throw new OwnException("Undefined measure");
                }
                return null;
            }
            int n = measurement.LastIndexOf(".");
            if (n < 0)
            {
                if (!allowNull)
                {
                    throw new OwnException("Undefined measure");
                }
                return null;
            }
            string p = measurement.Substring(0, n);
            string s = measurement.Substring(n + 1);
            IAssociatedObject ass = Consumer as IAssociatedObject;
            INamedComponent comp = ass.Object as INamedComponent;
            IDesktop d = comp.Desktop;
            for (int i = 0; i < Consumer.Count; i++)
            {
                IMeasurements mea = Consumer[i];
                IAssociatedObject ao = mea as IAssociatedObject;
                INamedComponent nc = ao.Object as INamedComponent;
                string name = PureObjectLabel.GetName(nc, d);
                if (!name.Equals(p))
                {
                    continue;
                }
                for (int j = 0; j < mea.Count; j++)
                {
                    IMeasurement m = mea[j];
                    if (s.Equals(m.Name))
                    {
                        return m;
                    }
                }
            }
            if (Consumer is IMeasurements)
            {
                if (Consumer.ShouldInsertIntoChildren())
                {
                    var cm = Consumer as IMeasurements;
                    foreach (var cmm in cm.GetMeasurementObjects())
                    {
                        var nm = Consumer.GetName(cmm);
                        if (measurement.Equals(nm))
                        {
                            return cmm;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Measurements by name
        /// </summary>
        public Dictionary<string, IMeasurement> Measurements
        {
            get
            {
                var d = new Dictionary<string, IMeasurement>();
                for (int i = 0; i < Consumer.Count; i++)
                {
                    var mm = Consumer[i];
                    var mn = Consumer.GetMeasurementsName(mm) + ".";
                    for (int j = 0; j < mm.Count; j++)
                    {
                        var m = mm[j];
                        var s = mn +  m.Name;
                        d[s] = m;
                    }
                }
                return d;
            }
        }



        /// <summary>
        /// Gets all iterators of consumer
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="iterators">List of iterators</param>
        public void GetIterators(List<IIterator> iterators)
        {
            getIterators(Consumer, iterators);
        }

        #endregion

        #region Private Members
        static void getIterators(IDataConsumer consumer, List<IIterator> list)
        {
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                if (m is IIterator)
                {
                    IIterator it = m as IIterator;
                    if (!list.Contains(it))
                    {
                        list.Add(it);
                    }
                }
                if (m is IDataConsumer)
                {
                    IDataConsumer c = m as IDataConsumer;
                    getIterators(c, list);
                }
            }
        }

        #endregion

    }
}
