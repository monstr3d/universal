using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
