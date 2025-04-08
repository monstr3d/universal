using System;
using NamedTree;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Adding and removing objects
    /// </summary>
    public interface IAddRemove : IChildren<object>
    {
 
        /// <summary>
        /// Type of element
        /// </summary>
        Type Type
        {
            get;
        }
    }
}
