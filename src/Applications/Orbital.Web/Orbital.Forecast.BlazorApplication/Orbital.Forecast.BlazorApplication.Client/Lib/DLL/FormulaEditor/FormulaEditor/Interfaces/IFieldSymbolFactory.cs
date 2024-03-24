using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FormulaEditor.Symbols;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Factory of field symbol
    /// </summary>
    public interface IFieldSymbolFactory
    {
        /// <summary>
        /// Gets type associated to the symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>The type</returns>
        object GetType(FieldSymbol symbol);

        /// <summary>
        /// Gets value associated to the symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>The value</returns>
        object GetValue(FieldSymbol symbol);
    }
}
