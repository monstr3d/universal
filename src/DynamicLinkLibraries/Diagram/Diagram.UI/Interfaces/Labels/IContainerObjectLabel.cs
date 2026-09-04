using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces.Labels
{
    /// <summary>
    /// Container label
    /// </summary>
    public interface IContainerObjectLabel
    {
        /// <summary>
        /// Expands label
        /// </summary>
        Task Expand();
    }
}
