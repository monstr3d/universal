using System.Collections.Generic;

namespace Scada.Interfaces
{
    /// <summary>
    /// Event output collection
    /// </summary>
    public interface IEventOutput
    {
        /// <summary>
        /// Dictionary of event output
        /// </summary>
        Dictionary<string, List<string>> EventOutput
        {
            get;
        }
    }
}
