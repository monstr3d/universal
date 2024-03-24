using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Physical unit dictionary
    /// </summary>
    public interface IPhysicalUnitAlias
    {
        /// <summary>
        /// Gets dictionary of an alias
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Physical unit dictionary</returns>
        Dictionary<Type, int> this[string name]
        {
            get;
        }
    }
}
