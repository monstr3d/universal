using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Math distribution
    /// </summary>
    public interface IDistribution
    {
        /// <summary>
        /// Resets itself
        /// </summary>
        void Reset();

        /// <summary>
        /// Gets an integral
        /// </summary>
        double Integral
        {
            get;
        }

    }
}
