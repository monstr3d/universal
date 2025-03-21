﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

using BaseTypes;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.SeriesTypes;
using DataPerformer.Portable;
using DataPerformer.Formula;
using AssemblyService.Attributes;
using ErrorHandler;

namespace DataPerformer
{
    /// <summary>
    /// Extension utilites
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataPerformerAdvanced
    { 
        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionDataPerformerAdvanced()
        {
            new Binder();
        }

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        /// <summary>
        /// Saves series to stream
        /// </summary>
        /// <param name="series">Series to save</param>
        /// <param name="stream">Stream for saving</param>
        static public void Save(this Series series, Stream stream)
        {
            Series s = new Series();
            s.CopyFrom(series);
            s.Comments = series.Comments;
            BinaryFormatter form = new BinaryFormatter();
            form.Serialize(stream, s);
        }

        /// <summary>
        /// Saves series to file
        /// </summary>
        /// <param name="series">Series</param>
        /// <param name="filename">File name</param>
        static public void Save(this Series series, string filename)
        {
            Stream str = File.OpenWrite(filename);
            series.Save(str);
            str.Close();
        }

        /// <summary>
        /// Loads series from stream
        /// </summary>
        /// <param name="series">The series</param>
        /// <param name="stream">Stream for load</param>
        static public void Load(this Series series, Stream stream)
        {
            BinaryFormatter form = new BinaryFormatter();
            Series s = form.Deserialize(stream) as Series;
            series.CopyFrom(s);
            series.Comments = s.Comments;
        }

        /// <summary>
        /// Loads series from file
        /// </summary>
        /// <param name="series">Series</param>
        /// <param name="filename">File name</param>
        static public void Load(this Series series, string filename)
        {
            Stream str = File.OpenRead(filename);
            Load(series, str);
            str.Close();
        }

        /// <summary>
        /// Creates measurements
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="argument">Argument</param>
        /// <param name="values">Names of values</param>
        /// <param name="series">series</param>
        /// <param name="functions">functions</param>
        /// <returns>Mesurements dictionary</returns>
        public static Dictionary<string, object> CreateMeasurements(this IDataConsumer consumer, string argument, string[] values, out ParametrizedSeries[] series,
            out Dictionary<DoubleArrayFunction, IMeasurement[]> functions)
        {
            Double a = 0;
            functions = new Dictionary<DoubleArrayFunction, IMeasurement[]>();
            series = null;
            if (argument == null | values == null)
            {
                return null;
            }
            IMeasurement arg = null;
            if (argument.Equals("Time"))
            {
                arg = DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;
            }
            else
            {
                arg = consumer.FindMeasurement(argument, false);
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            List<ParametrizedSeries> m = new List<ParametrizedSeries>();
            foreach (string key in values)
            {
                object o = null;
                IMeasurement val = consumer.FindMeasurement(key, false);
                object t = val.Type;
                if (t.Equals(a))
                {

                    ParametrizedSeries ps = new ParametrizedSeries(arg.ToValueHolder(), val.ToValueHolder());
                    m.Add(ps);
                    o = ps;
                }
                else
                {
                    DoubleArrayFunction f = new DoubleArrayFunction(t);
                    functions[f] = new IMeasurement[] { arg, val };
                    o = f;
                }
                d[key] = o;
            }
            series = m.ToArray();
            Type type = consumer.GetType();
            System.Reflection.MethodInfo mi = type.GetMethod("Prepare", new Type[0]);
            if (mi != null)
            {
                mi.Invoke(consumer, new object[0]);
            }
            return d;
        }


        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="start">Start time</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="argument">Argument</param>
        /// <param name="values">Values</param>
        /// <param name="series">Series</param>
        /// <param name="functions">Functions</param>
        /// <returns>Result of simulation</returns>
        public static Dictionary<string, object> PerformFixedTT(this IDataConsumer consumer, 
            double start, double step, int count, 
            string argument, string[] values,
             out ParametrizedSeries[] series,
            out Dictionary<DoubleArrayFunction, IMeasurement[]> functions)
        {
            try
            {
                series = null;
                functions = null;
                Dictionary<string, object> dic = consumer.CreateMeasurements(argument, values, out series, out functions);
                if (dic == null)
                {
                    return null;
                }
   /* !!!!            PerformFixed(consumer, start, step, count, argument, 
                    values, series, functions, StaticExtensionDataPerformerInterfaces.Calculation);
       */         return dic;
            }

            catch (Exception ex)
            {
                ex.HandleException(10);
                consumer.Throw(ex);
            }
            series = null;
            functions = null;
            return null;
        }

        /// <summary>
        /// Performs operation with fixed step
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="start">Start time</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="argument">Argument</param>
        /// <param name="values">Values</param>
        /// <returns>Dictionary of performed result</returns>
    /*    public static Dictionary<string, object> PerformFixed(this IDataConsumer consumer, double start, double step, int count,
            string argument, string[] values)
        {
            ParametrizedSeries[] series = null;
            Dictionary<DoubleArrayFunction, IMeasurement[]> functions = null;
            return consumer.PerformFixed(start, step, count, argument, values, out series, out functions);
        }*/


        /// <summary>
        /// Gets series
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="argument">Argument</param>
        /// <param name="values">Values</param>
        /// <returns>Dictionary of series</returns>
        public static Dictionary<string, Portable.Basic.Series> GetSeries(this IDataConsumer consumer, double start, double step, int count,
             string argument, string[] values)
        {
            Dictionary<string, Portable.Basic.Series> dic = new Dictionary<string, Portable.Basic.Series>();
         /*  !!! Dictionary<string, object> d = consumer.PerformFixed(start, step, count, argument, values);
            foreach (string key in d.Keys)
            {
                ParametrizedSeries s = d[key] as ParametrizedSeries;
                Portable.Basic.Series ser = new Portable.Basic.Series();
                ser.CopyFrom(s);
                dic[key] = ser;
            }*/
            return dic;
        }


      /*  !!! private static void PerformFixedT(this IDataConsumer consumer, double start, double step, int count, string argument, string[] values,
       ParametrizedSeries[] series,
      Dictionary<DoubleArrayFunction, IMeasurement[]> functions, string reason)
        {
            consumer.PerformFixed(start, step, count, 
                StaticExtensionDataPerformerPortable.Factory.TimeProvider,
              Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor,
             reason, 0, () =>
             {
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
        }*/

 
        #region Binder Class

        class Binder : SerializationBinder
        {
   
            internal Binder()
            {
                this.Add();
            }
            public override Type BindToType(string assemblyName, string typeName)
            {
                if (assemblyName.Contains("DataPerformer,"))
                {
                    string a = typeof(Binder).Assembly.FullName;
                    return Type.GetType(String.Format("{0}, {1}",
                        typeName, a));
                }

                return null;
            }
        }

        #endregion
    }
}