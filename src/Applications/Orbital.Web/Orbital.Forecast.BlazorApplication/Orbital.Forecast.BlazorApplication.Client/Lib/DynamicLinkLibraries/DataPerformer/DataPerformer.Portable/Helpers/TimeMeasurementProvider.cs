using System;


using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

namespace DataPerformer.Portable.Helpers
{
    /// <summary>
    /// Simplest provider of time measurement
    /// </summary>
    public class TimeMeasurementProvider : ITimeMeasurementProvider
    {
        #region Fields

        double time;

        const double a = 0;

        double step;

        IMeasurement timeMeasurement;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TimeMeasurementProvider()
        {
            timeMeasurement = new TimeMeasurement(GetTime);
        }

        #endregion

        #region ITimeMeasurementProvider Members

        IMeasurement ITimeMeasurementProvider.TimeMeasurement
        {
            get
            {
                return timeMeasurement;
            }
        }

        double ITimeMeasurementProvider.Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        double ITimeMeasurementProvider.Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
            }
        }

        #endregion

        object GetTime()
        {
            return time;
        }
    }
}