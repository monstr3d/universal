using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralNode
{
    /// <summary>
    /// Expanded node
    /// </summary>
    public interface IExpandedNode
    {
        /// <summary>
        /// The "is expanded" sign
        /// </summary>
        bool IsExpanded
        {
            get;
            set;
        }
    }
}
