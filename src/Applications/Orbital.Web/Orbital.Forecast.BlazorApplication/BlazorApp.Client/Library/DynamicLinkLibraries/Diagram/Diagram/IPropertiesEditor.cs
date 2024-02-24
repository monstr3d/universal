using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI
{
    /// <summary>
    /// Object with editing of propeties
    /// </summary>
    public interface IPropertiesEditor
    {

        /// <summary>
        /// Gets property editor
        /// </summary>
        object Editor
        {
            get;
        }

        /// <summary>
        /// The properties
        /// </summary>
        object Properties
        {
            get;
            set;
        }
    }
}
