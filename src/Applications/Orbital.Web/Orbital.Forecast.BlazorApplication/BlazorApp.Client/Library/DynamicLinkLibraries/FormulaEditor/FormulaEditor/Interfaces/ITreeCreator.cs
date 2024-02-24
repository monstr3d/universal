using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Creator of tree
    /// </summary>
    public interface ITreeCreator
    {
        /// <summary>
        /// Gets tree
        /// </summary>
        ObjectFormulaTree Tree
        {
            get;
        }
    }
}
