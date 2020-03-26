using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{

    /// <summary>
    /// Start and stop action of real time
    /// </summary>
    public interface IRealTimeStartStop
    {
        /// <summary>
        /// Statrs realtime
        /// </summary>
        void Start();

        /// <summary>
        /// Stops runtime
        /// </summary>
        void Stop();


        /// <summary>
        /// On start action
        /// </summary>
        event Action OnStart;

        /// <summary>
        /// On stop action
        /// </summary>
        event Action OnStop;

    }
}
