using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Creator of tree from two trees
    /// </summary>
    public interface IChildTreeCreator
    {
        /// <summary>
        /// Creates the tree from children
        /// </summary>
        /// <param name="children">The children</param>
        /// <returns>Created tree</returns>
        ObjectFormulaTree this[ObjectFormulaTree[] children]
        { get; }
    }
}
