using System;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{

    /// <summary>
    /// Detector of objected symbol
    /// </summary>
    public class ObjectSymbolDetector : IOperationDetector
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly ObjectSymbolDetector Object = new ObjectSymbolDetector();

        private ObjectSymbolDetector()
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
            if (s is ObjectedSymbol)
            {
                ObjectedSymbol os = s as ObjectedSymbol;
                return os;
            }
            return null;
        }

        #endregion
    }
}
