using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// This form should update after external editing
    /// </summary>
    public interface IUpdatableForm
    {
        /// <summary>
        /// Updates form UI
        /// </summary>
        void UpdateFormUI();
    }
}
