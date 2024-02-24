using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Transformation of tree
    /// </summary>
    public interface ITreeTransformation
    {
        /// <summary>
        /// Transforms tree
        /// </summary>
        /// <param name="tree">Tree to transform</param>
        /// <returns>Result of transformation</returns>
        ObjectFormulaTree Transform(ObjectFormulaTree tree);
    }
}
