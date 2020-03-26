using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Proxy of tree collection
    /// </summary>
    public interface ITreeCollectionProxy
    {
        /// <summary>
        /// Proxy parameter of tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>The proxy parameter</returns>
        GetValue this[ObjectFormulaTree tree]
        {
            get;
        }

        /// <summary>
        /// Update function
        /// </summary>
        void Update();
    }
 
}
