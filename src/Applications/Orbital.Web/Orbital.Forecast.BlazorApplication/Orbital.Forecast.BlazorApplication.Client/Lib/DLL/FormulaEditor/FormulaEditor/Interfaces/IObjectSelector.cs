using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Selector of objects
    /// </summary>
    public interface IObjectSelector
    {
        /// <summary>
        /// Selects object
        /// </summary>
        /// <param name="x">Input of selection</param>
        /// <returns>Output of selection</returns>
        object Select(object x);
    }
}
