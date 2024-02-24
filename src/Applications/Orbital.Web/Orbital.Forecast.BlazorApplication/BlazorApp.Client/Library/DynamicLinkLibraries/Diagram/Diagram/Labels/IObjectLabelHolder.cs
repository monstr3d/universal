using System;
using System.Collections.Generic;
using System.Text;
using CategoryTheory;


namespace Diagram.UI.Labels
{
    /// <summary>
    /// Holder of object label
    /// </summary>
    public interface IObjectLabelHolder
    {
        /// <summary>
        /// The label
        /// </summary>
        IObjectLabel Label
        {
            get;
            set;
        }
    }
}
