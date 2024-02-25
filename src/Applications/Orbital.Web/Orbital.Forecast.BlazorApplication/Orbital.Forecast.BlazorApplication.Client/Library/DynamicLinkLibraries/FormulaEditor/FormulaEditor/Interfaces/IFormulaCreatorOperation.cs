using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Operation that creates formula
    /// </summary>
    public interface IFormulaCreatorOperation
    {

        /// <summary>
        /// Creates formula
        /// </summary>
        /// <param name="tree">Operation tree</param>
        /// <param name="level">Formula level</param>
        /// <param name="sizes">Sizes of symbols</param>
        /// <returns>The formula</returns>
        MathFormula CreateFormula(ObjectFormulaTree tree, byte level, int[] sizes);

        /// <summary>
        /// Operation priority
        /// </summary>
        int OperationPriority
        {
            get;
        }
    }
}
