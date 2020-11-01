using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CategoryTheory;
using Diagram.UI.Labels;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Desktop
    /// </summary>
    public interface IDesktop : IComponentCollection
    {
        /// <summary>
        /// Components
        /// </summary>
        IEnumerable<object> Components
        {
            get;
        }

 
        /// <summary>
        /// Objects
        /// </summary>
        IEnumerable<IObjectLabel> Objects
        {
            get;
        }

        /// <summary>
        /// Arrows
        /// </summary>
        IEnumerable<IArrowLabel> Arrows
        {
            get;
        }


        /// <summary>
        /// Copies objects and arrows
        /// </summary>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        /// <param name="associated">Copy associated objects sign</param>
        void Copy(IEnumerable<IObjectLabel> objects, IEnumerable<IArrowLabel> arrows, bool associated);

        /// <summary>
        /// Access to component
        /// </summary>
        INamedComponent this[string name]
        {
            get;
        }

        /// <summary>
        /// Gets associated object
        /// </summary>
        /// <param name="name">Object name</param>
        /// <returns>Associated object</returns>
        object GetObject(string name);

        /// <summary>
        /// Parent desktop
        /// </summary>
        IDesktop ParentDesktop
        {
            get;
        }

        /// <summary>
        /// Level of desktop
        /// </summary>
        int Level
        {
            get;
        }

        /// <summary>
        /// Root desktop
        /// </summary>
        IDesktop Root
        {
            get;
        }

        /// <summary>
        /// All objects
        /// </summary>
        IEnumerable<ICategoryObject> CategoryObjects
        {
            get;
        }

        /// <summary>
        /// All arrows
        /// </summary>
        IEnumerable<ICategoryArrow> CategoryArrows
        {
            get;
        }

    }
}
