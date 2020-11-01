using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Blocking control
    /// </summary>
    public interface IBlocking
    {
        /// <summary>
        /// The "is blocked" sign
        /// </summary>
        bool IsBlocked
        {
            get;
            set;
        }
    }
}
