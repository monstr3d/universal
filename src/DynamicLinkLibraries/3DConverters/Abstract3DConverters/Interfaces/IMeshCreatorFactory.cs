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
        /// <param name="bytes">The bytes</param>
        /// <returns>The creator</returns>
        IMeshCreator this[string extension, byte[] bytes] { get;  }
    }
}
