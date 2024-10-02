using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Reason of calculation
    /// </summary>
    public interface ICalculationReason
    {
        /// <summary>
        /// Calculation reason
        /// </summary>
        string CalculationReason
        {
            get;
            set;
        }
    }
}
