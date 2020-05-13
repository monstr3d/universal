using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Simulink.Parser.Library;

namespace Simulink.Proxy.UI.Interfaces
{
    /// <summary>
    /// Holder of "change system" event generator
    /// </summary>
    public interface IChangeSystem
    {
        /// <summary>
        /// The "change system" event
        /// </summary>
        event Action<object> ChangeSystem;
    }
}
