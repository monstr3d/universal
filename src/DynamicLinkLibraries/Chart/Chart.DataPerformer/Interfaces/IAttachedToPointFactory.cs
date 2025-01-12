using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.DataPerformer.Interfaces
{
    /// <summary>
    /// Attached to point
    /// </summary>
    public interface IAttachedToPointFactory
    {
        /// <summary>
        /// Creates attached to point
        /// </summary>
        /// <param name="value">Initial value</param>
        /// <returns>Attached value</returns>
        object this[object value]
        { get; }
    }
}
