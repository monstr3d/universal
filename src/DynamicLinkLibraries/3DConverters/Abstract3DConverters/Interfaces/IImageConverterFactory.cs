namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Factory of image converters
    /// </summary>
    public interface IImageConverterFactory
    {
        /// <summary>
        /// Gets converter
        /// </summary>
        /// <param name="extension">File extension</param>
        /// <returns>The converter</returns>
        IImageConverter this[string extension] { get; }
    }
}
