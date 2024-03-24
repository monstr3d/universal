using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Portable.Interfaces
{
    /// <summary>
    /// Start realtime
    /// </summary>
    public interface IRealtimeStart
    {
        /// <summary>
        /// Start alias dictionary
        /// </summary>
        Dictionary<IAlias, Dictionary<string, object[]>> StartAlias
        {
            get;
        }

        /// <summary>
        /// The "is enabled" sign
        /// </summary>
        bool IsEnabled
        {
            get;
        }
    }
}