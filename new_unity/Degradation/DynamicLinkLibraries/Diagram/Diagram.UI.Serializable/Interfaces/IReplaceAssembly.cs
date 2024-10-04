using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Replaces assembly
    /// </summary>
    public interface IReplaceAssembly
    {
        /// <summary>
        /// Replaces assembly
        /// </summary>
        /// <param name="assembly">Assembly for replace</param>
        /// <returns>Replaced assembly</returns>
        Assembly Replace(Assembly assembly);
    }
}
