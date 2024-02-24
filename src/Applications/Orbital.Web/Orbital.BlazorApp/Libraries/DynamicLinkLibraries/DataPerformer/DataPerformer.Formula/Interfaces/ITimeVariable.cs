using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.Formula.Interfaces
{
    /// <summary>
    /// Time variable
    /// </summary>
    public interface ITimeVariable
    {
        /// <summary>
        /// Variable
        /// </summary>
        VariableMeasurement Variable
        {
            get;
        }
    }
}
