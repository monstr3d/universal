namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Consumer of time
    /// </summary>
    public interface ITimeMeasurementConsumer
    {
        /// <summary>
        /// Time measure
        /// </summary>
        IMeasurement Time
        {
            get;
            set;
        }
    }
}
