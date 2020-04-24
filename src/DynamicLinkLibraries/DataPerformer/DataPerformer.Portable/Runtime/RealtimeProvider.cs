using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseTypes;
using BaseTypes.Attributes;

using DataPerformer;
using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;
using Event.Interfaces;

namespace DataPerformer.Runtime
{
    /// <summary>
    /// Real time provider
    /// </summary>
    public abstract class RealtimeProvider : ITimeMeasurementProvider, IRealtimeUpdate
    {

        #region Fields

        protected Func<double> time;

        DateTime dt;

        protected IMeasurement timeMeasurement;

        protected double currentTime;
        
        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isAbsolute">True in case of relative time</param>
        /// <param name="timeUnit">Time unit</param>
        public RealtimeProvider(bool isAbsolute, TimeType timeUnit)
        {
            if (timeUnit.Equals(TimeType.Day))
            {
                if (!isAbsolute)
                {
                    dt = DateTime;
                    time = () =>
                        {
                            return (DateTime.Now - dt).TotalDays;
                        };
                }
                else
                {
                    time = () => { return DateTime.Now.DateTimeToDay(); };
                }
            }
            else
            {
                double coeff = TimeType.Day.Coefficient<TimeType>(timeUnit);
                if (!isAbsolute)
                {
                    dt = DateTime.Now;
                    time = () =>
                    {
                        return coeff * (DateTime.Now - dt).TotalDays;
                    };
                }
                else
                {
                    time = () => { return coeff * DateTime.Now.DateTimeToDay(); };
                }
            }
            currentTime = time();
            Func<object> mea = () => 
            {
               return currentTime;
            };
            timeMeasurement = new TimeMeasurement(new Func<object>(mea));
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected RealtimeProvider()
        {

        }

        event Action IRealtimeUpdate.OnUpdate
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ITimeMeasureProvider Members

        IMeasurement ITimeMeasurementProvider.TimeMeasurement
        {
            get { return timeMeasurement; }
        }

        double ITimeMeasurementProvider.Time
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;
            }
        }

        double ITimeMeasurementProvider.Step
        {
            get
            {
                throw new Exception("Step is not allowed");
            }
            set
            {
                throw new Exception("Step is not allowed");
            }
        }

        #endregion


        #region IRealtimeUpdate Members


        Action IRealtimeUpdate.Update => Update;


        #endregion



        #region Public Members

        /// <summary>
        /// Current Date Time
        /// </summary>
        public abstract DateTime DateTime
        {
            get;
            set;
        }

       /// <summary>
        /// Updates time
        /// </summary>
        public void Update()
        {
            currentTime = time();
        }

        /// <summary>
        /// Creates Realtime provider
        /// <param name="timeUnit">Time unit</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="stepAction">Step Action</param>
        /// <param name="dataConsumer">Data Consumer</param>
        /// <param name="log">log</param>
        /// <param name="reason">Reason</param>
        /// <returns>The Realtime provider</returns>
        static public RealtimeProvider Create(bool isAbsolute, TimeType timeUnit, string reason)
        {
            if (reason == "Realtime")
            {
                return new RealtimeProviderRealtime(isAbsolute, timeUnit);
            }
            return new RealtimeProviderAnalysis(isAbsolute, timeUnit);
        }

        #endregion

    }
}
