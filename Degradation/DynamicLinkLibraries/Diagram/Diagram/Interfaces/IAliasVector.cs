using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Verctor alias
    /// </summary>
    public interface IAliasVector : IAliasBase
    {
        /// <summary>
        /// Names of aliases
        /// </summary>
        IList<string> AliasNames
        {
            get;
        }

        /// <summary>
        /// Access to alias object
        /// </summary>
        object this[string name, int i]
        {
            get;
            set;
        }

        /// <summary>
        /// Gets object type
        /// </summary>
        /// <param name="name">Object name</param>
        /// <returns>Returns type of alias object</returns>
        object GetType(string name);

        /// <summary>
        /// Gets count of aliases
        /// </summary>
        /// <param name="name">Object name</param>
        /// <returns>Count of vector component</returns>
        int GetCount(string name);

    }
}
