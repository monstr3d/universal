using System;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;
using System.Threading;


using CategoryTheory;

using Diagram.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataPerformer.Interfaces;
using DataPerformer.Interfaces.Attributes;

using ErrorHandler;
using NamedTree;


namespace DataPerformer.Portable.Wrappers
{
    /// <summary>
    /// Wrapper of data consumer
    /// </summary>
    public class DataConsumerWrapper
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
        /// <param name="action">The action</param>
        /// <param name="stop">The stop</param>
        /// <param name="preparation">The preparation action</param>
        /// <param name="errorHandler">The error handler</param>
        public void PerformIterator(IIterator iterator,
           Action action, Func<bool> stop = null, Action preparation = null,
           IExceptionHandler errorHandler = null)
        {
            Func<bool> st = (stop == null) ? () => false : stop;
            var b = true;
            try
            {
                iterator.Reset();
                Consumer.ResetAll();
                var rt = Consumer.CreateRuntime(null);
                Action act = () => { rt.UpdateAll(); };
                var attr = CustomAttributeExtensions.GetCustomAttribute<IteratorTypeAttribute>
                    (IntrospectionExtensions.GetTypeInfo(iterator.GetType()));
                if (attr != null)
                {
                    if (attr.Log)
                    {
                        act = () => { };
                    }
                }
                var coll = Consumer.GetDependentCollection();
                coll.ForEach((IRunning s) => s.IsRunning = true);
                preparation?.Invoke();
                while (true)
                {
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
        }


        /*  IEnumerable<object> PerformIterator(IEnumerable<double> times,
              ITimeMeasurementProvider provider,
                IDifferentialEquationProcessor processor, string reason,
               int priority, Func<object> func, IMeasurement condition = null, Func<bool> stop = null, IAsynchronousCalculation asynchronousCalculation = null,
               IErrorHandler errorHandler = null)
          {
              ITimeMeasurementProvider old = processor.TimeProvider;
              var stp = stop;
              if (stp == null)
              {
                  stp = () => false;
              }
              Func<bool> f = () => true;
              if (condition != null) 
              {
                  f = () => (bool)condition.Parameter();
              }
              try
              {
                  using (var backup = new TimeProviderBackup(Consumer, provider, processor, reason, priority))
                  {
                     bool first = true;
                      Action<double, double, long> act;
                      foreach (var time in times)
                      {
                          if (first)
                          {
                              first = false;
                              provider.Time = time;
                              IDataRuntime runtime = backup.Runtime;
                              runtime.StartAll(time);
                              processor.TimeProvider = provider;
                              IStep st = null;
                              if (runtime is IStep)
                              {
                                  st = runtime as IStep;
                              }
                              provider.Time = time;
                              double t = time;
                              double last = t;
                              act = runtime.Step(processor,
                              (time) =>
                              {
                                  provider.Time = time;
                              }
                              , reason, asynchronousCalculation);
                              continue;
                          }
                          if (stp())
                          {
                              break;
                          }
                          t = testc;
                          act(last, t, i);
                          last = t;
                          acts();
                      }
                  }
              }
              catch (Exception ex)
              {
                  if (errorHandler != null)
                  {
                      errorHandler.HandleException(ex, 10);
                  }
                  else
                  {
                      ex.HandleException(10);
                  }
              }
              processor.TimeProvider = old;
          }
      }*/


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
                using (var backup = new TimeProviderBackup(Consumer, provider, processor, reason, priority))
                {
                    var p = backup.Processor;
                    provider.Time = start;
                    IDataRuntime runtime = backup.Runtime;
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
        /// <param name="condition">Condition</param>
        /// <param name="stop">Stop function</param>
        /// <param name="errorHandler">Error handler</param>
        /// <param name="asynchronousCalculation">Asynchronous calculation</param>
        /// <param name="errorHandler">Asynchronous calculation</param>
        /*   public void PerformFixed(double start, double step, int count,
           ITimeMeasurementProvider provider,
             IDifferentialEquationProcessor processor, string reason,
            int priority, Action action, IMeasurement condition, Func<bool> stop = null, IAsynchronousCalculation asynchronousCalculation = null,
            IErrorHandler errorHandler = null)
           {
               ITimeMeasurementProvider old = processor.TimeProvider;
               Func<bool> stp = stop;
               if (stp == null)
               {
                   stp = () => false;
               }
               try
               {
                   using (var backup = new TimeProviderBackup(Consumer, provider, processor, reason, priority))
                   {
                       provider.Time = start;
                       IDataRuntime runtime = backup.Runtime;
                       runtime.StartAll(start);
                       processor.TimeProvider = provider;
                       IStep st = null;
                       if (runtime is IStep)
                       {
                           st = runtime as IStep;
                       }
                       provider.Time = start;
                       double t = start;
                       double last = t;
                       Action<double, double, long>
                           act = runtime.Step(processor,
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
                           if ((bool)condition.Parameter())
                           {
                               action();
                           }
                       }
                   }
               }
               catch (Exception ex)
               {
                   if (errorHandler != null)
                   {
                       errorHandler.HandleException(ex, 10);
                   }
                   else
                   {
                       ex.HandleException(10);
                   }
               }
               processor.TimeProvider = old;
           }*/


        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="reason">Reason</param>
        /// <param name="priority">Priority</param>
        /// <param name="action">Additional action</param>
        /*      public void PerformFixed(double start, double step, int count, string reason,
                 int priority, Action action, Func<bool> stop = null, IAsynchronousCalculation asynchronousCalculation = null, IErrorHandler errorHandler = null)
              {
                  PerformFixed(start, step, count,
                         StaticExtensionDataPerformerPortable.Factory.TimeProvider,
                         DifferentialEquationProcessors.DifferentialEquationProcessor.Processor,
                      reason, priority, action, stop, asynchronousCalculation, errorHandler);
              }*/


        #endregion

        #region CreateXmlDocument

        /// <summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count</param>
        /// <returns>Result</returns>
        /*      public XmlDocument CreateXmlDocument(
                  XmlDocument input, double start, double step,
                  int count)
              {
                  List<string> p = new List<string>();
                  IMeasurement cond = null;
                  string arg = null;
                  Dictionary<string, Func<Func<object>>> d = new Dictionary<string, Func<Func<object>>>();
                  XmlElement r = input.DocumentElement;
                  foreach (XmlElement e in r.ChildNodes)
                  {
                      string name = e.Name;
                      if (name.Equals("Condition"))
                      {
                          cond = FindMeasurement(e.InnerText, true);
                          continue;
                      }
                      if (name.Equals("Argument"))
                      {
                          arg = e.InnerText;
                          continue;
                      }
                      if (name.Equals("Parameters"))
                      {
                          XmlNodeList nl = e.ChildNodes;
                          foreach (XmlElement xp in nl)
                          {
                              string pn = null;
                              string pv = null;
                              foreach (XmlElement xpp in xp.ChildNodes)
                              {
                                  string npp = xpp.Name;
                                  if (npp.Equals("Name"))
                                  {
                                      pn = xpp.InnerText;
                                      continue;
                                  }
                                  pv = xpp.InnerText;
                              }
                              IMeasurement mcc = FindMeasurement(pn, false);
                              d[pv] = mcc.ToValueHolder();
                          }
                      }
                  }
                  XmlParameterWriter xpv = new XmlParameterWriter(null);
                  IParameterWriter pvv = xpv;
                  Action acts = () =>
                  {
                      Dictionary<string, string> dpp = new Dictionary<string, string>();
                      foreach (string k in d.Keys)
                      {
                          object v = d[k]()();
                          dpp[k] = v + "";
                      }
                      pvv.Write(dpp);
                  };

                  Action act = (cond == null) ? acts : () =>
                  {
                      foreach (string k in d.Keys)
                      {
                          object v = d[k]()();
                      }
                      if ((bool)cond.Parameter())
                      {
                          acts();
                      }
                  };
                  try
                  {
                      //PerformFixedT(start, step, count, StaticExtensionDataPerformerInterfaces.Calculation, 0, act);
                  }
                  catch (Exception e)
                  {
                      e.HandleException(10);
                  }
                  return xpv.Document;
              }*/

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
            var d = new Dictionary<string, IMeasurement>();
            foreach (var a in output.Keys)
            {
                d[a] = FindMeasurement(a);
            }
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

    }
}
