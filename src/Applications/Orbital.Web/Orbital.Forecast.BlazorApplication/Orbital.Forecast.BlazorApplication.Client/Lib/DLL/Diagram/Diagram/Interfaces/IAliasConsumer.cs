using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Consumer of alias
    /// </summary>
    public interface IAliasConsumer
    {
        /// <summary>
        /// Adds an alias
        /// </summary>
        /// <param name="alias">The alias</param>
        void Add(IAlias alias);

        /// <summary>
        /// Removes alias
        /// </summary>
        /// <param name="alias">The alias</param>
        void Remove(IAlias alias);
    }
}
