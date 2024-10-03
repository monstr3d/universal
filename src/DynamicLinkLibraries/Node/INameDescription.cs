using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralNode
{
    /// <summary>
    /// Object that have name and description
    /// </summary>
    public interface INameDescription
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Description
        /// </summary>
        string Description
        {
            get;
        }
    }
}
