using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Checks whether code creation is allowed
    /// </summary>
    public interface IAllowCodeCreation
    {
        /// <summary>
        /// True if code creation is allowed
        /// </summary>
        bool AllowCodeCreation { get; }
    }
}
