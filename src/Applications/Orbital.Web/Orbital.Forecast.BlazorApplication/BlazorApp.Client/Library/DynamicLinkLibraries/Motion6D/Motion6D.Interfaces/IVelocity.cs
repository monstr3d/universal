using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Object with linear velocity
    /// </summary>
    public interface IVelocity
    {
        /// <summary>
        /// Linear velocity
        /// </summary>
        double[] Velocity
        {
            get;
        }

     }
}
