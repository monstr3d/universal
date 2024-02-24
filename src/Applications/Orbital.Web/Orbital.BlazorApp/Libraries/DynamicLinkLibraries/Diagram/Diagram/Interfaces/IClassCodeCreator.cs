using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Creates code for a class
    /// </summary>
    public interface IClassCodeCreator
    {
        /// <summary>
        /// Creates code
        /// </summary>
        /// <param name="preffix">Preffix</param>
        /// <param name="obj">Prototype object</param>
        /// <returns>Code</returns>
        List<string> CreateCode(string preffix, object obj);
    }
}
