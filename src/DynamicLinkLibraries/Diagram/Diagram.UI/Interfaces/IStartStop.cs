using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Start stop interface
    /// </summary>
    public interface IStartStop
    {
        /// <summary>
        /// Performs action
        /// </summary>
        /// <param name="type">Action type</param>
        /// <param name="actionType">Type of action</param>
        void Action(object type, ActionType actionType);
    }

    /// <summary>
    /// Type of action
    /// </summary>
    public enum ActionType
    {
        Start,  // Start
        Stop,   // Stop   
        Pause,  // Pause
        Resume  // Resume
    }
}
