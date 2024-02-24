using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Interfaces
{
    /// <summary>
    /// IEvent
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Event
        /// </summary>
        event Action Event;
    }
}
