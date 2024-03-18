using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes.Interfaces;


namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Acceptor of binary operations
    /// </summary>
    public interface IBinaryAcceptor
    {
        /// <summary>
        /// Acceptor of binary operation
        /// </summary>
        /// <param name="typeA">Type of left part</param>
        /// <param name="typeB">Type of right part</param>
        /// <returns>Accepted operation</returns>
        IObjectOperation Accept(object typeA, object typeB);
    }
}
