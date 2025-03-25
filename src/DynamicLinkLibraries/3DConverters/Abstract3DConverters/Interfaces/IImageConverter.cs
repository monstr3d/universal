namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Converter of image
    /// </summary>
    public interface IImageConverter
    {
        /// <summary>
        /// Converts image
        /// </summary>
        /// <param name="filename">Name of file</param>
        /// <returns>Conversion result</returns>
        Tuple<string, byte[]> Convert(string filename);
    }
}
