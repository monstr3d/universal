using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Creator of formula from tree
    /// </summary>
    public class FormulaCreator
    {

        /// <summary>
        /// Creates formula
        /// </summary>
        /// <param name="tree">Operation tree</param>
        /// <param name="level">Formula level</param>
        /// <param name="sizes">Sizes of symbols</param>
        /// <returns>The formula</returns>
        public static MathFormula CreateFormula(ObjectFormulaTree tree, byte level, int[] sizes)
        {
            IFormulaCreatorOperation c = tree.Operation as IFormulaCreatorOperation;
            return c.CreateFormula(tree, level, sizes);
        }
    }
}
