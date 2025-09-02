using System.Collections.Generic;

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
        /// <param name="prefix">Prefix</param>
        /// <param name="obj">Prototype object</param>
        /// <param name="volume">Prototype object</param>
        /// <returns>Code</returns>
        List<string> CreateCode(string prefix, object obj, string volume);


    }
}
