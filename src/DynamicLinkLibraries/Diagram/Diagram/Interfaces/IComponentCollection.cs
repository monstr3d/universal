using Diagram.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Collection of components
    /// </summary>
    public interface IComponentCollection
    {
        /// <summary>
        /// All components
        /// </summary>
        IEnumerable<object> AllComponents
        {
            get;
        }

        /// <summary>
        /// Desktop
        /// </summary>
        IDesktop Desktop
        {
            get;
        }

    }
}
