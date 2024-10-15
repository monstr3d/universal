namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Data provider
    /// </summary>
    public interface IMeasurements
    {
        /// <summary>
        /// The count of data units
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Gets number - th unit of data
        /// </summary>
        IMeasurement this[int number]
        {
            get;
        }

        /// <summary>
        /// Updates data
        /// </summary>
        void UpdateMeasurements();


        /// <summary>
        /// Shows, wreather the object is updated
        /// </summary>
        bool IsUpdated
        {
            get;
            set;
        }
    }
}
