using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diagram.UI.Labels;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Tools diagram
    /// </summary>
    public interface IToolsDiagram
    {

        /// <summary>
        /// Finds required button
        /// </summary>
        /// <param name="nc">Corresponding component</param>
        /// <returns>The button</returns>
        IPaletteButton FindButton(INamedComponent nc);

        /// <summary>
        /// Finds button
        /// </summary>
        /// <param name="type">Button type</param>
        /// <param name="kind">Button kind</param>
        /// <returns>The button</returns>
        IPaletteButton FindButton(string type, string kind);


    }
}
