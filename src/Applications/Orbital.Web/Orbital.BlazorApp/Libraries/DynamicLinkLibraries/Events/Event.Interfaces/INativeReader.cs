using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Reads object
    /// </summary>
    public interface INativeReader
    {
        /// <summary>
        /// Reads object
        /// </summary>
        /// <param name="o">The object for reading</param>
        void Read(object[] o);
    }
}
