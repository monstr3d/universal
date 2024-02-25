using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Collection on named data units
    /// </summary>
    public interface IAlias : IAliasBase
    {
        /// <summary>
        /// Names of all data units
        /// </summary>
        IList<string> AliasNames
        {
            get;
        }

        /// <summary>
        /// Access to data unit by name
        /// </summary>
        object this[string name]
        {
            get;
            set;
        }

        /// <summary>
        /// Gets unit type
        /// </summary>
        /// <param name="name">Unit name</param>
        /// <returns>Type of unit</returns>
        object GetType(string name);

        /// <summary>
        /// Change alias event
        /// </summary>
        event Action<IAlias, string> OnChange;

    }
}
