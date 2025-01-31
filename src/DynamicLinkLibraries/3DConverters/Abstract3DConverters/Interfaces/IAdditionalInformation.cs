namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Additional information
    /// </summary>
    public interface IAdditionalInformation
    {
        /// <summary>
        /// Dictionary of additional information
        /// </summary>
        Dictionary<string, byte[]> Information { get; }
    }
}
