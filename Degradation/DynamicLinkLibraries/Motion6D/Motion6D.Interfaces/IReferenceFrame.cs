using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Reference frame holder
    /// </summary>
    public interface IReferenceFrame : IPosition
    {
        /// <summary>
        /// Own frame
        /// </summary>
        ReferenceFrame Own
        {
            get;
        }

        /// <summary>
        /// Children objects
        /// </summary>
        List<IPosition> Children
        {
            get;
        }

    }
}
