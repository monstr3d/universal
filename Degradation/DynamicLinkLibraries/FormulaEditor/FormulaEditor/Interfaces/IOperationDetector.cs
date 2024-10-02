using BaseTypes.Interfaces;

using FormulaEditor.Symbols;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Detector of operation
    /// </summary>
    public interface IOperationDetector
    {
        /// <summary>
        /// Detects operation
        /// </summary>
        /// <param name="symbol">First symbol of the formula</param>
        /// <returns>Acceptor of the operation</returns>
        IOperationAcceptor Detect(MathSymbol symbol);
    }
}
