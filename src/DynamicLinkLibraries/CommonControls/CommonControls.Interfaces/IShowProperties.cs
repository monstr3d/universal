using System;
using System.Collections.Generic;
using System.Text;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Object which shows proprerties
    /// </summary>
    public interface IShowProperties
    {
        /// <summary>
        /// Shows properties of object
        /// </summary>
        /// <param name="o">The object with properties</param>
        void ShowProperties(object o);
    }
}
