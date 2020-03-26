using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

namespace DataPerformer.Helpers
{
    /// <summary>
    /// Simplest provider of time measure
    /// </summary>
    public class TimeMeasureProvider : ITimeMeasureProvider
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
        public TimeMeasureProvider()
        {
            timeMeasurement = new TimeMeasurement(GetTime);
        }

        #endregion

        #region ITimeMeasureProvider Members

        IMeasurement ITimeMeasureProvider.TimeMeasurement
        {
            get
            {
                return timeMeasurement;
            }
        }

        double ITimeMeasureProvider.Time
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

        double ITimeMeasureProvider.Step
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