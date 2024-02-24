using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Separated editor of properties
    /// </summary>
    public interface ISeparatedPropertyEditor
    {
        /// <summary>
        /// Gets editior
        /// </summary>
        /// <param name="o">Edited objectc</param>
        /// <returns>Editor</returns>
        object GetEditor(object o);

   
    }
}
