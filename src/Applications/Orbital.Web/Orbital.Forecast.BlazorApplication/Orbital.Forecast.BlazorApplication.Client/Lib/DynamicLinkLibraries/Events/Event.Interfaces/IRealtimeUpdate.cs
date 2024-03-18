using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{

    /// <summary>
    /// Realtime update
    /// </summary>
    public interface IRealtimeUpdate
    {
        /// <summary>
        /// Updates itself
        /// </summary>
        Action Update
        {
            get;
        }

        /// <summary>
        /// On unpdate action
        /// </summary>
        event Action OnUpdate;

    }
}
