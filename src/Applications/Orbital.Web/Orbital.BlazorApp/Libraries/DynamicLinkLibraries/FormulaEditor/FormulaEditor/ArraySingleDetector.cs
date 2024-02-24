using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Single detector of array operation
    /// </summary>
    public class ArraySingleDetector : IOperationDetector
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly ArraySingleDetector Object = new ArraySingleDetector();

        private ArraySingleDetector()
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
            if (s is SimpleSymbol)
            {
                SimpleSymbol ss = s as SimpleSymbol;
                if (s.Symbol == '\u2211')
                {
                    return new ArraySingleOperationAcceptor(ArraySingleOperationType.Sum);
                }
            }
            return null;
        }

        #endregion
    }
}
