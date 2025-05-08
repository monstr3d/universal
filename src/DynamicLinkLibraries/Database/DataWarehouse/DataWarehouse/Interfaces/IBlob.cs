namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Blob consumer
    /// </summary>
    public interface IBlob
    {
        /// <summary>
        /// Bytes
        /// </summary>
        byte[] Bytes
        {
            get;
            set;
        }

        /// <summary>
        /// Extension
        /// </summary>
        string Extension
        {
            get;
            set;
        }
    }
}
