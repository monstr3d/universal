using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI.ExternalTools
{
    /// <summary>
    /// Factory of external tools
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// Names of tools
        /// </summary>
        string[] Names
        {
            get;
        }

        /// <summary>
        /// Assess to external tool
        /// </summary>
        /// <param name="name">Name of tool</param>
        /// <returns>The external tool</returns>
        object this[string name]
        {
            get;
        }

    }
}
