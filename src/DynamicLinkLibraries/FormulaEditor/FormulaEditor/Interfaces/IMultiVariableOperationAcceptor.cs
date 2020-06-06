using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor.Symbols;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Acceptor of multivariable operation
    /// </summary>
    public interface IMultiVariableOperationAcceptor : IOperationAcceptor
    {
        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>Accepted operation</returns>
        IMultiVariableOperation AcceptOperation(MathSymbol symbol);
    }
}
