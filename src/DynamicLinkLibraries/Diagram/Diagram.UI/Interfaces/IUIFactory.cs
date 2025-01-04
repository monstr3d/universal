using System;
using System.Collections.Generic;
using System.Text;


using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces.Labels;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// The factory of objects arrows and controls
    /// </summary>
    public interface IUIFactory
    {
        /// <summary>
        /// Creates object which corresponds to a button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>Created object</returns>
        ICategoryObject CreateObject(IPaletteButton button);

        /// <summary>
        /// Creates an arrow which corresponds to a button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>Created arrow</returns>
        ICategoryArrow CreateArrow(IPaletteButton button);

        /// <summary>
        /// Creates a form for component properties editor
        /// </summary>
        /// <param name="comp">The component</param>
        /// <returns>The result form</returns>
        object CreateForm(INamedComponent comp);

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
        /// Creates object label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object label</returns>
        IObjectLabelUI CreateObjectLabel(IPaletteButton button);


        /// <summary>
        /// Tools
        /// </summary>
        IToolsDiagram Tools
        {
            set;
        }

        /// <summary>
        /// Gets button from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The button</returns>
        IPaletteButton GetObjectButton(ICategoryObject obj);

        /// <summary>
        /// Gets button from arrow
        /// </summary>
        /// <param name="arrow">The arrow</param>
        /// <returns>The arrow</returns>
        IPaletteButton GetArrowButton(ICategoryArrow arrow);

        /// <summary>
        /// Checks order of desktop and throws exception if order is illegal
        /// </summary>
        /// <param name="desktop">The desktop</param>
        void CheckOrder(IDesktop desktop);


        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        IObjectLabelUI CreateLabel(ICategoryObject obj);

        /// <summary>
        /// Crerates arrow label from arrow
        /// </summary>
        /// <param name="arr">The arrow</param>
        /// <returns>The label</returns>
        IArrowLabelUI CreateLabel(ICategoryArrow arr);

        /// <summary>
        /// Creates additional feature
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Additional feature</returns>
  
        /// <summary>
        /// Gets additional feature
        /// </summary>
        /// <typeparam name="T">Feature type</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Feature</returns>
        object GetAdditionalFeature<T>(T obj);

        /// <summary>
        /// Parent factory
        /// </summary>
        IUIFactory Parent
        {
            get;
            set;
        }
    }
}
