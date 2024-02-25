using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Creator of operation separators
    /// </summary>
    public interface IOperationSeparatorCreator
    {
        /// <summary>
        /// Separators
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <returns>operation separators</returns>
        string[] this[ObjectFormulaTree tree]
        {
            get;
        }
    }
}
