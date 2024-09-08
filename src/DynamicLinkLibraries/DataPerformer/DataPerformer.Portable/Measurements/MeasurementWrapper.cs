using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataPerformer.Interfaces;

namespace DataPerformer.Portable.Measurements
{
    /// <summary>
    /// Wrapper of measurement
    /// </summary>
    public class MeasurementWrapper
    {
        #region Fields

        IMeasurement measurement;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="measurement">Measure</param>
        public MeasurementWrapper(IMeasurement measurement)
        {
            this.measurement = measurement;
        }

        #endregion

        #region Members

        internal object GetValue()
        {
            return measurement.Parameter();
        }

        #endregion
    }
}

