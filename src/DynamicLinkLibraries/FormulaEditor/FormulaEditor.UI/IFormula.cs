using System;
using System.Collections.Generic;

namespace FormulaEditor.UI
{
    /// <summary>
    /// Object tha contains formula
    /// </summary>
    public interface IFormula
    {
        /// <summary>
        /// String representation of formula
        /// </summary>
        string Formula
        {
            get;
            set;
        }
    }
}
