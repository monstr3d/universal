namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Hoder of measurement
    /// </summary>
    public interface IMeasurementHolder
    {
        /// <summary>
        /// Measurement
        /// </summary>
        IMeasurement Measurement
        { get; }
    }
}
