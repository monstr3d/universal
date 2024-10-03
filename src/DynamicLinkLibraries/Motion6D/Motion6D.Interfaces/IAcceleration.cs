using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Accelerated object
    /// </summary>
    public interface IAcceleration
    {
        /// <summary>
        /// Linear acceleration
        /// </summary>
        double[] LinearAcceleration
        {
            get;
        }

        /// <summary>
        /// Relative acceleration
        /// </summary>
        double[] RelativeAcceleration
        {
            get;
        }

    }
}
