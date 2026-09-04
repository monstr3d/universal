using System.Threading;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Initializastion task
    /// </summary>
    public interface IInitializeTask
    {
        Task InitializeAsync(CancellationToken cancellationToken);
    }
}
