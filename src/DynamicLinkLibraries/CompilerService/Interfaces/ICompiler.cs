using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompilerService.Interfaces
{
    /// <summary>
    /// Compilation from code
    /// </summary>
    public interface ICompiler
    {
        /// <summary>
        /// Creates assembly from code
        /// </summary>
        /// <param name="code">The code</param>
        /// <returns>The assembly</returns>
        Assembly this[string code]
        { get; }
    }
}
