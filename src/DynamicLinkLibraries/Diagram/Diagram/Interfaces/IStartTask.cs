using System.Threading;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces
{
    public interface IStartTask
    {
        /// <summary>
        /// Starts itself
        /// </summary>
        /// <param name="cancellationToken">Token</param>
        /// <returns>The task</returns>
        Task StartAsync(CancellationToken cancellationToken);
    }
}
