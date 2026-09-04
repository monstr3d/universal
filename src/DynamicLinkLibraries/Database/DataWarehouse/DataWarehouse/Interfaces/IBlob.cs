using System.Threading;
using System.Threading.Tasks;

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
        }

        /// <summary>
        /// Sets bytes
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <param name="cancellationToken">token</param>
        /// <returns>Async tast</returns>
        Task SetBytesAsync(byte[] bytes, CancellationToken cancellationToken);

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
