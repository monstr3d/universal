using System;

namespace DataPerformer.Portable.Measurements
{
    /// <summary>
    /// Time measurement
    /// </summary>
    public class TimeMeasurement : MeasurementDerivation
    {

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameter">Parameter</param>
        public TimeMeasurement(Func<object> parameter) :
            base(parameter, new ConstantMeasurement(1), "Time", null)
        {

        }

        #endregion

        #region Public Members

     
        /// <summary>
        /// Time parameter
        /// </summary>
        public Func<object> TimeParameter
        {
            get
            {
                return parameter;
            }
            set
            {
                parameter = value;
            }
        }

        #endregion
    }
}
