using DataWarehouse.Classes;

using System.Threading;
using System.Threading.Tasks;

namespace DataWarehouse.Interfaces.Async
{
    public interface IDatabaseInterfaceAsync
    {
        Task<IDirectoryAsync[]> GetRoots(string[] extensions, CancellationToken cancellationToken);


        /// <summary>
        /// SyncModde
        /// </summary>
        SyncMode SyncMode { get; }


    }
}
