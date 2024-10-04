using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Constant string value
    /// </summary>
    public interface IStringConstantValue
    {
        /// <summary>
        /// The value
        /// </summary>
        string Value { get; }
    }
}
