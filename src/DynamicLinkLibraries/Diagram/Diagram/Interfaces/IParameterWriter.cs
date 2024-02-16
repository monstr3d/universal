using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI
{
    /// <summary>
    /// Writer of string
    /// </summary>
    public interface IParameterWriter
    {
        /// <summary>
        /// Writes parameters
        /// </summary>
        /// <param name="parameters">Dictionary of parameters</param>
        void Write(Dictionary<string, string> parameters);

         /// <summary>
        /// Flushes itself
        /// </summary>
        void Flush();
    }
}
