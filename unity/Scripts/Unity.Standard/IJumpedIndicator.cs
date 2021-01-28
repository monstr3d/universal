using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Standard
{
    /// <summary>
    /// Jumped indicator
    /// </summary>
    public interface IJumpedIndicator
    {
        /// <summary>
        /// Jump events
        /// </summary>
        string[] JumpEvents { get;  }
    }
}
