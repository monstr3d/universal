using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseTypes.Attributes;

using Diagram.UI.Interfaces;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Factory of async calclulations
    /// </summary>
    public interface IAsynchronousCalculationFactory
    {
        /// <summary>
        /// Creates asynchronous calculation
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="reasons">Reasons</param>
        /// <param name="timeUnit">Time unit</param>
        /// <param name="timeScale">Time scale</param>
        /// <returns>Calculation</returns>
        IAsynchronousCalculation Create(IComponentCollection collection, string[] reasons, TimeType timeUnit, double timeScale);
    }
}
