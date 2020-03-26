using System;
using System.Collections.Generic;
using System.Text;
using Diagram.UI.Labels;

namespace Diagram.UI.Interfaces.Labels
{
    /// <summary>
    /// Child object label
    /// </summary>
    public interface IChildObjectLabel : IStartStop
    {
        /// <summary>
        /// Associated label
        /// </summary>
        IObjectLabel Label
        {
            get;
        }

        /// <summary>
        /// Shows form
        /// </summary>
        void ShowForm();

        /// <summary>
        /// Removes form
        /// </summary>
        void RemoveForm();
    }
}
