using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Cloneable
    /// </summary>
    public interface ICloneable
    {
        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns></returns>
        object Clone();
    }
}
