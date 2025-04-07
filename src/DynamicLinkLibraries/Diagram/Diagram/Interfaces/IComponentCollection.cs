using Diagram.Interfaces;
using Diagram.UI.Labels;
using NamedTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Collection of components
    /// </summary>
    public interface IComponentCollection : INamed
    {
        /// <summary>
        /// All components
        /// </summary>
        IEnumerable<object> AllComponents
        {
            get;
        }

        /// <summary>
        /// Desktop
        /// </summary>
        IDesktop Desktop
        {
            get;
        }

        IEnumerable<IObjectLabel> Objects { get; }

        IEnumerable<IArrowLabel> Arrows { get; }

        IEnumerable<INamedComponent> NamedComponents { get; }


        IEnumerable<CategoryTheory.ICategoryObject> CategoryObjects { get; }

        IEnumerable<CategoryTheory.ICategoryArrow> CategoryArrows { get; }

        IEnumerable<T> Get<T>() where T : class;

    }
}
