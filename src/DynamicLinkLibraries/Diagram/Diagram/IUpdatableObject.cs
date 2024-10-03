using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI
{
    /// <summary>
    /// Interface for should update objects
    /// </summary>
    public interface IUpdatableObject
    {
        /// <summary>
        /// The update operation
        /// </summary>
        Action Update
        {
            get;
        }

        /// <summary>
        /// The "should update" sign
        /// </summary>
        bool ShouldUpdate
        {
            get;
            set;
        }
    }
}
