using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Factory of parallel calculations
    /// </summary>
    public interface IParallelFactory
    {

        /// <summary>
        /// Gets unary parallel operation
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="operation">Prototype</param>
        /// <returns>The parallel operation</returns>
        IObjectOperation GetUnary(object type, IObjectOperation operation);

        /// <summary>
        /// Get dynamical binary left parallel operation
        /// </summary>
        /// <param name="typeLeft">Type of left part</param>
        /// <param name="typeRight">Type of right part</param>
        /// <param name="operation">Prototype</param>
        /// <returns>The parallel operation</returns>
        IObjectOperation GetDynamicalBinaryLeft(object typeLeft, object typeRight, IObjectOperation operation);

        /// <summary>
        /// Get dynamical binary right parallel operation
        /// </summary>
        /// <param name="typeLeft">Type of left part</param>
        /// <param name="typeRight">Type of right part</param>
        /// <param name="operation">Prototype</param>
        /// <returns>The parallel operation</returns>
        IObjectOperation GetDynamicalBinaryRight(object typeLeft, object typeRight, IObjectOperation operation);

    }
}
