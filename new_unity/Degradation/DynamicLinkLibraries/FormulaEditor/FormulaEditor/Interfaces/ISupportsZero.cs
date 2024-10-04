using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// The zero support
    /// </summary>
    public interface ISupportsZero
    {
        /// <summary>
        /// The "is zero" sign
        /// </summary>
        /// <param name="tree">Thee</param>
        /// <returns>The sign</returns>
        bool IsZero(ObjectFormulaTree tree);
    }
}
