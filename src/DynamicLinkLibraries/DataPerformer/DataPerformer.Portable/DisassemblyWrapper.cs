using BaseTypes.Interfaces;
using DataPerformer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Wrapper of Dissassembly
    /// </summary>
    public class DisassemblyWrapper
    {
        #region Fields

        Dictionary<string, IMeasurement> dictionary = new Dictionary<string, IMeasurement>();

        List<MeasurementsDisasseblyWrapper> l = new List<MeasurementsDisasseblyWrapper>();


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="names">Names</param>
        /// <param name="consumer">Consumer</param>
        /// <param name="disassembly">Disassembly</param>
        public DisassemblyWrapper(IEnumerable<string> names, IDataConsumer consumer, 
            IDisassemblyObject disassembly)
        {
            Dictionary<IMeasurement, MeasurementsDisasseblyWrapper> d = 
                consumer.CreateDisassemblyMeasurements(disassembly);
            Dictionary<string, IMeasurement> measurements = consumer.GetAllMeasurementsByName();
             foreach (string key in measurements.Keys)
            {
                if (names.Contains(key))
                {
                    IMeasurement measurement = measurements[key];
                    if (d.ContainsKey(measurement))
                    {
                        string s = key + ".";
                        MeasurementsDisasseblyWrapper wr = d[measurement];
                        l.Add(wr);
                        IMeasurement[] mea = wr.Measurements;
                        foreach (IMeasurement mm in mea)
                        {
                            dictionary[s + mm.Name] = mm;
                        }
                        continue;
                    }
                    dictionary[key] = measurement;
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Dictionary
        /// </summary>
        public Dictionary<string, object> Dictionary
        {
            get
            {
                foreach (MeasurementsDisasseblyWrapper wrapper in l)
                {
                    wrapper.Update();
                }
                Dictionary<string, object> d = new Dictionary<string, object>();
                foreach (string key in dictionary.Keys)
                {
                    d[key] = dictionary[key].Parameter();
                }
                return d;
            }
        }

        #endregion

    }
}
