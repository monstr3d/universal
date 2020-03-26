using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Saver of formula
    /// </summary>
    public interface IFormulaSaver
    {
        /// <summary>
        /// Loads formula from string
        /// </summary>
        /// <param name="str">The string</param>
        /// <returns>Loaded formula</returns>
        MathFormula Load(string str);

        /// <summary>
        /// Saves formula to string
        /// </summary>
        /// <param name="formula">The formula</param>
        /// <returns>The saved string</returns>
        string Save(MathFormula formula);
    }
}
