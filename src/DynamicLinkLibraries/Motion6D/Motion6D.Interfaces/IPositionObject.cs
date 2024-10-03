using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Object linked to position
    /// </summary>
    public interface IPositionObject
    {
        /// <summary>
        /// Linked position
        /// </summary>
        IPosition Position
        {
            get;
            set;
        }
    }
}
