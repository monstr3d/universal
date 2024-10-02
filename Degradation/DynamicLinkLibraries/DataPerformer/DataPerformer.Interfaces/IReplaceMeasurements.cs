namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Replacement of measurements
    /// </summary>
    public interface IReplaceMeasurements
    {
        /// <summary>
        /// Replaces measutements
        /// </summary>
        /// <param name="oldMeasurements">Old measurements</param>
        /// <param name="oldMeasure">Old measure</param>
        /// <param name="newMeasurements">New measurements</param>
        /// <param name="newMeasure">New measure</param>
        void Replace(IMeasurements oldMeasurements, IMeasurement oldMeasure, IMeasurements newMeasurements, IMeasurement newMeasure);
    }
}
