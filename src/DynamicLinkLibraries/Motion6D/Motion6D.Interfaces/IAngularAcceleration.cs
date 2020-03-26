using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Angular Acceleration
    /// </summary>
    public interface IAngularAcceleration
    {
        /// <summary>
        /// Angular acceleration
        /// </summary>
        double[] AngularAcceleration
        {
            get;
        }

    }
}
