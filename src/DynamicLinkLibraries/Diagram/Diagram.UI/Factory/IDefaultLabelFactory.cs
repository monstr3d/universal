using System;
using System.Collections.Generic;
using System.Text;

using Diagram.UI.Labels;
using CategoryTheory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;

namespace Diagram.UI.Factory
{
    /// <summary>
    /// Factory of default labels
    /// </summary>
    public interface IDefaultLabelFactory
    {

        /// <summary>
        /// Creates object label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object label</returns>
        IObjectLabelUI CreateObjectLabel(IPaletteButton button);

        /// <summary>
        /// Creates arrow label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <param name="arrow">Corresponding arrow</param>
        /// <param name="source">Soource label</param>
        /// <param name="target">Target label</param>
        /// <returns>The arrow label</returns>
        IArrowLabelUI CreateArrowLabel(IPaletteButton button, ICategoryArrow arrow, IObjectLabel source, IObjectLabel target);

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        IObjectLabelUI CreateObjectLabel(ICategoryObject obj);

        /// <summary>
        /// Creates default form for component
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The form</returns>
        object CreateDefaultForm(INamedComponent component);
    }
}
