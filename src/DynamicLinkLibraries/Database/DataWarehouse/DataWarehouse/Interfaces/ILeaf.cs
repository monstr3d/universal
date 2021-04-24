using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Leaf
    /// </summary>
    public interface ILeaf : INode
    {
        /// <summary>
        /// Data
        /// </summary>
        byte[] Data
        {
            get;
            set;
        }
    }
}
