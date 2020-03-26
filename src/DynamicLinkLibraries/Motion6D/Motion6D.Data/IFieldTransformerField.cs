using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D
{
    /// <summary>
    /// Field that have transformer
    /// </summary>
    public interface IFieldTransformerField
    {
        /// <summary>
        /// Transformer of n-th component
        /// </summary>
        /// <param name="n">Number of component</param>
        /// <returns>The transformer</returns>
        IFieldTransformer GetTransformer(int n);
    }
}
