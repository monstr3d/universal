using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Simlification of formula tree
    /// </summary>
    public interface IFormulaSimplification
    {
        /// <summary>
        /// Simplfies tree
        /// </summary>
        /// <param name="tree">Simplfied tree</param>
        /// <returns>Simplfication result</returns>
        ObjectFormulaTree Simplify(ObjectFormulaTree tree);
    }
}
