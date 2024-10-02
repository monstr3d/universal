using BaseTypes.Interfaces;

using FormulaEditor.Symbols;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Detector of variable
    /// </summary>
    public interface IVariableDetector
    {
        /// <summary>
        /// Detects variable operation
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>The operation</returns>
        IOperationAcceptor Detect(MathSymbol symbol);
    }
}
