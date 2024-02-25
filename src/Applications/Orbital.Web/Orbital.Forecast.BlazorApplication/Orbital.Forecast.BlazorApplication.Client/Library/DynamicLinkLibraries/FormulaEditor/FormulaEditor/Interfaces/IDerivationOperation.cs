using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Operation with derivation
    /// </summary>
    public interface IDerivationOperation
    {
        /// <summary>
        /// Calculates derivation
        /// </summary>
        /// <param name="tree">The tree for derivation calculation</param>
        /// <param name="variableName">Name of variable</param>
        /// <returns>The derivation tree</returns>
        ObjectFormulaTree Derivation(ObjectFormulaTree tree, string variableName);
    }
}
