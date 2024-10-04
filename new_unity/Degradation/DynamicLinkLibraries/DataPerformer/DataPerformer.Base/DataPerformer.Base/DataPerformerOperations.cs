using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using DataPerformer;
using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace DataPerformer
{
    /// <summary>
    /// This class performs most common operations
    /// </summary>
    public class DataPerformerOperations
    {
        /// <summary>
        /// Data consumer
        /// </summary>
        protected IDataConsumer consumer;

        /// <summary>
        /// List of measurements
        /// </summary>
        protected List<string> measurements = new List<string>();

        /// <summary>
        /// List of alias names
        /// </summary>
        protected List<string> aliasNames = new List<string>();

        /// <summary>
        /// List of aliases
        /// </summary>
        protected List<object[]> aliases = new List<object[]>();


        /// <summary>
        /// List of measures
        /// </summary>
        protected List<IMeasurement> measures = new List<IMeasurement>();



        #region Specific Members

        /// <summary>
        /// Trasformation
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        public void Transform(object[] input, object[] output)
        {
            for (int i = 0; i < input.Length; i++)
            {
                object[] al = aliases[i];
                IAlias a = al[0] as IAlias;
                string s = al[1] as string;
                a[s] = input[i];
            }
            consumer.ResetAll();
            consumer.UpdateChildrenData();
            for (int i = 0; i < output.Length; i++)
            {
                IMeasurement m = measures[i];
                output[i] = m.Parameter();
            }
        }


        /// <summary>
        /// Sets data to consumer
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <param name="measurements">Names of measurements</param>
        /// <param name="aliasNames">Names of aliases</param>
        public void Set(IDataConsumer consumer, List<string> measurements, List<string> aliasNames)
        {
            aliases.Clear();
            measures.Clear();
            this.measurements = measurements;
            this.aliasNames = aliasNames;
            this.consumer = consumer;
            Set();
        }


        /// <summary>
        /// Sets measures to consumer
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <param name="measures">Names of measures</param>
        /// <param name="measuresData">Measures</param>
        public static void SetMeasurements(IDataConsumer consumer, List<string> measures, List<IMeasurement> measuresData)
        {
            measuresData.Clear();
            IAssociatedObject ac = consumer as IAssociatedObject;
            foreach (string ms in measures)
            {
                for (int i = 0; i < consumer.Count; i++)
                {
                    IMeasurements m = consumer[i];
                    IAssociatedObject ao = m as IAssociatedObject;
                    string on = ac.GetRelativeName(ao) + ".";

                    for (int j = 0; j < m.Count; j++)
                    {
                        IMeasurement mea = m[j];
                        string s = on + mea.Name;
                        if (s.Equals(ms))
                        {
                            measuresData.Add(mea);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets aliases to consumer
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <param name="aliasNames">Names of aliases</param>
        /// <param name="aliases">Aliases</param>
        public static void SetAliases(IDataConsumer consumer, List<string> aliasNames, List<object[]> aliases)
        {
            List<string> al = new List<string>();
            consumer.GetAliases(al);
            for (int i = 0; i < aliasNames.Count; i++)
            {
                string an = aliasNames[i];
                object[] o = consumer.FindAlias(an);
                aliases.Add(o);
            }
        }



        /// <summary>
        /// Sets all own settings
        /// </summary>
        public void Set()
        {
            SetMeasurements(consumer, measurements, measures);
            SetAliases(consumer, aliasNames, aliases);
        }

        #endregion
    }
}