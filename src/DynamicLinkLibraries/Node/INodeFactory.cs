using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralNode
{
    /// <summary>
    /// Factory of nodes
    /// </summary>
    public interface INodeFactory
    {
        /// <summary>
        /// Creates node from object
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Node</returns>
        INode CreateNode(object o);

    }
}
