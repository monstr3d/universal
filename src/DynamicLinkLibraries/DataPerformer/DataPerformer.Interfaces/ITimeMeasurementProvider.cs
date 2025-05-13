namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Provider of time
    /// </summary>
    public interface ITimeMeasurementProvider
    {
        /// <summary>
        /// Time measurement
        /// </summary>
        IMeasurement TimeMeasurement
        {
            get;
        }

        /// <summary>
        /// Time
        /// </summary>
        double Time
        {
            get;
            set;
        }

        /// <summary>
        /// Step
        /// </summary>
        double Step
        {
            get;
            set;
        }
    }
}
