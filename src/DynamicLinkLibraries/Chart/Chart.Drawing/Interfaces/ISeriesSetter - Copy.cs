using System;
using System.Collections.Generic;
using System.Text;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Series getter
    /// </summary>
    public interface ISeriesSetter
    {
        /// <summary>
        /// Series
        /// </summary>
        ISeries Series
        {
            set;
        }
    }
}
