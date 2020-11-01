using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI.Labels
{
    /// <summary>
    /// Holder of arrow label
    /// </summary>
    public interface IArrowLabelHolder
    {
        /// <summary>
        /// The label
        /// </summary>
        IArrowLabel Label
        {
            get;
            set;
        }

    }
}
