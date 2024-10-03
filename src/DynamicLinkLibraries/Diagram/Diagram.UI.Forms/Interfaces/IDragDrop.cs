using CategoryTheory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Drag and drop
    /// </summary>
    public interface IDragDrop
    {
        /// <summary>
        /// Sets drag and drop
        /// </summary>
        /// <param name="converter">Converter</param>
        /// <param name="desktop">Desktop</param>
        void Set(ICategoryObjectConverter converter, PanelDesktop desktop);

        /// <summary>
        /// New drag and drop
        /// </summary>
        IDragDrop New
        {
            get;
        }
    }
}
