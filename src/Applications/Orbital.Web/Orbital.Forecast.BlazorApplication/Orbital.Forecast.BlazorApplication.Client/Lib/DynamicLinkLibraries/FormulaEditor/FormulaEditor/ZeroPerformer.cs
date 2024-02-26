using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Performer of zero operations
    /// </summary>
    public static class ZeroPerformer
    {
        /// <summary>
        /// Checks whether tree is zero
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>True in case of zero and false otherwise</returns>
        static public bool IsZero(ObjectFormulaTree tree)
        {
            IObjectOperation op = tree.Operation;
            if (op is ISupportsZero)
            {
                ISupportsZero sz = op as ISupportsZero;
                return sz.IsZero(tree);
            }
            return false;
        }
    }
}
