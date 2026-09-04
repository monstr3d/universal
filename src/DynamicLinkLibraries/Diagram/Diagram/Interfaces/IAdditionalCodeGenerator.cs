using Diagram.UI.Interfaces;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Generator of additional code
    /// </summary>
    public interface IAdditionalCodeGenerator
    {
        /// <summary>
        /// Code generation
        /// </summary>
        /// <param name="componentCollection">Components</param>
        /// <param name="name">Name</param>
        /// <param name="directory">Directory of generation</param>
        void Generate(IComponentCollection componentCollection, string name, string directory);
    }
}
