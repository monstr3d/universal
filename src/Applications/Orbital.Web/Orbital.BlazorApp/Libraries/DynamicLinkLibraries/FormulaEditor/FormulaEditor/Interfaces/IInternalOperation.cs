using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Object with internal operation
    /// </summary>
    public interface IInternalOperation
    {
        /// <summary>
        /// The intrernal opreation
        /// </summary>
        IObjectOperation Operation
        { get; }
    }
}
