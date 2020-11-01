using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI
{
    /// <summary>
    /// Process
    /// </summary>
    public interface IProcess
    {
        /// <summary>
        /// Starts process
        /// </summary>
        void Start();

        /// <summary>
        /// Pauses process
        /// </summary>
        void Pause();

        /// <summary>
        /// Resumes process
        /// </summary>
        void Resume();

        /// <summary>
        /// Terminates process
        /// </summary>
        void Terminate();

        /// <summary>
        /// Shows status of process
        /// </summary>
        /// <param name="status">Status</param>
        void ShowStatus(double status);

        /// <summary>
        /// Time of start
        /// </summary>
        double StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Step
        /// </summary>
        double Step
        {
            get;
            set;
        }

        /// <summary>
        /// Number of steps
        /// </summary>
        int Count
        {
            get;
            set;
        }
         
    }
}
