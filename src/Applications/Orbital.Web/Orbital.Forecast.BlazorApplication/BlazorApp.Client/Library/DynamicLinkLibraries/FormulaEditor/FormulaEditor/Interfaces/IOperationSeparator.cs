using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Separator of the operation
    /// </summary>
    public interface IOperationSeparator
    {
        /// <summary>
        /// Gets the separator from the operation
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        string[] this[IObjectOperation operation]
        { get; }
    }
}
