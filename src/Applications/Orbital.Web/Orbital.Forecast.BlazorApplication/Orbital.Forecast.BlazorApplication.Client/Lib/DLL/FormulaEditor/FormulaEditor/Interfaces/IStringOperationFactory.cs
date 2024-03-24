using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes.Interfaces;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Factory of operations by string
    /// </summary>
    public interface IStringOperationFactory
    {
        /// <summary>
        /// Gets operation from key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The opreation</returns>
        IObjectOperation this[string key]
        {
            get;
        }
    }
}
