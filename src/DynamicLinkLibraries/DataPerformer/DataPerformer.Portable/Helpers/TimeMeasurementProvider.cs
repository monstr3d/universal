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

        private object obj;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TimeMeasurementProvider(object obj)
        {
            timeMeasurement = new TimeMeasurement(GetTime);
            this.obj = obj;
        }

        #endregion

        #region ITimeMeasurementProvider Members

        IMeasurement ITimeMeasurementProvider.TimeMeasurement
        {
            get => timeMeasurement;
        }

        double ITimeMeasurementProvider.Time
        {
            get => time;
            set => time = value;
        }

        double ITimeMeasurementProvider.Step
        {
            get => step;
            set => step = value;
        }

        #endregion

        object GetTime()
        {
            return time;
        }
    }
}