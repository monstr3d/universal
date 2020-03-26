using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataPerformer.Interfaces;

namespace DataPerformer.Portable.Measurements
{
    /// <summary>
    /// Wrapper of measure
    /// </summary>
    public class MeasurementWrapper
    {
        #region Fields

        IMeasurement measure;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="measure">Measure</param>
        public MeasurementWrapper(IMeasurement measure)
        {
            this.measure = measure;
        }

        #endregion

        #region Members

        internal object GetValue()
        {
            return measure.Parameter();
        }

        #endregion
    }
}

