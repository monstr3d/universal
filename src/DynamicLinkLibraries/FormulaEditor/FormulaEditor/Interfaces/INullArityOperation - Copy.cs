using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes.Interfaces;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Null arity operation
    /// </summary>
    public interface INullArityOperation : IObjectOperation
    {
        /// <summary>
        /// Operation object
        /// </summary>
        object Object
        {
            get;
            set;
        }
    }
}
