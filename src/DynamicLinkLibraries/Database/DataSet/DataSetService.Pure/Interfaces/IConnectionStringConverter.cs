namespace DataSetService.Pure.Interfaces
{
    /// <summary>
    /// Converter of connection string
    /// </summary>
    public interface IConnectionStringConverter
    {
        /// <summary>
        /// Converts connection string
        /// </summary>
        /// <param name="value">Old value</param>
        /// <returns>New value</returns>
        string Convert(string value);
    }
}
