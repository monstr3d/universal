using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces.Labels;

namespace Diagram.UI.Factory
{
    /// <summary>
    /// Empty UI Factory
    /// </summary>
    public class EmptyUIFactory : IUIFactory
    {

        #region Fields

        IUIFactory parent;

        #endregion

        #region IUIFactory Members

        /// <summary>
        /// Creates object the corresponds to button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>Created object</returns>
        public virtual ICategoryObject CreateObject(IPaletteButton button)
        {
            return null;
        }

        /// <summary>
        /// Creates an arrow the corresponds to button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>Created arrow</returns>
        public virtual ICategoryArrow CreateArrow(IPaletteButton button)
        {
            return null;
        }

        /// <summary>
        /// Creates a form for component properties editor
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The result form</returns>
        public virtual object CreateForm(INamedComponent component)
        {
            return null;
        }


        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="e">The exception of the error</param>
        public virtual void ShowError(Exception e)
        {
        }

        /// <summary>
        /// Creates arrow label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <param name="arrow">Corresponding arrow</param>
        /// <param name="source">Soource label</param>
        /// <param name="target">Target label</param>
        /// <returns>The arrow label</returns>
        public virtual IArrowLabelUI CreateArrowLabel(IPaletteButton button, ICategoryArrow arrow, IObjectLabel source, IObjectLabel target)
        {
            return null;
        }

        /// <summary>
        /// Creates object label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object label</returns>
        public virtual IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            return null;
        }


        /// <summary>
        /// Tools
        /// </summary>
        public virtual IToolsDiagram Tools
        {
            set { }
        }


        /// <summary>
        /// Gets button from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The button</returns>
        public virtual IPaletteButton GetObjectButton(ICategoryObject obj)
        {
            return null;
        }

        /// <summary>
        /// Gets button from arrow
        /// </summary>
        /// <param name="arrow">The arrow</param>
        /// <returns>The arrow</returns>
        public virtual IPaletteButton GetArrowButton(ICategoryArrow arrow)
        {
            return null;
        }

        /// <summary>
        /// Checks order of desktop and throws exception if order is illegal
        /// </summary>
        /// <param name="desktop">The desktop</param>
        public virtual void CheckOrder(IDesktop desktop)
        {
        }

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public virtual IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            return null;
        }

        /// <summary>
        /// Crerates arrow label from arrow
        /// </summary>
        /// <param name="arr">The arrow</param>
        /// <returns>The label</returns>
        public virtual IArrowLabelUI CreateLabel(ICategoryArrow arr)
        {
            return null;
        }

        /// <summary>
        /// Gets additional feature
        /// </summary>
        /// <typeparam name="T">Feature type</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Feature</returns>
        public virtual object GetAdditionalFeature<T>(T obj)
        {
            return null;
        }

        /// <summary>
        /// Parent factory
        /// </summary>
        public IUIFactory Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }


        #endregion
    }
}
