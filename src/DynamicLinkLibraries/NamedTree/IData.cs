namespace NamedTree
{
    /// <summary>
    /// Data
    /// </summary>
    public interface IData
    {
        /// <summary>
        /// Data
        /// </summary>
        byte[] Data { get; set; }
    }

    /// <summary>
    /// Async data
    /// </summary>
    public interface IDataAsync
    {
        Task<byte[]> GetDataAsync(CancellationToken cancellationToken);
    }
}
