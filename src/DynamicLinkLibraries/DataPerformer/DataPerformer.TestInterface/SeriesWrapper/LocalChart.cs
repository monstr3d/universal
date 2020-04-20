﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using TestCategory.Interfaces;

using Diagram.UI.Interfaces;
using Diagram.UI;

using DataPerformer.Interfaces;


namespace DataPerformer.TestInterface.SeriesWrapper
{
    /// <summary>
    /// Test of time dependent function
    /// </summary>
    [Serializable()]
    class LocalChart : ITest, ISerializable
    {

        #region Fields

        /// <summary>
        /// Saved series
        /// </summary>
        Dictionary<string, LocalSeries> series = new Dictionary<string, LocalSeries>();

        string name;

        string argument;

        double start;

        double step;

        int stepCount;

        string[] values = null;



        #endregion

        #region Ctor

        internal LocalChart(string name, double start, double step, int stepCount, string argument, string[] values)
        {
            this.name = name;
            this.start = start;
            this.step = step;
            this.stepCount = stepCount;
            this.argument = argument;
            this.values = values;
        }


        /// <summary>
        /// Loads saved time dependent functions
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private LocalChart(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("Name");
            series = info.GetValue("Series", typeof(Dictionary<string, LocalSeries>)) as Dictionary<string, LocalSeries>;
            argument = info.GetString("Argument");
            start = info.GetDouble("Start");
            step = info.GetDouble("Step");
            stepCount = info.GetInt32("StepCount");
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// Saves time dependent functions
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("Series", series, typeof(Dictionary<string, LocalSeries>));
            info.AddValue("Argument", argument);
            info.AddValue("Start", start);
            info.AddValue("Step", step);
            info.AddValue("StepCount", stepCount);
        }

        #endregion

        #region ITest Members


        /// <summary>
        /// Tests collection of components
        /// </summary>
        /// <param name="collection">Collection of components</param>
        /// <returns>Test result</returns>
        object ITest.this[IComponentCollection collection]
        {
            get
            {
                IDesktop desktop = collection as IDesktop;
                IDataConsumer dataconsumer = desktop[name] as IDataConsumer;
                Dictionary<string, DataPerformer.Basic.Series> d = GetSeries(collection); // Calculation of time dependent function
                List<string> l = new List<string>();
                foreach (string s in d.Keys)
                {
                    if (!series[s].Compare(d[s])) // Comparation of test results
                    {
                        l.Add("Different series values. Object - " + name + ". Series - " + s + ".");
                    }
                }
                if (l.Count == 0)
                {
                    return null;
                }
                return l;
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Crates tests
        /// </summary>
        /// <param name="collection">Collection of components</param>
        internal void Create(IComponentCollection collection)
        {
            Dictionary<string, DataPerformer.Basic.Series> d = GetSeries(collection);
            series.Clear();
            foreach (string key in d.Keys)
            {
                series[key] = new LocalSeries(d[key]);
            }
        }

        Dictionary<string, DataPerformer.Basic.Series> GetSeries(IComponentCollection collection)
        {
            IDataConsumer dataConsumer = collection.GetObject<IDataConsumer>(name);
            string[] ss = (values == null) ? series.Keys.ToArray() : values;
            return dataConsumer.GetSeries(start, step, stepCount, 
                argument, ss);
        }

        internal string Name
        {
            get
            {
                return name;
            }
        }

        #endregion
    }
}