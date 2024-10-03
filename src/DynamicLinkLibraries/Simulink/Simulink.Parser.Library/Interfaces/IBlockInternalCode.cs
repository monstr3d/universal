using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simulink.Parser.Library.DiagramElements;

namespace Simulink.Parser.Library.Interfaces
{
    /// <summary>
    /// Creates block code
    /// </summary>
    public interface IBlockInternalCode
    {
        /// <summary>
        /// Creates code
        /// </summary>
        /// <param name="block">Block</param>
        /// <param name="number">Block number</param>
        /// <returns>Code</returns>
        IList<string> Create(Block block, int number);
    }
}
