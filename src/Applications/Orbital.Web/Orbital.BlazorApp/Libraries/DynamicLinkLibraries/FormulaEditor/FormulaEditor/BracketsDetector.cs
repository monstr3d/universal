using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Brackets detector
    /// </summary>
    public class BracketsDetector : IOperationDetector
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly BracketsDetector Object = new BracketsDetector();

        /// <summary>
        /// Constructor
        /// </summary>
        protected BracketsDetector()
        {
        }

        #region IOperationDetector Members

        /// <summary>
        /// Detects operation
        /// </summary>
        /// <param name="s">First symbol of the formula</param>
        /// <returns>Acceptor of operation</returns>
        public IOperationAcceptor Detect(MathSymbol s)
        {
            if (s is BracketsSymbol)
            {
                return new ElementaryBrackets(null);
            }
            return null;
        }

        #endregion
    }
}
