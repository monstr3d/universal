using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Measure which replaces its parameter
    /// </summary>
    public interface IReplacedMeasurementParameter
    {
        /// <summary>
        /// Replaces parameter
        /// </summary>
        /// <param name="parameter">Parameter for replace</param>
        void Replace(Func<object> parameter);

        /// <summary>
        /// Resets itself
        /// </summary>
        void Reset();
    }
}
