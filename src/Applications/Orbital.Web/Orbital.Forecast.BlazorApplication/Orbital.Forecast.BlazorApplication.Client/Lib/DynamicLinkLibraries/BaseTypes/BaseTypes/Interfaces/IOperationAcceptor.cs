using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Operation acceptor
    /// </summary>
    public interface IOperationAcceptor
    {
        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        IObjectOperation Accept(object type);
    }
}
