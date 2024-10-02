using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using FormulaEditor.Symbols;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Converter of math symbol
    /// </summary>
    public interface IMathSymbolConverter
    {
        /// <summary>
        /// Converts the symbol
        /// </summary>
        /// <param name="symbol">Symbol - source</param>
        /// <returns>Symbol - result</returns>
        MathSymbol Convert(MathSymbol symbol);
    }
}
