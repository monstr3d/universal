using System;

namespace Event.Interfaces
{
    /// <summary>
    /// Proxy of event
    /// </summary>
    public interface IEventProxy
    {
        Action Proxy { get; set; }

        void CreateProxy();

        event Action<Action> OnCreate;
    }
}
