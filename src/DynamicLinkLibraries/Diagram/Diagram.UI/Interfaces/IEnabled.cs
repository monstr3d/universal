using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Interface of objects which can be ebabled
    /// </summary>
    public interface IEnabled
    {
        /// <summary>
        /// The "enabled" property
        /// </summary>
        bool Enabled
        {
            get;
            set;
        }
    }
}
