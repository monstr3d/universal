using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;
using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Wrapper of measurements and disaassembly
    /// </summary>
    public class MeasurementsDisassemblyWrapper
    {

        #region Fields

        IDisassemblyObject disassembly;

        IMeasurement[] measurements;

        IMeasurement measure;

        object[][] o = new object[1][];

        #endregion

        #region Ctor

        public MeasurementsDisassemblyWrapper(IDisassemblyObject disassembly, IMeasurement measure)
        {
            this.disassembly = disassembly;
            this.measure = measure;
            List<Tuple<string, object>> types = disassembly.Types;
            o[0] = new object[types.Count];
            List<IMeasurement> l = new List<IMeasurement>();
            string n = measure.Name + "_";
            for (int i = 0; i < types.Count; i++)
            {
                Tuple<string, object> type = types[i];
                o[0][i] = type.Item2;
                l.Add(new ArrayMeasurement(o, type.Item2, i, n + type.Item1, null));
            }
            measurements = l.ToArray();
        }

        #endregion

        #region Public

        /// <summary>
        /// Updates itself
        /// </summary>
        public void Update()
        {
            o[0] = disassembly.Disassembly(measure.Parameter());
        }

        /// <summary>
        /// Measurements
        /// </summary>
        public IMeasurement[] Measurements
        {
            get
            {
                return measurements;
            }
        }


        #endregion

    }
}
