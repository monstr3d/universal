using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Nostandard label
    /// </summary>
    public interface INonstandardLabel
    {
        /// <summary>
        /// Initialization
        /// </summary>
        void Initialize();

        /// <summary>
        /// Post operation
        /// </summary>
        void Post();

        /// <summary>
        /// Resize operation
        /// </summary>
        void Resize();

        /// <summary>
        /// Creates Form
        /// </summary>
        void CreateForm();

        /// <summary>
        /// Associated form
        /// </summary>
        object Form
        {
            get;
        }

        /// <summary>
        /// Associated image
        /// </summary>
        object Image
        {
            get;
        }
    }
}
