using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Diagram.UI.Interfaces;

using TestCategory.Interfaces;


using DataPerformer.Interfaces;
using DataPerformer;


namespace SoundService.Test
{
    /// <summary>
    /// Test of sound
    /// </summary>
    [Serializable()]
    class SoundTest : ISerializable, ITest
    {

        #region Fields

        string name;

        double start;

        double step;

        int stepCount;

        /// <summary>
        /// Dictionary of sounds
        /// Keys are instants of sounds
        /// Values are sound filenames
        /// </summary>
        Dictionary<double, string> soundResults = new Dictionary<double, string>();

 
        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">Collection of components</param>
        /// <param name="name">Sound component name</param>
        /// <param name="start">Start time</param>
        /// <param name="step">Step</param>
        /// <param name="stepCount">Count of steps</param>
        internal SoundTest(IComponentCollection collection, 
            string name, double start, double step, int stepCount)
        {
            this.name = name;
            this.start = start;
            this.step = step;
            this.stepCount = stepCount;
            soundResults = GetSounds(collection);
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private SoundTest(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("Name");
            start = info.GetDouble("Start");
            step = info.GetDouble("Step");
            stepCount = info.GetInt32("StepCount");
            soundResults = info.GetValue("Sounds", typeof(Dictionary<double, string>)) as Dictionary<double, string>;
        }



        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("Start", start);
            info.AddValue("Step", step);
            info.AddValue("StepCount", stepCount);

            // Dictionary of sounds saving
            info.AddValue("Sounds", soundResults, typeof(Dictionary<double, string>));
        }

        #endregion

        #region ITest Members

        /// <summary>
        /// Testing
        /// </summary>
        /// <param name="collection">Collection of objects</param>
        /// <returns>Tesing result</returns>
        object ITest.this[IComponentCollection collection]
        {
            get 
            {
                List<string> l = new List<string>();
                Dictionary<double, string> d = GetSounds(collection); // Calculates dictionary of sounds
                
                
                // Comparation of saved dictionary with calculated one
                if (d.Count != soundResults.Count)
                {
                    l.Add("Different number of sounds");
                }
                foreach (double key in d.Keys)
                {
                    if (!soundResults.ContainsKey(key))
                    {
                        l.Add("Illegal time: " + key);
                    }
                    else
                    {
                        string s = d[key];
                        if (!s.Equals(soundResults[key]))
                        {
                            l.Add("Illegal sound '" + s + "' Time = " + key);
                        }

                    }
                }
                 if (l.Count == 0)
                {
                    return null;
                }
                // Returns list of errors
                return l;
            }
       }

        #endregion

        #region Members

        /// <summary>
        /// Name
        /// </summary>
        internal string Name
        {
            get
            {
                return name;
            }
        }


        /// <summary>
        /// Calculates dictionary of sounds
        /// </summary>
        /// <param name="collection">Collection of objects</param>
        /// <returns>Dictionary of sounds</returns>
        Dictionary<double, string> GetSounds(IComponentCollection collection)
        {
            IDesktop desktop = collection as IDesktop;
            Dictionary<double, string> d = new Dictionary<double, string>();
            SoundCollection coll = desktop.GetObject(name) as SoundCollection;
            IDataConsumer dc = coll;
            ITimeMeasurementProvider p = DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory.TimeProvider;
            Action<string> act = (string s) => { d[p.Time] = s; };
            coll.PlaySound += act;
            /* !!! REPLACE AFTER     dc.PerformFixed(start, step, stepCount, p,
                    DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor, "Animation",  0, () => { });
                 coll.PlaySound -= act;
                 return d;
            */
            return null;
        }

        #endregion 
    
    }
}
