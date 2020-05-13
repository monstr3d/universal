using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulink.Parser.Library.Interfaces
{
    /// <summary>
    /// Object with attribute
    /// </summary>
    public interface IAttribute
    {
        /// <summary>
        /// Access to attribute
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The value</returns>
        string this[string key]
        {
            get;
        }
    }
}
