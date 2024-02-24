using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Default operation acceptor
    /// </summary>
    public class DefaultOperationAcceptor : IOperationAcceptor
    {
        /// <summary>
        /// Operation
        /// </summary>
        private IObjectOperation operation;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="operation">The operation</param>
        public DefaultOperationAcceptor(IObjectOperation operation)
        {
            this.operation = operation;
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            return operation;
        }
    }
}
