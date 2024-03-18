using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

namespace Diagram.UI.Labels
{
    /// <summary>
    /// Object label
    /// </summary>
    public interface IObjectLabel : INamedComponent
    {
        /// <summary>
        /// Object
        /// </summary>
        ICategoryObject Object
        {
            get;
            set;
        }

    }
}
