namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Factory of mesh creators
    /// </summary>
    public interface IMeshCreatorFactory
    {
        /// <summary>
        /// Creates a creator from the extension and bytes
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <param name="directory">The directory</param>
        /// <param name="objects">The objects</param>
        /// <returns>The creator</returns>
        IMeshCreator this[string extension, string directory, params object[] objects] { get;  }

        /// <summary>
        /// Extensions
        /// </summary>
        List<string> Extensions { get; }
    }
}
