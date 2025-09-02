using System.Collections.Generic;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Creator of code of alias
    /// </summary>
    public interface IAliasCodeCreator
    {
        /// <summary>
        /// Creates code for alias
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="alias">The alias</param>
        /// <returns>The code</returns>
        Dictionary<string, List<string>> Create(string id, IAlias alias);
    }
}
