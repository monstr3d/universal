using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// 3D Position
    /// </summary>
    public interface IPosition
    {

        /// <summary>
        /// Absolute position coordinates
        /// </summary>
        double[] Position
        {
            get;
        }

        /// <summary>
        /// Parent frame
        /// </summary>
        IReferenceFrame Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Position parameters
        /// </summary>
        object Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// Updates itself
        /// </summary>
        void Update();

    }
}
