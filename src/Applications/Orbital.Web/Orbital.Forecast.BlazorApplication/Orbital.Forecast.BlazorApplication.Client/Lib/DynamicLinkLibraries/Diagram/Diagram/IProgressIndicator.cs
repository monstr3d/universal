using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI
{
    /// <summary>
    /// The progress indicator
    /// </summary>
    public interface IProgressIndicator
    {
        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="step">Step count</param>
        void Init(int step);

        /// <summary>
        /// Performs step
        /// </summary>
        void Step();

        /// <summary>
        /// Stops itself
        /// </summary>
        void Stop();
    }
}
