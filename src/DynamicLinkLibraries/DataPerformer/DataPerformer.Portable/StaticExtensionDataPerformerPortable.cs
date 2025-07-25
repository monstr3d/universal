﻿using System;
using System.Collections.Generic;
using System.Xml;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Aliases;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using AssemblyService.Attributes;

using BaseTypes;
using BaseTypes.Attributes;
using BaseTypes.Interfaces;

using DataPerformer.Attributes;
using DataPerformer.Interfaces;
using DataPerformer.Interfaces.Attributes;
using DataPerformer.Portable.Interfaces;
using DataPerformer.Portable.Measurements;
using DataPerformer.Portable.Wrappers;

using Event.Interfaces;
using System.Drawing;
using ErrorHandler;
using System.Threading;
using NamedTree;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataPerformerPortable
    {

        #region Fields

        static NamedTree.Performer performer = new NamedTree.Performer();

        // Type check
        private static readonly double a = 0;
        /// <summary>
        /// Comparer of measurements
        /// </summary>
        private static IComparer<IMeasurements> measurementsComparer = Comparation.MeasurementsComparer.Singleton;

        /// <summary>
        /// Asynchronous calculations
        /// </summary>
        private static Dictionary<string, IAsynchronousCalculationFactory> asynchronousCalculations =
            new Dictionary<string, IAsynchronousCalculationFactory>();

        static CommonWrapper wrapper = new();


        /// <summary>
        /// Desktop
        /// </summary>
        private static IDesktop desktop;

        /// <summary>
        /// Step
        /// </summary>
        static private int stepNumber;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionDataPerformerPortable()
        {
            new CSCodeCreator();
            TimeMeasureProviderFactory = new DefautFactory();
            Runtime.DataRuntimeFactory.Singleton.SetBase();
            Runtime.DataRuntimeFactory.Singleton.SetBaseAction();
            (Runtime.DataRuntimeFactory.Singleton as IActionFactoryCreator).SetBaseAction();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets double value of measure
        /// </summary>
        /// <param name="measurement">The measure</param>
        /// <returns>The double value</returns>
        public static double ToDouble(this IMeasurement measurement)
        {
            return wrapper.ToDouble(measurement);
        }

        /// <summary>
        /// Transformation to string
        /// </summary>
        /// <param name="measurement">measurement</param>
        /// <param name="obj">Associated object</param>
        /// <returns>The string</returns>
        public static string ToString(this IMeasurement measurement, object obj)
        {
            var s = measurement.ToString();
            if (obj == null)
            {
                return s;
            }
            var name = measurement.Name;
            if (obj is IObjectLabel label)
            {
                return label.ToString() + "." + name + s;
            }
            if (obj is IAssociatedObject associatedObject)
            {
                if (associatedObject.Object is IObjectLabel alabel)
                {
                    return alabel.ToString() + "." + name + s;
                }
            }
            return s;
        }

        /// <summary>
        /// Static to string
        /// </summary>
        /// <param name="measurement">The measurement</param>
        /// <returns>The string</returns>
        /// <exception cref="IllegalSetPropetryException"></exception>
        public static string ToStringStatic(this IMeasurement measurement)
        {
            if (measurement is IAssociatedObject alabel)
            {
                return measurement.ToString(alabel.Object);
            }
            throw new IllegalSetPropetryException("ToStringStatic");
        }

        /// <summary>
        /// Checks whether type is double
        /// </summary>
        /// <param name="obj">The type</param>
        /// <returns>The result of checking</returns>
        public static bool IsDoubleType(this object obj)
        {
            return wrapper.IsDoubleType(obj);
         }


        /// <summary>
        /// Converts object to differential equation solver
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The solver</returns>
        public static IDifferentialEquationSolver ToDifferentialEquationSolver(this object obj)
        {
            return wrapper.ToDifferentialEquationSolver(obj);
        }


        /// <summary>
        /// Initialize itself
        /// </summary>
        /// <param name="attr">Initialization attribute</param>
        static public void Init(InitAssemblyAttribute attr)
        {

        }


        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="consumer">Data Consumer</param>
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
        public static void PerformFixed(this IDataConsumer consumer, double start, double step, int count,
                ITimeMeasurementProvider provider,
                  IDifferentialEquationProcessor processor, string reason,
                 int priority, CancellationToken token,
                 Action action, string condition, IAsynchronousCalculation asynchronousCalculation = null,
                 IExceptionHandler errorHandler = null)
        {
            var wrapper = new Wrappers.DataConsumerWrapper(consumer);
            wrapper.PerformFixed(start, step, count,
                provider, processor, reason, priority, token, action, condition, asynchronousCalculation,
                errorHandler);
        }




        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="consumer">Data Consumer</param>
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
        public static void PerformFixed(this IDataConsumer consumer, double start, double step, int count,
                ITimeMeasurementProvider provider,
                  IDifferentialEquationProcessor processor, string reason,
                 int priority, Action action, string condition, Func<bool> stop, IAsynchronousCalculation asynchronousCalculation = null,
                 IExceptionHandler errorHandler = null)
        {
            var wrapper = new Wrappers.DataConsumerWrapper(consumer);
            wrapper.PerformFixed(start, step, count,
                provider, processor, reason, priority, action, condition, stop, asynchronousCalculation,
                errorHandler);
        }

        /// <summary>
        /// Get dicionary of measurements
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <returns>The Dictionaty</returns>
        public static Dictionary<string, IMeasurement> GetMeasurementsInverseDictionary(this IDataConsumer consumer)
        {
            var wrapper = new Wrappers.DataConsumerWrapper(consumer);
            return wrapper.Measurements;
        }

        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="reason">Reason</param>
        /// <param name="priority">Priority</param>
        /// <param name="action">Additional action</param>
        /*     public static void PerformFixed(this IDataConsumer consumer, double start, double step, int count, string reason,
            int priority, Action action, Func<bool> stop = null,  IAsynchronousCalculation asynchronousCalculation = null, IErrorHandler errorHandler = null)
         {
             consumer.PerformFixed(start, step, count,
                    StaticExtensionDataPerformerPortable.Factory.TimeProvider,
                    DifferentialEquationProcessors.DifferentialEquationProcessor.Processor,
                 reason, priority, action, stop, asynchronousCalculation, errorHandler);
         }*/


        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="provider">Provider of time measure</param>
        /// <param name="processor">Differential equation processor</param>
        /// <param name="reason">Reason</param>
        /// <param name="priority">Priority</param>
        /// <param name="action">Additional action</param>
        /// <param name="stop">Stop function</param>
        /// <param name="errorHandler">Error handler</param>
        /// <param name="asynchronousCalculation">Asynchronous calculation</param>
        /*       static public void PerformFixed(this IDataConsumer consumer, double start, double step, int count,
                   ITimeMeasurementProvider provider,
                     IDifferentialEquationProcessor processor, string reason,
                    int priority, Action action, Func<bool> stop, IAsynchronousCalculation asynchronousCalculation = null,
                    IErrorHandler errorHandler = null)
               {

                   var wrapper = new Wrappers.DataConsumerWrapper(consumer);
                   wrapper.PerformFixed(start, step, count, provider, processor, reason, priority,
                       action, stop, asynchronousCalculation, errorHandler);

               }*/



        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="collection">Desktop</param>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="provider">Provider of time measure</param>
        /// <param name="processor">Differential equation processor</param>
        /// <param name="priority">Priority</param>
        /// <param name="action">Additional action</param>
        /// <param name="reason">Reason</param>
        static public void PerformFixed(this IComponentCollection collection, double start, double step, int count, ITimeMeasurementProvider provider,
            IDifferentialEquationProcessor processor, int priority, Action action, string reason)
        {
            var wrapper = new ComponentCollectionWrapper(collection);
            wrapper.PerformFixed(start, step, count, provider, processor, priority, action,
                 reason);
        }

        /// <summary>
        /// Performs iterator
        /// </summary>
        /// <param name="consumer">The Data Consumer</param>
        /// <param name="iterator">The iterator</param>
        /// <param name="action">The action</param>
        /// <param name="stop">The stop</param>
        /// <param name="preparation">The preparation action</param>
        /// <param name="errorHandler">The error handler</param>
        public static void PerformIterator(this IDataConsumer consumer, IIterator iterator,
           Action action, Func<bool> stop = null, Action preparation = null,
           IExceptionHandler errorHandler = null)
        {
            var wrapper = new Wrappers.DataConsumerWrapper(consumer);
            wrapper.PerformIterator(iterator, action, stop, preparation, errorHandler);
        }




        /// <summary>
        /// Gets all iterators of consumer
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="iterators">List of iterators</param>
        public static void GetIterators(this IDataConsumer consumer, List<IIterator> iterators)
        {
            getIterators(consumer, iterators);
        }


        /// <summary>
        /// Sets the factory of the time measurements
        /// </summary>
        /// <param name="factory">Factory of the time measurement </param>
        static public void SetTimeFactory(this ITimeMeasurementProviderFactory factory)
        {
            TimeMeasureProviderFactory = factory;
        }

        /// <summary>
        /// Factory of the time measurement 
        /// </summary>
        static public ITimeMeasurementProviderFactory TimeMeasureProviderFactory
        { get; set; }

        /// <summary>
        /// Creates disassembly object dictionary
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="disassembly">Disassembly</param>
        /// <returns>The dictionary</returns>
        static public Dictionary<IMeasurement, IDisassemblyObject>
            CreateDisassemblyObjectDictionary(this IEnumerable<IMeasurement> measurements,
            IDisassemblyObject disassembly)
        {
            Dictionary<IMeasurement, IDisassemblyObject> d =
                new Dictionary<IMeasurement, IDisassemblyObject>();
            foreach (IMeasurement m in measurements)
            {
                IDisassemblyObject o = disassembly[m.Type];
                if (o != null)
                {
                    d[m] = o;
                }
            }
            return d;
        }

        /// <summary>
        /// Gets measurement objects 
        /// </summary>
        /// <param name="dataConsumer">Consumer of data</param>
        /// <param name="factory">Factory of objects</param>
        /// <returns>Dictionary of objects</returns>
        static public Dictionary<IMeasurement, object> GetMeasurementObjects(this IDataConsumer dataConsumer,
            IMeasurementObjectFactory factory)
        {
            Dictionary<IMeasurement, object> d = new Dictionary<IMeasurement, object>();
            for (int i = 0; i < dataConsumer.Count; i++)
            {
                IMeasurements m = dataConsumer[i];
                string n = dataConsumer.GetMeasurementsName(m) + ".";
                for (int j = 0; j < m.Count; j++)
                {
                    IMeasurement mm = m[j];
                    object o = factory[n + mm.Name, mm];
                    if (o != null)
                    {
                        d[mm] = o;
                    }
                }
            }
            return d;
        }

        /// <summary>
        /// Gets measurement objects 
        /// </summary>
        /// <param name="dataConsumer">Consumer of data</param>
        /// <param name="dictionary">Dictionary of objects</param>
        /// <param name="factory">Factory of objects</param>
        /// <param name="condition">Condition for leave old</param>
        static public void GetMeasurementObjects(this IDataConsumer dataConsumer,
         Dictionary<IMeasurement, object> dictionary, IMeasurementObjectFactory factory, Func<object, bool> condition)
        {
            for (int i = 0; i < dataConsumer.Count; i++)
            {
                IMeasurements m = dataConsumer[i];
                string n = dataConsumer.GetMeasurementsName(m) + ".";
                for (int j = 0; j < m.Count; j++)
                {
                    IMeasurement mm = m[j];
                    if (dictionary.ContainsKey(mm))
                    {
                        if (!condition(dictionary[mm]))
                        {
                            continue;
                        }
                    }
                    object o = factory[n + mm.Name, mm];
                    if (o != null)
                    {
                        dictionary[mm] = o;
                    }
                }
            }
        }

        /// <summary>
        /// Removes measurement objects 
        /// </summary>
        /// <param name="dictionary">Dictionary of objects</param>
        /// <param name="condition">Condition for remove</param>
        static public void RemoveMeasurementObjects(this Dictionary<IMeasurement, object> dictionary,
            Func<object, bool> condition)
        {
            List<IMeasurement> l = new List<IMeasurement>(dictionary.Keys);
            foreach (IMeasurement m in l)
            {
                if (condition(dictionary[m]))
                {
                    dictionary.Remove(m);
                }
            }
        }

        /// <summary>
        /// Gets measurements ditcionary
        /// </summary>
        /// <param name="dataConsumer"></param>
        /// <param name="type"></param>
        /// <returns>The dictionary</returns>
        static public Dictionary<IMeasurement, string> GetMeasurementsDictionary(this IDataConsumer dataConsumer,
            object type = null)
        {
            if (type == null)
            {
                return dataConsumer.GetMeasurementsDictionaryPrivate();
            }
            Dictionary<IMeasurement, string> d = new Dictionary<IMeasurement, string>();
            for (int i = 0; i < dataConsumer.Count; i++)
            {
                IMeasurements m = dataConsumer[i];
                string n = dataConsumer.GetMeasurementsName(m) + ".";
                for (int j = 0; j < m.Count; j++)
                {
                    IMeasurement mm = m[j];
                    if (type.Equals(mm.Type))
                    {
                        d[mm] = n + mm.Name;
                    }
                }
            }
            return d;
        }

        /// <summary>
        ///  Creates disassembly object dictionary
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="disassembly">Disassembly</param>
        /// <returns>The dictionary</returns>
        static public Dictionary<IMeasurement, IDisassemblyObject>
            CreateDisassemblyObjectDictionary(this IDataConsumer dataConsumer,
            IDisassemblyObject disassembly)
        {
            List<IMeasurement> l = new List<IMeasurement>();
            for (int i = 0; i < dataConsumer.Count; i++)
            {
                IMeasurements m = dataConsumer[i];
                for (int j = 0; j < m.Count; j++)
                {
                    l.Add(m[j]);
                }
            }
            return l.CreateDisassemblyObjectDictionary(disassembly);
        }


        /// <summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="collection">Components</param>
        /// <param name="input">Input</param>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count</param>
        /// <returns>Result</returns>
/*  !!!      static public XmlDocument CreateXmlDocument(this IDataConsumer consumer,
            XmlDocument input, double start, double step,
            int count)
        {
            var wrapper = new Wrappers.DataConsumerWrapper(consumer);
            return wrapper.CreateXmlDocument(input, start, step, count);

        }*/

        /// <summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="output">Output parameters</param>
        /// <param name="condition">Condition</param>
        /// <param name="start">Start time</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count</param>
        /// <param name="stop">Stop function</param>
        /// <param name="provider">Provider of time measurements</param>
        /// <param name="processor">Differential equation processor</param>
        /// <param name="errorHandler">Error handler</param>
        /// <returns>The Xml document</returns>
        static public XmlDocument CreateXmlDocument(this IDataConsumer consumer,
            Dictionary<string, string> output,
            string condition, double start, double step,
            int count, Func<bool> stop,
            ITimeMeasurementProvider provider,
        IDifferentialEquationProcessor processor,
        IExceptionHandler errorHandler = null)
        {
            var wrapper = new Wrappers.DataConsumerWrapper(consumer);
            return wrapper.CreateXmlDocument(output,
               start, step,
             count, condition, stop, provider,
             processor, errorHandler);
        }


        /// <summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="consumer">Consumer name</param>
        /// <param name="input">Input</param>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <returns>Document</returns>
       /*!!! static public XmlDocument CreateXmlDocument(this IDesktop desktop, string consumer,
            XmlDocument input, double start, double step, int count)
        {
            var wrapper = new ComponentCollectionWrapper(desktop);
            return wrapper.CreateXmlDocument(consumer, input, start, step, count);
        }
       */

        /// <summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="input">Input</param>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <returns>Document</returns>
  /*!!!      static public XmlDocument CreateXmlDocument(this IDesktop desktop,
            XmlDocument input, double start, double step, int count)
        {
            var wrapper = new ComponentCollectionWrapper(desktop);
            string consumer = (input.GetElementsByTagName("ChartName")[0] as XmlElement).InnerText;
            return wrapper.CreateXmlDocument(consumer, input, start, step, count);
        }*/

        /// <summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="input">Input</param>
        /// <returns>Document</returns>
   /*!!!     static public XmlDocument CreateXmlDocument(this IDesktop desktop, XmlDocument input)
        {
            var wrapper = new ComponentCollectionWrapper(desktop);
            return wrapper.CreateXmlDocument(input);
        }
   */




        /// <summary>
        ///  Creates disassembly measurements dictionary
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="disassembly">Disassembly</param>
        /// <returns>The dictionary</returns>
        static public Dictionary<IMeasurement, MeasurementsDisassemblyWrapper> CreateDisassemblyMeasurements(
            this IDataConsumer dataConsumer, IDisassemblyObject disassembly)
        {
            Dictionary<IMeasurement, IDisassemblyObject> disassemblyDict =
                dataConsumer.CreateDisassemblyObjectDictionary(disassembly);
            Dictionary<IMeasurement, MeasurementsDisassemblyWrapper> disassemblyDictionary =
                new Dictionary<IMeasurement, MeasurementsDisassemblyWrapper>();
            foreach (IMeasurement key in disassemblyDict.Keys)
            {
                disassemblyDictionary[key] = new
                    MeasurementsDisassemblyWrapper(disassemblyDict[key], key);
            }
            return disassemblyDictionary;
        }

        /// <summary>
        /// Transforms selection to data array
        /// </summary>
        /// <param name="selection">The selection</param>
        /// <returns>The array</returns>
        public static double[] ToDoubleArray(this IStructuredSelection selection)
        {
            int n = selection.DataDimension;
            double[] data = new double[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = (double)selection[i];
            }
            return data;
        }

        /// <summary>
        /// Sets relative alias links
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        /// <param name="collection">Collection of objects</param>
        public static void SetMeasureAliasLinks(this IMeasurements measurements,
            Dictionary<int, string> input, Dictionary<IMeasurement, IAliasName> output,
                      IComponentCollection collection = null)
        {
            IComponentCollection c = collection;
            if (c == null)
            {
                c = (measurements as IAssociatedObject).GetRootDesktop();
            }
            output.Clear();
            Dictionary<object, List<IAliasName>> d = measurements.GetAliasesByTypes(c);
            foreach (List<IAliasName> lan in d.Values)
            {
                foreach (IAliasName an in lan)
                {
                    string name = measurements.GetRelativeMeasureAliasName(an);
                    if (input.ContainsValue(name))
                    {
                        foreach (int num in input.Keys)
                        {
                            if (input[num].Equals(name))
                            {
                                output[measurements[num]] = an;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates text list
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <returns>Text list</returns>
        public static List<string> CreateCSharpAliasList(this IAlias alias)
        {
            List<string> l = new List<string>();
            IList<string> al = alias.AliasNames;
            int n = al.Count;
            l.Add("new Dictionary<string, object>()");
            l.Add("{");
            if (n == 0)
            {
                l.Add("};");
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    string s = al[i];
                    s = "\t{\"" + s + "\", " + alias[al[i]].AnyToString() + " }";
                    if (i < (n - 1))
                    {
                        s += ',';
                    }
                    l.Add(s);
                }
                l.Add("};");
            }
            return l;
        }

        /// <summary>
        /// Gets output types of measurements
        /// </summary>
        /// <param name="measurements"></param>
        /// <returns></returns>
        public static List<object> GetOutputTypes(this IMeasurements measurements)
        {
            List<object> l = new List<object>();
            for (int i = 0; i < measurements.Count; i++)
            {
                object t = measurements[i].Type;
                if (!l.Contains(t))
                {
                    l.Add(t);
                }
            }
            return l;
        }

        /// <summary>
        /// Gets sources of measurements
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="collection">Collection of components</param>
        /// <returns>All sources</returns>
        public static List<IDataConsumer> GetSources(this IMeasurements measurements,
            IComponentCollection collection)
        {
            IComponentCollection c = collection;
            if (c == null)
            {
                c = (measurements as IAssociatedObject).GetRootDesktop();
            }
            var  en = c.GetObjectsAndArrows<IDataConsumer>().ToArray();
            List<IDataConsumer> l = new List<IDataConsumer>();
            foreach (IDataConsumer consumer in en)
            {
                if (measurements.IsSource(consumer))
                {
                    l.Add(consumer);
                }
            }
            return l;
        }

        /// <summary>
        /// Checks whether measurements object is source of data consumer
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="consumer">Data consumer</param>
        /// <returns>Check result</returns>
        public static bool IsSource(this IMeasurements measurements, IDataConsumer consumer)
        {
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                if (m == measurements)
                {
                    return true;
                }
                if (m is IDataConsumer)
                {
                    if (measurements.IsSource(m as IDataConsumer))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// Gets types of aliases
        /// </summary>
        /// <param name="measurements">measurements</param>
        /// <param name="collection">Object collection</param>
        /// <returns>Aliases</returns>
        static public Dictionary<object, List<IAliasName>> GetAliasesByTypes(
            this IMeasurements measurements,
            IComponentCollection collection = null)
        {
            IComponentCollection c = collection;
            if (c == null)
            {
                c = (measurements as IAssociatedObject).GetRootDesktop();
            }
            Dictionary<object, List<IAliasName>> dictionary = new Dictionary<object, List<IAliasName>>();
            List<object> t = measurements.GetOutputTypes();
            List<IDataConsumer> l = measurements.GetSources(collection);
            foreach (IDataConsumer consumer in l)
            {
                if (consumer is IAlias)
                {
                    IAlias alias = consumer as IAlias;
                    IList<string> names = alias.AliasNames;
                    foreach (string name in names)
                    {
                        object type = alias.GetType(name);
                        if (!t.Contains(type))
                        {
                            continue;
                        }
                        List<IAliasName> la = null;
                        if (dictionary.ContainsKey(type))
                        {
                            la = dictionary[type];
                        }
                        else
                        {
                            la = new List<IAliasName>();
                            dictionary[type] = la;
                        }
                        la.Add(new AliasName(alias, name));
                    }
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Relative name of alias
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="aliasName">Alias name</param>
        /// <returns>Relative name</returns>
        public static string GetRelativeMeasureAliasName(this IMeasurements measurements,
            IAliasName aliasName)
        {
            IAliasBase alias = aliasName.Alias;
            string an =
                (measurements as IAssociatedObject).GetRelativeName(alias as IAssociatedObject);
            return an + "." + aliasName.Name;
        }

        /// <summary>
        /// Creates value holder from measure
        /// </summary>
        /// <param name="measurement">The measurement</param>
        /// <returns>The holder</returns>
        public static Func<Func<object>> ToValueHolder(this IMeasurement measurement)
        {
            var wrapper =
                new MeasurementWrapper(measurement);
            return () => wrapper.GetValue;
        }

        /// <summary>
        /// Gets dependent measurements
        /// </summary>
        /// <param name="measurements">Source</param>
        /// <param name="list">Dependent objects</param>
        /// <param name="dependent">Dependent measurements</param>
        public static void GetDependent(this IEnumerable<IMeasurements> measurements,
            List<object> list, List<IMeasurements> dependent)
        {
            dependent.Clear();
            list.Clear();
            foreach (IMeasurements m in measurements)
            {
                if (m is IRuntimeUpdate)
                {
                    if (!(m as IRuntimeUpdate).ShouldRuntimeUpdate)
                    {
                        continue;
                    }
                }
                dependent.Insert(0, m);
                if (m is IDataConsumer)
                {
                    (m as IDataConsumer).GetDependentObjects(list);
                    foreach (object o in list)
                    {
                        if (o is IMeasurements)
                        {
                            IMeasurements mm = o as IMeasurements;
                            if (!dependent.Contains(mm))
                            {
                                dependent.Insert(0, mm);
                            }
                        }
                    }
                }
            }
            dependent.SortMeasurements();
        }

        /// <summary>
        /// Gets dependent objects
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="list">Objects</param>
        /// <param name="dependent">Dependent objects</param>
        public static void GetDependent(this IDataConsumer consumer,
            List<object> list, List<IMeasurements> dependent)
        {
            consumer.GetMeasurements().GetDependent(list, dependent);
        }

        /// <summary>
        /// Gets measurements of data consumer
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <returns>Measurements</returns>
        public static List<IMeasurements> GetMeasurements(this IDataConsumer consumer)
        {
            int n = consumer.Count;
            List<IMeasurements> l = new List<IMeasurements>();
            for (int i = 0; i < n; i++)
            {
                l.Add(consumer[i]);
            }
            return l;
        }

        /// <summary>
        /// Updates children data of consumer
        /// </summary>
        /// <param name="consumer">The consumer</param>
        public static void UpdateChildrenData(this IDataConsumer consumer)
        {
            int n = consumer.Count;
            for (int i = 0; i < n; i++)
            {
                consumer[i].UpdateMeasurements();
            }
        }

        /// <summary>
        /// Resets data consumer
        /// </summary>
        /// <param name="consumer">The consumer</param>
        public static void ResetAll(this IDataConsumer consumer)
        {
            if (consumer is IMeasurements)
            {
                IMeasurements mea = consumer as IMeasurements;
                mea.IsUpdated = false;
            }
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i] as IMeasurements;
                m.IsUpdated = false;
                if (m is IDataConsumer)
                {
                    IDataConsumer c = m as IDataConsumer;
                    c.Reset();
                }
            }
        }

        /// <summary>
        /// Updates measurements
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="recursive">Recursive sign</param>
        public static void UpdateMeasurements(this ICollection<IMeasurements> measurements, bool recursive)
        {
            foreach (IMeasurements m in measurements)
            {
                m.UpdateMeasurements(recursive);
            }
        }

        /// <summary>
        /// Updates measurements
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="recursive">Recursive sign</param>
        public static void UpdateMeasurements(this IMeasurements measurements, bool recursive)
        {
            measurements.IsUpdated = false;
            if (recursive)
            {
                if (measurements is IDataConsumer)
                {
                    IDataConsumer cons = measurements as IDataConsumer;
                    int n = cons.Count;
                    for (int i = 0; i < n; i++)
                    {
                        UpdateMeasurements(cons[i], recursive);
                    }
                }
            }
            measurements.UpdateMeasurements();
        }

        /// <summary>
        /// Resets data consumer and all depenent objects
        /// </summary>
        /// <param name="consumer">The consumer</param>
        public static void FullReset(this IDataConsumer consumer)
        {
            if (consumer is IMeasurements)
            {
                IMeasurements mea = consumer as IMeasurements;
                mea.IsUpdated = false;
            }
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i] as IMeasurements;
                m.IsUpdated = false;
                if (m is IDataConsumer)
                {
                    IDataConsumer c = m as IDataConsumer;
                    c.Reset();
                }
            }
        }

        /// <summary>
        /// Gets root desktop of consumer
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <returns>The desktop</returns>
        public static IDesktop GetRootConsumerDesktop(this IDataConsumer consumer)
        {
            ICategoryObject ob = consumer as ICategoryObject;
            return ob.GetRootDesktop();
        }

        /// <summary>
        /// Prepares consumer
        /// </summary>
        /// <param name="consumer">Consumer for preparation</param>
        static public void Prepare(this IDataConsumer consumer)
        {
            consumer.FullReset();
            consumer.UpdateChildrenData();
        }

        /// <summary>
        /// Desktop
        /// </summary>
        public static IDesktop Desktop
        {
            get
            {
                return desktop;
            }
            set
            {
                desktop = value;
            }
        }

        /// <summary>
        /// Clean measures
        /// </summary>
        /// <param name="measures">Measures to clean</param>
        public static void Clean(this IMeasurement[] measures)
        {
            for (int i = 0; i < measures.Length; i++)
            {
                measures[i] = null;
            }
        }

        /// <summary>
        /// Fills measures by zero c=constants
        /// </summary>
        /// <param name="measures">Measuresd</param>
        public static void FillByDoubleZero(this IMeasurement[] measures)
        {
            Double a = 0;
            double b = 0;
            for (int i = 0; i < measures.Length; i++)
            {
                IMeasurement m = measures[i];
                if (m == null)
                {
                    measures[i] = new ConstantMeasurement(b, a, "");
                }
            }
        }

        /// <summary>
        /// Creates collection from data consumer
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="reason">Reason</param>
        /// <param name="priority">priority</param>
        /// <returns>Collection</returns>
        public static IComponentCollection CreateCollection(this IDataConsumer dataConsumer, string reason = null, int priority = 0)
        {
            return Factory.CreateCollection(dataConsumer, priority, reason);
        }

        /// <summary>
        /// Fills measure by double constant
        /// </summary>
        /// <param name="measures">All measures</param>
        /// <param name="i">Measure number</param>
        /// <param name="x">Double constant</param>
        public static void FillMeasureByDouble(this IMeasurement[] measures, int i, double x)
        {
            Double a = 0;
            if (measures[i] == null)
            {
                measures[i] = new ConstantMeasurement(x, a, "");
            }
        }

        /// <summary>
        /// Checks whether object satisfies Calculation reason
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="reasons">Reasons</param>
        /// <returns>Evident</returns>
        static public bool SatisfiesReason(this object obj, string reason)
        {
            if (reason == null)
            {
                return false;
            }
            CalculationReasonsAttribute attr = performer.GetAttribute<CalculationReasonsAttribute>(obj);
            if (attr == null)
            {
                return false;
            }
            string[] ss = attr.Reasons;
            foreach (string s in ss)
            {
                if (s.Equals(reason))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Updates measurements
        /// </summary>
        /// <param name="measurements">Measurements to update</param>
        public static void UpdateChildrenData(this ICollection<IMeasurements> measurements)
        {
            foreach (IMeasurements m in measurements)
            {
                m.UpdateMeasurements();
            }
        }

        /// <summary>
        /// Sets aliases by vector components
        /// </summary>
        /// <param name="aliases">Array of aliases</param>
        /// <param name="aliasOffset">Offset of aliases</param>
        /// <param name="vector">Double vector</param>
        /// <param name="vectorOffset">Vector offset</param>
        /// <param name="lengh">Length</param>
        public static void SetAliases(this AliasName[] aliases, int aliasOffset, double[] vector,
            int vectorOffset, int lengh)
        {
            for (int i = 0; i < lengh; i++)
            {
                aliases[i + aliasOffset].SetValue(vector[i + vectorOffset]);
            }
        }


        /// <summary>
        /// Gets aliases names linked to data consumer
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="desktop">Relative desktop</param>
        /// <param name="l">List of name of aliases</param>
        /// <param name="type">Type of alias</param>
        public static void GetAliases(this IDataConsumer consumer, IDesktop desktop, IList<string> l, object type)
        {
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                if (m is IAlias)
                {
                    IAlias a = m as IAlias;
                    if (a is IAssociatedObject)
                    {
                        IAssociatedObject ao = a as IAssociatedObject;
                        object o = ao.Object;
                        if (o != null)
                        {
                            if (o is INamedComponent)
                            {
                                INamedComponent nc = o as INamedComponent;
                                string n = nc.GetName(desktop);
                                IList<string> an = a.AliasNames;
                                foreach (string aname in an)
                                {
                                    string s = n + "." + aname;
                                    object t = a.GetType(aname);
                                    if (type != null)
                                    {
                                        if (!type.Equals(t))
                                        {
                                            continue;
                                        }
                                    }
                                    if (!l.Contains(s))
                                    {
                                        l.Add(s);
                                    }
                                }
                            }
                        }
                    }
                }
                if (m is IDataConsumer)
                {
                    IDataConsumer cons = m as IDataConsumer;
                    GetAliases(cons, desktop, l, type);
                }
            }
        }

        /// <summary>
        /// Gets aliases names linked to data consumer
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="type">Type of alias</param>
        /// <returns>List of aliases</returns>
        public static List<string> GetAllAliases(this IDataConsumer consumer, object type = null)
        {
            var l = new List<string>();
            var d = (consumer as IAssociatedObject).GetRootDesktop();
            consumer.GetAllAliases(d, l, type);
            return l;
            
        }

        /// <summary>
        /// Gets aliases names linked to data consumer
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="desktop">Relative desktop</param>
        /// <param name="l">List of name of aliases</param>
        /// <param name="type">Type of alias</param>
        public static void GetAllAliases(this IDataConsumer consumer, IDesktop desktop, IList<string> l, object type = null)
        {
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                if (m is IAliasBase)
                {
                    IAliasBase a = m as IAliasBase;
                    if (a is IAssociatedObject)
                    {
                        IAssociatedObject ao = a as IAssociatedObject;
                        object o = ao.Object;
                        if (o != null)
                        {
                            if (o is INamedComponent)
                            {
                                INamedComponent nc = o as INamedComponent;
                                string n = nc.GetName(desktop);
                                if (a is IAlias)
                                {
                                    IAlias al = a as IAlias;
                                    IList<string> an = al.AliasNames;
                                    foreach (string aname in an)
                                    {
                                        string s = n + "." + aname;
                                        object t = al.GetType(aname);
                                        if (type != null)
                                        {
                                            if (!type.Equals(t))
                                            {
                                                continue;
                                            }
                                        }
                                        if (!l.Contains(s))
                                        {
                                            l.Add(s);
                                        }
                                    }
                                }
                                if (a is IAliasVector)
                                {
                                    IAliasVector av = a as IAliasVector;
                                    IList<string> an = av.AliasNames;
                                    foreach (string aname in an)
                                    {
                                        string s = n + "." + aname;
                                        object t = av.GetType(aname);
                                        if (type != null)
                                        {
                                            if (!type.Equals(t))
                                            {
                                                continue;
                                            }
                                        }
                                        if (!l.Contains(s))
                                        {
                                            l.Add(s);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (m is IDataConsumer)
                {
                    IDataConsumer cons = m as IDataConsumer;
                    GetAllAliases(cons, desktop, l, type);
                }
            }
        }

        /// <summary>
        /// Asynchronous calculations
        /// </summary>
        public static Dictionary<string, IAsynchronousCalculationFactory> AsynchronousCalculations
        {
            get
            {
                return asynchronousCalculations;
            }
        }

        /// <summary>
        /// Gets list of names measurements of data consumer 
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="type">The type of measurements</param>
        /// <returns>The list of names measurements</returns>
        static public List<string> GetAllMeasurements(this IDataConsumer consumer, object type = null)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                IAssociatedObject ao = m as IAssociatedObject;
                IAssociatedObject th = consumer as IAssociatedObject;
                string on = th.GetRelativeName(ao) + ".";
                for (int j = 0; j < m.Count; j++)
                {
                    IMeasurement mea = m[j];
                    string s = on + mea.Name;
                    if (type == null)
                    {
                        list.Add(s);
                        continue;
                    }
                    if (mea.Type.Equals(type))
                    {
                        list.Add(s);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Gets all measurements names of consumer
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <param name="desktop">Relative desktop</param>
        /// <param name="type">Type of measurement</param>
        /// <returns>List of names of measurements</returns>
        static public List<string> GetAllMeasurements(this IDataConsumer consumer,
            IDesktop desktop, object type)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                IAssociatedObject ao = m as IAssociatedObject;
                INamedComponent nc = ao.Object as INamedComponent;
                string on = nc.GetName(desktop) + ".";
                for (int j = 0; j < m.Count; j++)
                {
                    IMeasurement mea = m[j];
                    string s = on + mea.Name;
                    if (type == null)
                    {
                        list.Add(s);
                        continue;
                    }
                    if (mea.Type.Equals(type))
                    {
                        list.Add(s);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Gets measurements type
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <returns>Dictionary of types</returns>
        public static Dictionary<string, object> GetAllMeasurementsType(this IDataConsumer consumer)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                string on = consumer.GetMeasurementsName(m);
                for (int j = 0; j < m.Count; j++)
                {
                    IMeasurement mea = m[j];
                    string s = on + "." + mea.Name;
                    dictionary[s] = mea.Type;
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Gets measurements names
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="type">Type</param>
        /// <returns>Dictionary of types</returns>
        public static Dictionary<IMeasurement, string> GetAllMeasurementsName(this IDataConsumer consumer, 
            object type = null)
        {
            Dictionary<IMeasurement, string> dictionary = new Dictionary<IMeasurement, string>();
            List<IMeasurements> list = new List<IMeasurements>();
            for (int i = 0; i < consumer.Count; i++)
            {
                var measurements = consumer[i];
                list.Add(measurements);
            }
            if (consumer is IMeasurements cmeasurements)
            {
                if (consumer.ShouldInsertIntoChildren())
                {
                    list.Add(cmeasurements);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                var measurements = list[i];
                var measurementsName = consumer.GetMeasurementsName(measurements);
                for (int j = 0; j < measurements.Count; j++)
                {
                    var measurement = measurements[j];
                    if (type != null)
                    {
                        if (!measurement.Type.Equals(type))
                        {
                            continue;
                        }
                    }
                    var name = measurementsName + "." + measurement.Name;
                    dictionary[measurement] = name;
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Gets measurements by name
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="type">Type</param>
        /// <returns>Dictionary of types</returns>
        public static Dictionary<string, IMeasurement> GetAllMeasurementsByName(this IDataConsumer consumer, 
            object type = null)
        {
            Dictionary<string, IMeasurement> dictionary = new Dictionary<string, IMeasurement>();
            Dictionary<IMeasurement, string> d = consumer.GetAllMeasurementsName(type);
            foreach (IMeasurement m in d.Keys)
            {
                dictionary[d[m]] = m;
            }
            return dictionary;
        }

        /// <summary>
        /// Gets measures type
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="types">Lists of types</param>
        /// <returns>Dictionary of types</returns>
        public static Dictionary<string, object> GetAllMeasurementsType(this IDataConsumer consumer,
            List<object> types)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                string on = consumer.GetMeasurementsName(m);
                for (int j = 0; j < m.Count; j++)
                {
                    IMeasurement mea = m[j];
                    string s = on + "." + mea.Name;
                    object type = mea.Type;
                    if (types.Contains(type))
                    {
                        dictionary[s] = type;
                    }
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Comparer of measurements
        /// </summary>
        public static IComparer<IMeasurements> MeasurementsComparer
        {
            get
            {
                return measurementsComparer;
            }
            set
            {
                measurementsComparer = value;
            }
        }

        /// <summary>
        /// Gets simple type measurements
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <returns>Dictionary of types</returns>
        public static Dictionary<string, object> GetSimpleTypeMeasurements(this IDataConsumer consumer)
        {
            return consumer.GetAllMeasurementsType(StaticExtensionBaseTypes.SimpleTypeList);
        }

        /// <summary>
        /// Gets all measures of defined type
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="type">Type</param>
        /// <returns>List of measures</returns>
        public static IList<string> GetAllMeasurementsType(this IDataConsumer consumer, object type)
        {
            Dictionary<string, object> d = GetAllMeasurementsType(consumer);
            List<string> l = new List<string>();
            foreach (string s in d.Keys)
            {
                if (type == null)
                {
                    l.Add(s);
                    continue;
                }
                if (type.Equals(d[s]))
                {
                    l.Add(s);
                }
            }
            return l;
        }

        /// <summary>
        /// Creates runtime
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="reason">Reason</param>
        /// <param name="priority">Priority</param>
        /// <returns>Runtime</returns>
        public static IDataRuntime CreateRuntime(
            this IDataConsumer dataConsumer, string reason, int priority = 0)
        {
            return Factory.Create(dataConsumer, priority, reason);
        }

  
        /// <summary>
        /// Updates all data
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        public static void UpdateAll(this IDataConsumer dataConsumer)
        {
            dataConsumer.CreateRuntime(null).UpdateAll();
        }

        /// <summary>
        /// Gets all aliases of consumer and all its children
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <param name="list">List of aliases</param>
        /// <param name="type">Type of alias</param>
        public static void GetAliases(this IDataConsumer consumer, List<string> list, object type)
        {
            getAliases(consumer, consumer, list, type);
        }

        /// <summary>
        /// Gets all type aliases of consumer and all its children
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <param name="list">List of aliases</param>
        /// <param name="type">Type of alias</param>
        public static void GetAllAliases(this IDataConsumer consumer, List<string> list, object type)
        {
            getAllAliases(consumer, consumer, list, type);
        }

        /// <summary>
        /// Gets all aliases of data consumer
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <param name="type">Type of alias</param>
        /// <returns>List of aliases</returns>
        public static List<string> GetAliases(this IDataConsumer consumer, object type)
        {
            List<string> list = new List<string>();
            GetAliases(consumer, list, type);
            return list;
        }

        /// <summary>
        /// Resets updated measurements
        /// </summary>
        /// <param name="collection">The collection</param>
        public static void ResetUpdatedMeasurements(this IComponentCollection collection)
        {
            collection.ForEach((IMeasurements m) => { m.IsUpdated = false; });
        }

        /// <summary>
        /// Gets data consumers of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>Consumers</returns>
        public static List<IDataConsumer> GetDataConsumers(this IComponentCollection desktop)
        {
            return GetDataConsumers(desktop.AllComponents);
        }

        /// <summary>
        /// Gets data consumers of collection
        /// </summary>
        /// <param name="collection">The collectionp</param>
        /// <returns>Consumers</returns>
        public static List<IDataConsumer> GetDataConsumers(this IEnumerable<object> collection)
        {
            List<IDataConsumer> list = new List<IDataConsumer>();
            foreach (object o in collection)
            {
                if (!(o is IObjectLabel))
                {
                    continue;
                }
                IObjectLabel l = o as IObjectLabel;
                object ob = l.Object;
                if (!(ob is IDataConsumer))
                {
                    continue;
                }
                IDataConsumer c = ob as IDataConsumer;
                list.Add(c);
            }
            return list;
        }

        /// <summary>
        /// Gets dependent objects of data consumer
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="list">List of dependent objects</param>
        public static void GetDependentObjects(this IDataConsumer consumer, IList<object> list)
        {
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                if (m is IRuntimeUpdate)
                {
                    if (!(m as IRuntimeUpdate).ShouldRuntimeUpdate)
                    {
                        continue;
                    }
                }
                if (!list.Contains(m))
                {
                    list.Insert(0, m);
                }
                if (m is IDataConsumer)
                {
                    IDataConsumer c = m as IDataConsumer;
                    GetDependentObjects(c, list);
                }
            }
        }

        /// <summary>
        /// Gets dependent objects of data consumer
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <returns>List of dependent objects</returns>
        public static IList<Object> GetDependentObjects(this IDataConsumer consumer)
        {
            List<object> l = new List<object>();
            GetDependentObjects(consumer, l);
            return l;
        }

        /// <summary>
        /// Gets dependent collection
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        /// <returns>Dependent collection</returns>
        public static IComponentCollection GetDependentCollection(this IDataConsumer consumer,
            int priority = 0, string reason = null)
        {
            return Factory.CreateCollection(consumer, priority, reason);
        }

        /// <summary>
        /// Finds Alias name object
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="alias">Name of alias</param>
        /// <param name="allowNulls">The "allow nulls" sign</param>
        /// <returns>The AliasName object</returns>
        public static AliasName FindAliasName(this IDataConsumer consumer, string alias, bool allowNulls)
        {
            if (alias == null)
            {
                if (allowNulls)
                {
                    throw new OwnException("Null alias is not accepted");
                }
                return null;
            }
            IAssociatedObject ao = consumer as IAssociatedObject;
            INamedComponent nc = ao.Object as INamedComponent;
            return FindAliasName(consumer, nc.Desktop, alias);
        }

        /// <summary>
        /// Finds alias by name
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="alias">Alias name</param>
        /// <param name="allowNulls">The "allow nulls" sign</param>
        /// <returns>Necessary aliases</returns>
        public static IAliasName[] FindAllAliasName(this IDataConsumer consumer, string alias, bool allowNulls)
        {
            if (alias == null)
            {
                if (allowNulls)
                {
                    throw new OwnException("Null alias is not accepted");
                }
                return null;
            }
            IAssociatedObject ao = consumer as IAssociatedObject;
            INamedComponent nc = ao.Object as INamedComponent;
            return FindAllAliasName(consumer, consumer, alias);
        }

        /// <summary>
        /// Finds aliases
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="aliases">Names of aliases</param>
        /// <param name="allowNulls">The "allow null" sign</param>
        /// <returns>Array of aliases</returns>
        public static AliasName[] FindAliases(this IDataConsumer consumer, string[] aliases, bool allowNulls)
        {
            AliasName[] an = new AliasName[aliases.Length];
            for (int i = 0; i < an.Length; i++)
            {
                string s = aliases[i];
                if (s != null)
                {
                    an[i] = FindAliasName(consumer, s, allowNulls);
                }
            }
            return an;
        }

        /// <summary>
        /// Finds alias 
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="desktop">Desktop</param>
        /// <param name="alias">Alias name</param>
        /// <returns>Alias</returns>
        public static AliasName FindAliasName(this IDataConsumer consumer, 
            IDesktop desktop, string alias)
        {
            string ali = alias;
            IDesktop desk = null;
            if (ali.StartsWith("../"))
            {
                int k = ali.LastIndexOf('.');
                string n = ali.Substring(0, k);
                INamedComponent nc = PureDesktop.GetFromRoot(desktop, n);
                desk = nc.Desktop;
                k = ali.LastIndexOf("/");
                ali = ali.Substring(k + 1);
            }
            object[] o = FindAlias(consumer, desk, ali);
            if (o == null)
            {
                return null;
            }
            return new AliasName(o[0] as IAlias, o[1] as string); ;
        }

        /// <summary>
        /// Find aliases
        /// </summary>
        /// <param name="baseObject">Base object</param>
        /// <param name="consumer">Consumer</param>
        /// <param name="alias">Alias name</param>
        /// <returns>All alias name objects</returns>
        public static IAliasName[] FindAllAliasName(this IDataConsumer baseObject, IDataConsumer consumer, string alias)
        {
            if (consumer != baseObject)
            {
                IAliasName[] an = FindAllAliasObjectName(baseObject, consumer, alias);
                if (an != null)
                {
                    return an;
                }
            }
            for (int i = 0; i < consumer.Count; i++)
            {
                object o = consumer[i];
                if (o is IDataConsumer)
                {
                    IAliasName[] res = FindAllAliasName(baseObject, o as IDataConsumer, alias);
                    if (res != null)
                    {
                        return res;
                    }
                }
                IAliasName[] an = FindAllAliasObjectName(baseObject, o, alias);
                if (an != null)
                {
                    return an;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds all aliases
        /// </summary>
        /// <param name="baseObject">Base object</param>
        /// <param name="o">Current object</param>
        /// <param name="alias">Alias name</param>
        /// <returns>All aliases</returns>
        public static IAliasName[] FindAllAliasObjectName(this IDataConsumer baseObject, object o, string alias)
        {
            IAssociatedObject asc = baseObject as IAssociatedObject;
            if (o is MeasurementsWrapper)
            {
                MeasurementsWrapper mw = o as MeasurementsWrapper;
                for (int i = 0; i < mw.Count; i++)
                {
                    IAliasName[] an = FindAllAliasObjectName(baseObject, mw[i], alias);
                    if (an != null)
                    {
                        return an;
                    }
                }
            }
            if (o is IAliasBase)
            {
                IAliasBase ab = o as IAliasBase;
                if (o is IAssociatedObject)
                {
                    IAssociatedObject ao = o as IAssociatedObject;
                    if (ao.Object != null)
                    {
                        if (ao.Object is INamedComponent)
                        {
                            IAlias al = AliasWrapper.GetAlias(ao);
                            if (al != null)
                            {
                                string n = asc.GetRelativeName(ao);
                                IList<string> l = al.AliasNames;
                                foreach (string an in l)
                                {
                                    string s = n + "." + an;
                                    if (s.Equals(alias))
                                    {
                                        return new IAliasName[] { new AliasName(al, an) };
                                    }
                                }
                            }
                            if (ab is IAliasVector)
                            {
                                IAliasVector av = ab as IAliasVector;
                                string n = asc.GetRelativeName(ao);
                                IList<string> l = av.AliasNames;
                                foreach (string an in l)
                                {
                                    string s = n + "." + an;
                                    if (s.Equals(alias))
                                    {
                                        List<IAliasName> list = new List<IAliasName>();
                                        int count = av.GetCount(an);
                                        for (int j = 0; j < count; j++)
                                        {
                                            list.Add(new AliasNameVector(av, an, j));
                                        }
                                        return list.ToArray();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Finds alias by name
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="desktop">Desktop</param>
        /// <param name="alias">Alias name</param>
        /// <returns>Alias</returns>
        public static object[] FindAlias(this IDataConsumer consumer, IDesktop desktop, string alias)
        {
            for (int i = 0; i < consumer.Count; i++)
            {
                object o = consumer[i];
                if (o is IAssociatedObject)
                {
                    IAssociatedObject ao = o as IAssociatedObject;
                    IAlias al = AliasWrapper.GetAlias(ao);
                    if (al != null)
                    {
                        if (ao.Object != null)
                        {
                            if (ao.Object is INamedComponent)
                            {
                                INamedComponent nc = ao.Object as INamedComponent;
                                string n = nc.Name;
                                IList<string> l = al.AliasNames;
                                foreach (string an in l)
                                {
                                    string s = n + "." + an;
                                    if (s.Equals(alias))
                                    {
                                        return new object[] { al, an };
                                    }
                                }
                            }
                        }
                    }
                }
                if (o is IDataConsumer)
                {
                    IDataConsumer c = o as IDataConsumer;
                    object[] r = FindAlias(c, desktop, alias);
                    if (r != null)
                    {
                        return r;
                    }
                }
            }
            return null;

        }

        /// <summary>
        /// Number of step
        /// </summary>
        static public int StepNumber
        {
            get
            {
                return stepNumber;
            }
            set
            {
                stepNumber = value;
            }
        }

        /// <summary>
        /// Runtime factory
        /// </summary>
        public static IDataRuntimeFactory Factory
        {
            get;
            set;
        }

        /// <summary>
        /// Prepares data consumer
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="time">The time</param>
        /// <param name="reason">The reason</param>
        /// <param name="priority">The priority</param>
        public static void PrepareDataConsumer(this IDataConsumer consumer, double time, 
            string reason = StaticExtensionDataPerformerInterfaces.Calculation, 
            int priority = 0)
        {
            var runtime = Factory.Create(consumer, priority, reason);
            runtime.StartAll(time);
        }


        /// <summary>
        /// Sets base factory
        /// </summary>
        /// <param name="replace">Factory for replacement</param>
        public static void SetBase(this IDataRuntimeFactory replace)
        {
            if (replace == null)
            {
                throw new OwnException();
            }
            if (Factory == null)
            {
                Factory = replace;
                return;
            }
            if (Factory.IsBase(replace))
            {
                Factory = replace;
            }
        }

        /// <summary>
        /// Finds alias object
        /// </summary>
        /// <param name="baseObject">Base object</param>
        /// <param name="consumer">Data consumer</param>
        /// <param name="alias">Full alias</param>
        /// <returns>Pair object[]{object, alias}</returns>
        public static object[] FindAlias(this IDataConsumer baseObject, IDataConsumer consumer, string alias)
        {
            IAssociatedObject ao = baseObject as IAssociatedObject;
            INamedComponent nc = PureObjectLabel.PrefixComponent(ao, consumer, alias);
            if ((nc != null) & (consumer is IAliasBase))
            {
                return new object[] { consumer, PureObjectLabel.Suffix(alias) };
            }
            for (int i = 0; i < consumer.Count; i++)
            {
                object o = consumer[i];
                if (o is IDataConsumer)
                {
                    IDataConsumer c = o as IDataConsumer;
                    object[] r = baseObject.FindAlias(c, alias);
                    if (r != null)
                    {
                        return r;
                    }
                }
                else
                {
                    INamedComponent comp = PureObjectLabel.PrefixComponent(ao, o, alias);
                    if ((comp != null) & (o is IAlias))
                    {
                        IAlias al = o as IAlias;
                        if (o is IAssociatedObject)
                        {
                            IAssociatedObject aso = o as IAssociatedObject;
                            al = AliasWrapper.GetAlias(aso);
                        }
                        return new object[] { al, PureObjectLabel.Suffix(alias) };
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets name of measure
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="measurement">Measure</param>
        /// <returns>The name</returns>
        public static string GetName(this IDataConsumer consumer, IMeasurement measurement)
        {
            IAssociatedObject ass = consumer as IAssociatedObject;
            INamedComponent comp = ass.Object as INamedComponent;
            IDesktop d = comp.Desktop;
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements mea = consumer[i];
                for (int j = 0; j < mea.Count; j++)
                {
                    IMeasurement m = mea[j];
                    if (m == measurement)
                    {
                        IAssociatedObject ao = mea as IAssociatedObject;
                        INamedComponent nc = ao.Object as INamedComponent;
                        string name = PureObjectLabel.GetName(nc, d);
                        return name + "." + m.Name;
                    }
                }
            }
            if (consumer is IMeasurements)
            {
                if (consumer.ShouldInsertIntoChildren())
                {
                    if (consumer is IAssociatedObject)
                    {
                        IMeasurements measurements = consumer as IMeasurements;
                        var o = (consumer as IAssociatedObject).Object;
                        if (o is INamedComponent)
                        {
                            var nn = (o as INamedComponent).Name + ".";
                            foreach (var mt in measurements.GetMeasurementObjects())
                            {
                                if (mt == measurement)
                                {
                                    return nn + mt.Name;
                                }
                             }
                        }
                    }
                  
                }
            }
            return null;
        }

        /// <summary>
        /// Finds measurement
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="name">Name</param>
        /// <returns>Measurement</returns>
        public static IMeasurement FindMeasurement(this IDesktop desktop, string name)
        {
            string s = name.Substring(0, name.LastIndexOf('.'));
            IMeasurements m = desktop.GetObject<IMeasurements>(s);
            return m.GetMeasurement(name.Substring(s.Length + 1));
        }

        /// <summary>
        /// Finds measurements
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="name">Names</param>
        /// <returns>Measurements</returns>
        public static IMeasurement[] FindMeasurements(this IDesktop desktop, string[] names)
        {
            List<IMeasurement> l = new List<IMeasurement>();
            foreach (string name in names)
            {
                l.Add(desktop.FindMeasurement(name));
            }
            return l.ToArray();
        }

        /// <summary>
        /// Finds measure
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="measurement">Measure name</param>
        /// <param name="allowNull">The allow null sign</param>
        /// <returns>The measure</returns>
        public static IMeasurement FindMeasurement(this IDataConsumer consumer, string measurement, bool allowNull = false)
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
            IAssociatedObject ass = consumer as IAssociatedObject;
            INamedComponent comp = ass.Object as INamedComponent;
            IDesktop d = comp.Desktop;
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements mea = consumer[i];
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
            if (consumer is IMeasurements)
            {
                if (consumer.ShouldInsertIntoChildren())
                {
                    var cm = consumer as IMeasurements;
                    foreach (var cmm in cm.GetMeasurementObjects())
                    {
                        var nm = consumer.GetName(cmm);
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
        /// Gets relative name of measurements
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <param name="measurements">The measurements</param>
        /// <returns>The name</returns>
        public static string GetRelativeMeasurementsName(this IDataConsumer consumer, IMeasurements measurements)
        {
            return (consumer as IAssociatedObject).GetRelativeName(measurements as IAssociatedObject);
        }

 
        /// <summary>
        /// Find measurements of consumer by strings
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <param name="measurements">String representation of measures</param>
        /// <param name="allowNulls">The "allow nulls" flag</param>
        /// <returns>Array of measures</returns>
        static public IMeasurement[] FindMeasurements(this IDataConsumer consumer, string[] measurements, bool allowNulls)
        {
            IMeasurement[] m = new IMeasurement[measurements.Length];
            for (int i = 0; i < m.Length; i++)
            {
                string s = measurements[i];
                if (s != null)
                {
                    m[i] = FindMeasurement(consumer, measurements[i], allowNulls);
                }
            }
            return m;
        }

        /// <summary>
        /// Finds alias object
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="alias">Full alias</param>
        /// <returns>Pair object[]{object, alias}</returns>
        public static object[] FindAlias(this IDataConsumer consumer, string alias)
        {
            if (alias == null)
            {
                return null;
            }
            return FindAlias(consumer, consumer, alias);
        }

        /// <summary>
        /// Gets relative name
        /// </summary>
        /// <param name="o">Base object</param>
        /// <param name="measurements">Measurements</param>
        /// <returns>The name</returns>
        public static string GetName(this IAssociatedObject o, IMeasurements measurements)
        {
            IAssociatedObject ao = measurements as IAssociatedObject;
            return o.GetRelativeName(ao);
        }

        /// <summary>
        /// Gets relative name of measurement
        /// </summary>
        /// <param name="dataConsumer">Data consumer of measurement</param>
        /// <param name="mea">Source of measurement</param>
        /// <returns>Relative name</returns>
        public static string GetMeasurementsName(this IDataConsumer dataConsumer, IMeasurements mea)
        {
            IAssociatedObject ao = dataConsumer as IAssociatedObject;
            return ao.GetName(mea);
        }

        /// <summary>
        /// Step action 
        /// </summary>
        /// <param name="runtime">Runtime</param>
        /// <param name="processor">Processor</param>
        /// <param name="setTime">Set time action</param>
        /// <param name="reason">Reason</param>
        /// <returns>Step action</returns>
        public static Action<double, double, long> Step(this IDataRuntime runtime,
            IDifferentialEquationProcessor processor, Action<double> setTime, string reason,
            IAsynchronousCalculation calculation = null)
        {
            if (calculation == null)
            {
                return runtime.Step(processor, setTime, reason);
            }
            IEnumerable<object> enu = runtime.AllComponents;
            List<Action> updatable = new List<Action>();
            List<IStep> step = new List<IStep>();
            List<IDynamical> dynamical = new List<IDynamical>();
            Action<double> stepAction = calculation.Step;
            if (stepAction != null)
            {
                Action<double> go = (double a) =>
                {
                    calculation.Start(a);
                    go = stepAction;
                };
                foreach (object o in enu)
                {
                    if (o is IUpdatableObject)
                    {

                        if (o.SatisfiesReason(reason))
                        {
                            IUpdatableObject uo = o as IUpdatableObject;
                            if (uo.Update != null)
                            {
                                updatable.Add(uo.Update);
                            }
                        }
                    }
                    if (o is IStep)
                    {
                        step.Add(o as IStep);
                    }
                    if (o is IDynamical)
                    {
                        dynamical.Add(o as IDynamical);
                    }
                }
                if (processor != null)
                {
                    return (double last, double time, long i) =>
                    {
                        if (i == 0)
                        {
                            foreach (object o in enu)
                            {
                                if (o is IStarted)
                                {
                                    (o as IStarted).Start(time);
                                }
                            }
                        }
                        setTime(time);
                        if (i > 0)
                        {
                            processor.Step(last, time);
                        }
                        foreach (IDynamical d in dynamical)
                        {
                            d.Time = time;
                        }
                        foreach (IStep s in step)
                        {
                            s.Step = i;
                        }
                        runtime.Time = time;
                        runtime.UpdateAll();
                        go(time);
                    };
                }
                else
                {
                    return (double last, double time, long i) =>
                    {
                        if (i == 0)
                        {
                            foreach (object o in enu)
                            {
                                if (o is IStarted)
                                {
                                    (o as IStarted).Start(time);
                                }
                            }
                        }
                        foreach (Action u in updatable)
                        {
                            u();
                        }
                        setTime(time);
                        foreach (IDynamical d in dynamical)
                        {
                            d.Time = time;
                        }
                        foreach (IStep s in step)
                        {
                            s.Step = i;
                        }
                        runtime.Time = time;
                        runtime.UpdateAll();
                        if (i == 0)
                        {
                            calculation.Start(time);
                        }
                        else
                        {
                            calculation.Step(time);
                        }
                    };
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets count of variables
        /// </summary>
        /// <param name="processor">Processor</param>
        /// <returns>Variables</returns>
        static public int GetVariablesCount(this IDifferentialEquationSolver processor)
        {
            return processor.Variables.Count;
        }

        /// <summary>
        /// Sorts measurements
        /// </summary>
        /// <param name="measurements">Measurements for sort</param>
        public static void SortMeasurements(this List<IMeasurements> measurements)
        {
            measurements.ClearDoubleObjectsFormList();
            measurements.SortPatriallyOrderedSet(measurementsComparer);
        }

        /// <summary>
        /// Sorts started objects
        /// </summary>
        /// <param name="started">Statred objects for sort</param>
        public static void SortStarted(this List<IStarted> started)
        {
            Comparation.MeasurementsComparer.Sort(started);
        }

        /// <summary>
        /// Stops run
        /// </summary>
        public static void StopRun()
        {
            throw new ErrorHandler.FictionException("");
        }

        /// <summary>
        /// Time
        /// </summary>
        public static double Time
        {
            get
            {
                return Factory.TimeProvider.Time;
            }
            set
            {
                Factory.TimeProvider.Time = value;
            }
        }

        /// <summary>
        /// Gets priority of object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The priority</returns>
        public static int GetPriority(this object obj)
        {
            object[] coll = obj.GetObjects();
            int p = 0;
            foreach (object o in coll)
            {
                int i = o.GetCalculationPriority();
                if (i > p)
                {
                    p = i;
                }
            }
            return p;
        }

        /// <summary>
        /// Calculation priority
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Priority</returns>
        public static int GetCalculationPriority(this object obj)
        {
            ///!!!!!!
            object[] attr = null;// obj.GetType().GetCustomAttributes(typeof(CalculationPriorityAttribute), true);
            if (attr == null)
            {
                return 0; ;
            }
            if (attr.Length == 0)
            {
                return 0;
            }
            foreach (object o in attr)
            {
                if (o is CalculationPriorityAttribute)
                {
                    CalculationPriorityAttribute c = o as CalculationPriorityAttribute;
                    return c.Priority;
                }
            }
            return 0;
        }

        /// <summary>
        /// Checks whether one should include to children
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Result</returns>
        static public bool ShouldInsertIntoChildren(this object value)
        {
            var att = 
                performer.GetAttribute<InsertIntoChilldrenCollectionAttribute>(value);
            return att == null ? false : att.Insert;
        }


        #endregion

        #region Private Members

        static private Action GetUpdate(this IEnumerable<object> value, string reason)
        {
            Func<object, Action> tr = (object ob) =>
            {
                if (ob is IUpdatableObject up)
                {

                    if (ob.SatisfiesReason(reason))
                    {
                        return up.Update;
                    }
                }
                return null;
            };
           return value.TransformEnumerabe<Action, object>(tr).ToSingleAction();
        }


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

        static private Dictionary<IMeasurement, string> GetMeasurementsDictionaryPrivate(this IDataConsumer dataConsumer)
        {
            Dictionary<IMeasurement, string> d = new Dictionary<IMeasurement, string>();
            for (int i = 0; i < dataConsumer.Count; i++)
            {
                IMeasurements m = dataConsumer[i];
                string n = dataConsumer.GetMeasurementsName(m) + ".";
                for (int j = 0; j < m.Count; j++)
                {
                    IMeasurement mm = m[j];
                    d[mm] = n + mm.Name;
                }
            }

            return d;
        }


        /// <summary>
        /// Step action 
        /// </summary>
        /// <param name="runtime">Runtime</param>
        /// <param name="processor">Processor</param>
        /// <param name="setTime">Set time action</param>
        /// <param name="reason">Reason</param>
        /// <returns>Step action</returns>
        private static Action<double, double, long> Step(this IDataRuntime runtime,
             IDifferentialEquationProcessor processor, Action<double> setTime, string reason)
        {
            IEnumerable<object> enu = runtime.AllComponents;
            List<Action> updatableActions = new List<Action>();
            List<IStep> step = new List<IStep>();
            List<IDynamical> dynamical = new List<IDynamical>();
            var update = enu.GetUpdate(reason);
            foreach (object o in enu)
            {
                if (o is IStep)
                {
                    step.Add(o as IStep);
                }
                if (o is IDynamical)
                {
                    dynamical.Add(o as IDynamical);
                }
            }
            if (processor != null)
            {
                return (double last, double time, long i) =>
                {
                    if (i == 0)
                    {
                        foreach (object o in enu)
                        {
                            if (o is IStarted started)
                            {
                                started.Start(time);
                            }
                        }
                    }
                    if (i > 0)
                    {
                        processor.Step(last, time);
                    }
                    update?.Invoke();
                    foreach (IDynamical d in dynamical)
                    {
                        d.Time = time;
                    }
                    foreach (IStep s in step)
                    {
                        s.Step = i;
                    }
                    runtime.Time = time;
                    runtime.UpdateAll();
                };
            }
            else
            {
                return (double last, double time, long i) =>
                {
                    if (i == 0)
                    {
                        foreach (object o in enu)
                        {
                            if (o is IStarted)
                            {
                                (o as IStarted).Start(time);
                            }
                        }
                    }
                    update?.Invoke();
                    setTime(time);
                    foreach (IDynamical d in dynamical)
                    {
                        d.Time = time;
                    }
                    foreach (IStep s in step)
                    {
                        s.Step = i;
                    }
                    runtime.Time = time;
                    runtime.UpdateAll();
                };
            }
        }

        private static void getAliases(this IDataConsumer baseObject, IDataConsumer consumer, List<string> list, object type)
        {
            IAssociatedObject ao = baseObject as IAssociatedObject;
            PureObjectLabel.GetObjectAliases(ao, consumer, list, type);
            for (int i = 0; i < consumer.Count; i++)
            {
                object o = consumer[i];
                if (o is IDataConsumer)
                {
                    IDataConsumer c = o as IDataConsumer;
                    getAliases(baseObject, c, list, type);
                }
                else
                {
                    PureObjectLabel.GetObjectAliases(ao, o, list, type);
                }
            }
        }

        private static void getAllAliases(this IDataConsumer baseObject, IDataConsumer consumer, List<string> list, object type)
        {
            IAssociatedObject ao = baseObject as IAssociatedObject;
            PureObjectLabel.GetObjectAliases(ao, consumer, list, type);
            for (int i = 0; i < consumer.Count; i++)
            {
                object o = consumer[i];
                if (o is IDataConsumer)
                {
                    IDataConsumer c = o as IDataConsumer;
                    getAllAliases(baseObject, c, list, type);
                }
                else
                {
                    PureObjectLabel.GetAllObjectAliases(ao, o, list, type);
                }
            }
        }
    
        /// <summary>
        /// Sets time provider to data consumer and all dependent objects
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="provider">Data provider</param>
        /// <returns>Backup dictionary</returns>
        private static IDictionary<ITimeMeasurementConsumer, IMeasurement> SetTimeProvider(this IDataConsumer consumer, ITimeMeasurementProvider provider)
        {
            Dictionary<ITimeMeasurementConsumer, IMeasurement> dictionary = new Dictionary<ITimeMeasurementConsumer, IMeasurement>();
            SetTimeProvider(consumer, provider, dictionary);
            return dictionary;
        }

        /// <summary>
        /// Sets time provider to data consumer and all dependent objects
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="provider">Data provider</param>
        /// <param name="dictionary">Backup dictionary</param>
        private static void SetTimeProvider(this IDataConsumer consumer, ITimeMeasurementProvider provider, IDictionary<ITimeMeasurementConsumer, IMeasurement> dictionary)
        {
            if (consumer is ITimeMeasurementConsumer)
            {
                ITimeMeasurementConsumer tc = consumer as ITimeMeasurementConsumer;
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
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                if (m is ITimeMeasurementConsumer)
                {
                    ITimeMeasurementConsumer mc = m as ITimeMeasurementConsumer;
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
            }
        }

        #endregion

        #region Classes

        class DefautFactory : ITimeMeasurementProviderFactory
        {

            ITimeMeasurementProvider ITimeMeasurementProviderFactory.Create(bool isAbsolute, 
                TimeType timeUnit, string reason)
            {
                if (reason == "Realtime")
                {
                    return new Runtime.RealtimeProviderRealtime(isAbsolute, timeUnit);
                }
                return new Runtime.RealtimeProviderAnalysis(isAbsolute, timeUnit);
            }
        }


        #endregion
    }
}
