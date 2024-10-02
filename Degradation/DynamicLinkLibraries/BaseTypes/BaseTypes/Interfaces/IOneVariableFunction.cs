using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Function of one variable
    /// </summary>
    public interface IOneVariableFunction : IObjectOperation
    {
        /// <summary>
        /// Type of variable
        /// </summary>
        object VariableType
        {
            get;
        }
    }
}
