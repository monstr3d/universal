using System;

using BaseTypes;
using BaseTypes.Attributes;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

using Event.Interfaces;

using ErrorHandler;


namespace DataPerformer.Portable.Runtime
{
    /// <summary>
    /// Real time provider
    /// </summary>
    public abstract class RealtimeProvider : ITimeMeasurementProvider, IRealtimeUpdate
    {

        #region Fields

        protected Func<double> time;

        DateTime dt;

        BaseTypes.Performer Performer
        {
            get;
        } = new();

        protected IMeasurement timeMeasurement = null;

        protected double currentTime;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="timeUnit">Time unit</param>
        /// <param name="isAbsolute">True in case of relative time</param>
        public RealtimeProvider(bool isAbsolute, TimeType timeUnit)
        {
            var f = Performer.Convert(timeUnit, DateTime, isAbsolute);
            time = () => f(DateTime.Now);
            currentTime = time();
            Func<object> mea = () => 
            {
               return currentTime;
            };
            if (timeMeasurement == null)
            {
                timeMeasurement = new TimeMeasurement(new Func<object>(mea));
            }
            else if (timeMeasurement is TimeMeasurement)
            {
                (timeMeasurement as TimeMeasurement).TimeParameter = mea;
            }
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
                throw new WriteProhibitedException();
            }

            remove
            {
                throw new WriteProhibitedException();
            }
        }

        #endregion

        #region ITimeMeasureProvider Members

        IMeasurement ITimeMeasurementProvider.TimeMeasurement
        {
            get => timeMeasurement;
        }

        double ITimeMeasurementProvider.Time
        {
            get => currentTime;
            set => currentTime = value;
         }

        double ITimeMeasurementProvider.Step
        {
            get
            {
                throw new OwnException("Step is not allowed");
            }
            set
            {
                throw new OwnException("Step is not allowed");
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
