using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes.Interfaces;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Multivariable operation
    /// </summary>
    public interface IMultiVariableOperation : IObjectOperation
    {
        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="types">Types of variables</param>
        /// <returns>Accepted operation</returns>
        IObjectOperation Accept(object[] types);
    }
}
