
namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Object which can be saved to stream
    /// </summary>
    public interface ISaveToStream
    {
        /// <summary>
        /// Saves object to stream
        /// </summary>
        /// <param name="obj">The object</param>
        /// <param name="stream">The stream</param>
        void Save(object obj, Stream stream);
    }
}
