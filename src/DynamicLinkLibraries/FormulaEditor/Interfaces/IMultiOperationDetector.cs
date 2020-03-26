using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Symbols;


namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Multi oprearation detector
    /// </summary>
    public interface IMultiOperationDetector
    {
        /// <summary>
        /// The "has begin" sign
        /// </summary>
        bool HasBegin
        {
            get;
        }

        /// <summary>
        /// The "has end" sign
        /// </summary>
        bool HasEnd
        {
            get;
        }

        /// <summary>
        /// Count of arguments
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Detects i - th symbol of operation
        /// </summary>
        /// <param name="i">The symbol number</param>
        /// <param name="symbol">Symbol of detection</param>
        /// <returns></returns>
        bool Detect(int i, MathSymbol symbol);

        /// <summary>
        /// Accept operation
        /// </summary>
        /// <param name="types">Types of operands</param>
        /// <returns>Operation</returns>
        IObjectOperation Accept(object[] types);

    }
}
