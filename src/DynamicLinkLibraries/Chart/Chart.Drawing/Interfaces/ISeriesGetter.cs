using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Getter of series
    /// </summary>
    public interface ISeriesGetter
    {
        /// <summary>
        /// Series
        /// </summary>
        ISeries Series
        {
            get;
        }
    }
}
