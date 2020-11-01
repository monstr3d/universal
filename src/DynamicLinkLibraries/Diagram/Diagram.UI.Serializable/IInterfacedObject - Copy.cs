using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI
{
    /// <summary>
    /// Object with interface
    /// </summary>
    public interface IInterfacedObject
    {
        /// <summary>
        /// The x coorginate
        /// </summary>
        int X
        {
            get;
        }

        /// <summary>
        /// The y coordinate
        /// </summary>
        int Y
        {
            get;
        }

        /// <summary>
        /// Comment
        /// </summary>
        string Comment
        {
            get;
        }
    }

}
