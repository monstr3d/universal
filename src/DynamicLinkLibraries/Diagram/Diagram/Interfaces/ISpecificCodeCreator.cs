
using Diagram.UI.Interfaces;

namespace Diagram.Interfaces
{
    /// <summary>
    /// Specific code creator
    /// </summary>
    public interface ISpecificCodeCreator
    {
        /// <summary>
        /// Allows code
        /// </summary>
        /// <param name="allow">the code</param>
        /// <returns>Codereator</returns>
        bool Allow(IAllowCodeCreation allow);
    }
}
