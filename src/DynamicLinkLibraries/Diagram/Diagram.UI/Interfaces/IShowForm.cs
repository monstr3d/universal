using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Component those shows Form
    /// </summary>
    public interface IShowForm
    {
        /// <summary>
        /// Shows form
        /// </summary>
        void ShowForm();

        /// <summary>
        /// Removes form
        /// </summary>
        void RemoveForm();

        /// <summary>
        /// Form
        /// </summary>
        object Form
        {
            get;
        }
    }
}
