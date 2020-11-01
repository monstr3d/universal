using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using FormulaEditor.Symbols;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Generates symbol from key event
    /// </summary>
    public interface IKeySymbol
    {
        /// <summary>
        /// Gets symbol from key aruments
        /// </summary>
        /// <param name="args">Key adguments</param>
        /// <returns>The symbol</returns>
        MathSymbol GetSymbol(KeyPressEventArgs args);
    }
}
