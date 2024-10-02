using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Native event
    /// </summary>
    public interface INativeEvent
    {
        /// <summary>
        /// Forces itself
        /// </summary>
        void Force();
    }
}
