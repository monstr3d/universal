using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;
using FormulaEditor.Attributes;

namespace FormulaEditor
{
    /// <summary>
    /// Detector of array unary operation
    /// </summary>
    public class ArrayOperationDetector : IOperationDetector
    {

        #region Fields
        private IOperationDetector detector;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="detector">Base detector</param>
        public ArrayOperationDetector(IOperationDetector detector)
        {
            this.detector = detector;
        }

        #region IOperationDetector Members

        /// <summary>
        /// Detects operation
        /// </summary>
        /// <param name="s">First symbol of the formula</param>
        /// <returns>Acceptor of operation</returns>
        public IOperationAcceptor Detect(MathSymbol s)
        {
            IOperationAcceptor acc = detector.Detect(s);
            if (acc == null)
            {
                return null;
            }
            if (acc is IMultiVariableOperationAcceptor)
            {
                return new MultiVariableArrayOperationAcceptor(acc as IMultiVariableOperationAcceptor);
            }
            return new ArrayOperationAcceptor(acc);
        }

        #endregion
    }
}
