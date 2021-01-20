using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Standard
{
    /// <summary>
    /// Blinked Object
    /// </summary>
    public interface IBlinked
    {
        /// <summary>
        /// Blink itself
        /// </summary>
        /// <param name="i"></param>
        void Blink(int i);

        /// <summary>
        /// The "is stopped" sing
        /// </summary>
        bool IsStopped { get; set; }
    }
}
