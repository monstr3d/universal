using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;


using BaseTypes;
using BaseTypes.Interfaces;

using Diagram.UI;
using Diagram.UI.Interfaces;


using DataPerformer.Interfaces;
using DataPerformer.SeriesTypes;
using DataPerformer.Portable;

using DataPerformer.Portable.DifferentialEquationProcessors;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataPerformer
{
    /// <summary>
    /// Base class of data consumers
    /// </summary>
    [Serializable()]
    public class DataConsumer : DataConsumerIterate, ISerializable
    {    

        #region Fields

  

        /// <summary>
        /// Controls of graph
        /// </summary>
        private ArrayList graphControls = new ArrayList();

 

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of consumer</param>
        public DataConsumer(int type) : base(type)
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DataConsumer(SerializationInfo info, StreamingContext context) : base(0)
        {
            type = (int)info.GetValue("Type", typeof(int));
            try
            {
                graphControls = (ArrayList)info.GetValue("GraphConrtols", typeof(ArrayList));
                start = (double)info.GetValue("Start", typeof(double));
                step = (double)info.GetValue("Step", typeof(double));
                steps = (int)info.GetValue("Steps", typeof(int));
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
            initialize();
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", type);
            info.AddValue("GraphConrtols", graphControls);
            info.AddValue("Start", start);
            info.AddValue("Step", step);
            info.AddValue("Steps", steps);
        }

        #endregion

        /// <summary>
        /// Controls of graph
        /// </summary>
        public ArrayList GraphControls
        {
            get
            {
                return graphControls;
            }
            set
            {
                graphControls = value;
            }
        }



        #region Static Helper Members


        /// <summary>
        /// Creates document with arrays
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <returns>Xml document</returns>
        public static XmlDocument GetArraysXmlDocument(IDataConsumer consumer)
        {
            ArrayList meas = new ArrayList();
            int[] r = null;
            int n = consumer.Count;
            for (int i = 0; i < n; i++)
            {
                IMeasurements mea = consumer[i];
                int k = mea.Count;
                for (int j = 0; j < k; j++)
                {
                    IMeasurement m = mea[j];
                    object type = m.Type;
                    if (!(type is ArrayReturnType))
                    {
                        continue;
                    }
                    ArrayReturnType art = type as ArrayReturnType;
                    int[] rr = art.Dimension;
                    if (rr.Length > 1)
                    {
                        continue;
                    }
                    if (r == null)
                    {
                        r = rr;
                    }
                    if (r[0] != rr[0])
                    {
                        continue;
                    }
                    meas.Add(m);
                }
            }
            if (r == null)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version=\"1.0\"?><ExperimentalData><Root></Root></ExperimentalData>");
            XmlElement root = doc.GetElementsByTagName("Root")[0] as XmlElement;
            XmlAttribute att = doc.CreateAttribute("uid");
            att.Value = Guid.NewGuid() + "";
            root.Attributes.Append(att);
            att = doc.CreateAttribute("time");
            att.Value = DateTime.Now + "";
            root.Attributes.Append(att);
            XmlElement descr = doc.CreateElement("ParametersDescription");
            root.AppendChild(descr);
            for (int i = 0; i < meas.Count; i++)
            {
                IMeasurement m = meas[i] as IMeasurement;
                XmlElement e = doc.CreateElement("ParameterDescription");
                descr.AppendChild(e);
                att = doc.CreateAttribute("id");
                att.Value = i + "";
                e.Attributes.Append(att);
                att = doc.CreateAttribute("name");
                att.Value = m.Name;
                e.Attributes.Append(att);
            }
            XmlElement results = doc.CreateElement("Results");
            root.AppendChild(results);
            for (int i = 0; i < r[0]; i++)
            {
                XmlElement result = doc.CreateElement("Result");
                results.AppendChild(result);
                for (int j = 0; j < meas.Count; j++)
                {
                    IMeasurement mea = meas[j] as IMeasurement;
                    XmlElement par = doc.CreateElement("Parameter");
                    result.AppendChild(par);
                    att = doc.CreateAttribute("id");
                    att.Value = j + "";
                    par.Attributes.Append(att);
                    att = doc.CreateAttribute("value");
                    object[] o = mea.Parameter() as object[];
                    att.Value = o[i] + "";
                    par.Attributes.Append(att);
                }
            }
            return doc;
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Creates measurements
        /// </summary>
        /// <param name="argument">Argument</param>
        /// <param name="values">Names of values</param>
        /// <param name="series">series</param>
        /// <param name="functions">functions</param>
        /// <param name="disassembly">Disassembly</param>
        /// <returns>Mesurements dictionary</returns>
        public Dictionary<string, object>  CreateMeasurements(string argument, string[] values,  out ParametrizedSeries[] series, 
            out Dictionary<DoubleArrayFunction, IMeasurement[]> functions, Dictionary<IMeasurement, MeasurementsDisassemblyWrapper> disassembly = null)
        {
            Dictionary<IMeasurement, MeasurementsDisassemblyWrapper> dis = new Dictionary<IMeasurement, MeasurementsDisassemblyWrapper>();
            if (disassembly != null)
            {
                dis = disassembly;
            }
            double a = 0;
            functions = new Dictionary<DoubleArrayFunction, IMeasurement[]>();
            series = null;
            if (argument == null | values == null)
            {
                return null;
            }
            IMeasurement arg = null;
            if (argument.Equals("Time"))
            {
                arg = StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;
            }
            else
            {
                arg = this.FindMeasurement(argument, false);
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            List<ParametrizedSeries> m = new List<ParametrizedSeries>();
            foreach (string key in values)
            {
                object o = null;
                IMeasurement val = this.FindMeasurement(key, false);
                if (val == null)
                {
                    continue;
                }
                object t = val.Type;
                if (t.IsDoubleType())
                {

                    var ps =
                        new ParametrizedSeries(arg.ToValueHolder(), val.ToValueHolder(), t)
                        {
                            Attached = key
                        };
                    
                    m.Add(ps);
                    o = ps;
                }
                else if (disassembly.ContainsKey(val))
                {
                    MeasurementsDisassemblyWrapper mv = disassembly[val];
                    string k = key.Substring(0, key.IndexOf('.') + 1);
                    foreach (IMeasurement mea in mv.Measurements)
                    {

                        ParametrizedSeries ps =
                            new ParametrizedSeries(arg.ToValueHolder(), mea.ToValueHolder());
                        m.Add(ps);
                        if (ps != null)
                        {
                            d[k + mea.Name] = ps;
                        }

                    }
                    continue;

                    /* TEMP DELETE   DoubleArrayFunction f = new DoubleArrayFunction(t);
                    functions[f] = new IMeasurement[] { arg, val };
                    o = f;
                    */
                }
                if (o != null)
                {
                    d[key] = o;
                }
           }
            series = m.ToArray();
            Prepare();
            return d;
        }

        public Dictionary<string, object> PerformIterator(IIterator iterator, string argument, string[] values,
             
      Func<bool> stop)
        {
            ParametrizedSeries[] series;
            return PerformIterator(iterator, argument, values, out series, stop);
        }

        private  Dictionary<string, object> PerformIterator(IIterator iterator, string argument, string[] values,
             out ParametrizedSeries[] series,
      Func<bool> stop)
        {
            Dictionary<DoubleArrayFunction, IMeasurement[]> functions;
            Dictionary<string, object> dic = CreateMeasurements(argument, values, out series, out functions, null);
            this.ResetAll();
            do
            {
                if (stop())
                {
                    break;
                }
                this.UpdateAll();
                foreach (var s in series)
                {
                    s.Step();
                }
            }
            while (iterator.Next());
            return dic;
        }



        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="start">Start time</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="argument">Argument</param>
        /// <param name="values">Values</param>
        /// <param name="series">Series</param>
        /// <param name="functions">Functions</param>
        /// <param name="stop">Stop function</param>
        /// <param name="disassembly">Disassembly</param>
        /// <returns>Result of simulation</returns>
        public Dictionary<string, object> PerformFixed(double start, double step, int count, string argument, string[] values,
             out ParametrizedSeries[] series,
            out Dictionary<DoubleArrayFunction, IMeasurement[]> functions, Func<bool> stop, Dictionary<IMeasurement, MeasurementsDisassemblyWrapper> disassembly = null)
        {
            try
            {
                series = null;
                functions = null;
                Dictionary<string, object> dic = CreateMeasurements(argument, values, out series, out functions, disassembly);
                if (dic == null)
                {
                    return null;
                }
                PerformFixed(start, step, count, argument, values, series, functions, stop, 
                    StaticExtensionDataPerformerInterfaces.Calculation, disassembly);
                return dic;
            }

            catch (Exception ex)
            {
                if (!ex.IsFiction())
                {
                    ex.ShowError(10);
                }
            }
            series = null;
            functions = null;
            return null;
        }

        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="argument">Argument</param>
        /// <param name="values">Values</param>
        /// <param name="stop">Stop function</param>
        /// <param name="disassembly">Disassembly</param>
        /// <returns>Action result</returns>
        public Dictionary<string, object> PerformFixed(string argument, string[] values, Func<bool> stop,
            Dictionary<IMeasurement, MeasurementsDisassemblyWrapper> disassembly = null)
        {
            return PerformFixed(start, step, steps, argument, values, stop, disassembly);
        }

        /// <summary>
        /// Performs action with array of arguments
        /// </summary>
        /// <param name="array">Array of arguments</param>
        /// <param name="argument">Argument</param>
        /// <param name="values">Values</param>
        /// <param name="series">Series</param>
        /// <param name="functions">Functions</param>
        /// <param name="stop">Stop function</param>
        /// <returns>Result of simulation</returns>
        public Dictionary<string, object> PerformArray(Array array, string argument, string[] values,
             out ParametrizedSeries[] series,
            out Dictionary<DoubleArrayFunction, IMeasurement[]> functions, Func<bool> stop)
        {
            try
            {
                series = null;
                functions = null;
                Dictionary<string, object> dic = CreateMeasurements(argument, values, out series, out functions);
                if (dic == null)
                {
                    return null;
                }
                PerformArray(array, argument, values, series, functions, stop);
                return dic;
            }

            catch (Exception ex)
            {
                ex.ShowError(10);
                this.Throw(ex);
            }
            series = null;
            functions = null;
            return null;
        }

        /// <summary>
        /// Performs action with array of arguments
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="argument">Argument</param>
        /// <param name="values">Values</param>
        /// <param name="stop">Stop function</param>
        /// <returns>Result of simulation</returns>
        public Dictionary<string, object> PerformArray(Array array, string argument, string[] values, Func<bool> stop)
        {
            ParametrizedSeries[] series = null;
            Dictionary<DoubleArrayFunction, IMeasurement[]> functions = null;
            return PerformArray(array, argument, values, out series, out functions, stop);
        }

        /// <summary>
        /// Performs operation with fixed step
        /// </summary>
        /// <param name="start">Start time</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="argument">Argument</param>
        /// <param name="values">Values</param>
        /// <param name="stop">The stop function</param>
        /// <param name="disassembly">Disassembly</param>
        /// <returns>Dictionary of performed result</returns>
        public Dictionary<string, object> PerformFixed(double start, double step, int count,
            string argument, string[] values, Func<bool> stop, 
            Dictionary<IMeasurement, MeasurementsDisassemblyWrapper> disassembly = null)
        {
            ParametrizedSeries[] series = null;
            Dictionary<DoubleArrayFunction, IMeasurement[]> functions = null;
            return PerformFixed(start, step, steps, argument, values, out series, out functions, stop, disassembly);
        }

        #endregion

        #region Private Members

        private void PerformArray(Array array, string argument, string[] values,
      ParametrizedSeries[] series,
     Dictionary<DoubleArrayFunction, IMeasurement[]> functions, Func<bool> stop)
        {
            this.PerformArray(array, this.GetRootDesktop(), 
                StaticExtensionDataPerformerPortable.Factory.TimeProvider,
               DifferentialEquationProcessor.Processor, 0, () =>
               {
                   if (stop())
                   {
                       StaticExtensionDataPerformerPortable.StopRun();
                   }
                   UpdateChildrenData();
                   foreach (ParametrizedSeries s in series)
                   {
                       s.Step();
                   }
                   foreach (DoubleArrayFunction f in functions.Keys)
                   {
                       IMeasurement[] mm = functions[f];
                       double xx = (double)mm[0].Parameter();
                       f[xx] = mm[1].Parameter();
                   }
               }, null
           );
        }

   

        private void PerformFixed(double start, double step, int count, string argument, string[] values, 
     ParametrizedSeries[] series,
    Dictionary<DoubleArrayFunction, IMeasurement[]> functions, Func<bool> stop, string reason, Dictionary<IMeasurement, MeasurementsDisassemblyWrapper> disassembly = null)
        {
            Dictionary<IMeasurement, MeasurementsDisassemblyWrapper> dis = new Dictionary<IMeasurement, MeasurementsDisassemblyWrapper>();
            if (disassembly != null)
            {
                dis = disassembly;
            }
           this.PerformFixed(start, step, count, StaticExtensionDataPerformerPortable.Factory.TimeProvider,
               DifferentialEquationProcessor.Processor, reason,  0, () =>
               {
                   foreach (MeasurementsDisassemblyWrapper w in dis.Values)
                   {
                       w.Update();
                   }
                   if (stop())
                   {
                       StaticExtensionDataPerformerPortable.StopRun();
                   }
                   foreach (ParametrizedSeries s in series)
                   {
                       s.Step();
                   }
                   foreach (DoubleArrayFunction f in functions.Keys)
                   {
                       IMeasurement[] mm = functions[f];
                       double xx = (double)mm[0].Parameter();
                       f[xx] = mm[1].Parameter();
                   }
               }
           );
        }



        private void test(IDesktop desktop)
        {
            IDifferentialEquationProcessor processor = DifferentialEquationProcessor.Processor;
          /*  IDataPerformerRuntimeFactory str = StaticDataPerformer.Factory;
            if (str is IStep)
            {
                st = str as IStep;
            }
            for (int i = 0; i < steps; i++)
            {
                if (st != null)
                {
                    st.Step = i;
                }
                if (i == 0)
                {
                    desktop.StartAll(start);
                }
                desktop.UpdateAll();
                StaticDataPerformerExtension.Time = start + i * step;

                if (i > 0 & processor != null)
                {
                    processor.Step(start + i * step - step, start + i * step);
                }
                StaticDataPerformerExtension.Time = start + i * step;
                UpdateChildrenData();
                desktop.ResetUpdatedMeasurements();
            }*/

        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void initialize()
        {
            measurementsData = new List<IMeasurements>();
        }

        #endregion

    }
}
