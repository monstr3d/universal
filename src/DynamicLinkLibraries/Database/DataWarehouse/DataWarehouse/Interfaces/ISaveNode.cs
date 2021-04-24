using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Saves node
    /// </summary>
    public interface ISaveNode
    {
        /// <summary>
        /// Saves node
        /// </summary>
        /// <param name="node">Node to save</param>
        void Save(INode node);
    }
}
