using System;
using System.Collections.Generic;
using NamedTree;

namespace Event.Interfaces
{
    /// <summary>
    /// Event handler
    /// </summary>
    public interface IEventHandler : IChildren<IEvent>
    {
    }
}
