namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// The factory of mesh converters
    /// </summary>
    public interface IMeshConverterFactory
    {
        /// <summary>
        /// Gets a mesh converter
        /// </summary>
        /// <param name="extension">Thr file extension</param>
        /// <param name="objects">The comment</param>
        /// <returns>The converter</returns>
        IMeshConverter this[string extension, params object[] objects] { get; }
    }
}
