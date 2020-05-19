using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulink.Parser.Library.Interfaces
{
    /// <summary>
    /// Creator of code for simulink
    /// </summary>
    public interface ICodeCreator
    {
        /// <summary>
        /// Creates code from simulink system
        /// </summary>
        /// <param name="system">The system</param>
        /// <returns>Code</returns>
        IList<string> CreateCode(SimulinkSubsystem system);
    }
}
