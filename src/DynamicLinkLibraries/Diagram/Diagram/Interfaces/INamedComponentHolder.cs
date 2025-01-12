using Diagram.UI.Labels;

namespace Diagram.Interfaces
{
    /// <summary>
    /// Holder of named component
    /// </summary>
    public interface INamedComponentHolder
    {
        /// <summary>
        /// The component
        /// </summary>
        INamedComponent NamedComponent { get; set; }
    }
}
