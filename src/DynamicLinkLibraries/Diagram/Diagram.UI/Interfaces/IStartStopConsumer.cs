using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Consumer of start stop interface
    /// </summary>
    public interface IStartStopConsumer
    {
        /// <summary>
        /// Start stop
        /// </summary>
        IStartStop StartStop
        {
            get;
            set;
        }
    }
}
