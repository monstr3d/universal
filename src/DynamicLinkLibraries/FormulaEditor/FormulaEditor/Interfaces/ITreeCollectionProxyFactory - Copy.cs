using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor;

namespace FormulaEditor.Interfaces

{
    /// <summary>
    /// Factory of tree collection
    /// </summary>
    public interface ITreeCollectionProxyFactory
    {
        /// <summary>
        /// Creates proxy for collection of trees
        /// </summary>
        /// <param name="collection">Collection of trees</param>
        /// <param name="checkValue">Check value delegate</param>
        /// <returns>The proxy</returns>
        ITreeCollectionProxy CreateProxy(ITreeCollection collection, Action<object> checkValue);
    }
}
