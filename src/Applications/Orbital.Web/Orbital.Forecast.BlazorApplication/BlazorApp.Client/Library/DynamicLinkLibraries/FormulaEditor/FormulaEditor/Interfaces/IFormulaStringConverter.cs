using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FormulaEditor.Symbols;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// String converter
    /// </summary>
    public interface IFormulaStringConverter
    {
        /// <summary>
        /// Converts string to formula
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <param name="sizes">Sizes of formula characters</param>
        /// <returns>The formula</returns>
        MathFormula Convert(string str, int[] sizes);

        /// <summary>
        /// Converts formula to string
        /// </summary>
        /// <param name="formula">Formula to convert</param>
        /// <returns>String representation of formula</returns>
        string Convert(MathFormula formula);

        /// <summary>
        /// Converts formula symbol to string
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>String representation of symbol</returns>
        string Convert(MathSymbol symbol);
    }
}
