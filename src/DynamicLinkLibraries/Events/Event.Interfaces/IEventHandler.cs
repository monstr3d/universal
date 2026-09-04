
using NamedTree.Interfaces;

namespace Event.Interfaces
{
    /// <summary>
    /// Event handler
    /// </summary>
    public interface IEventHandler : IChildren<IEvent>
    {
    }
}
