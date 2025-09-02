
namespace Diagram.UI.Interfaces
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
