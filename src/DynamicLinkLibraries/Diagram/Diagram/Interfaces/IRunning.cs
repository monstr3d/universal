using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.Interfaces
{
    /// <summary>
    /// Running object
    /// </summary>
    public interface IRunning
    {
        /// <summary>
        /// The "is running" sign
        /// </summary>
        bool IsRunning { get; set; }

        /// <summary>
        /// Running changed event
        /// </summary>
        event Action<IRunning, bool> Running;

    }
}
