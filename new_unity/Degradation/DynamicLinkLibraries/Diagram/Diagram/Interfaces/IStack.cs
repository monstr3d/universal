using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Stack object
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Push
        /// </summary>
        void Push();

        /// <summary>
        /// Pop
        /// </summary>
        void Pop();
    }
}
