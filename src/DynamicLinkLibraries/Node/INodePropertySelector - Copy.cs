using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralNode
{
    /// <summary>
    /// Selector of node property
    /// </summary>
    public interface INodePropertySelector
    {
        /// <summary>
        /// Gets node property
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="node">node</param>
        /// <returns>Property name</returns>
        object GetProperty(string propertyName, INode node);
    }
}
