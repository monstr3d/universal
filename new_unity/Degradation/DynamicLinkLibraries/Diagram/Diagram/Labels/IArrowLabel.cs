using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

namespace Diagram.UI.Labels
{
    /// <summary>
    /// Arrow label
    /// </summary>
    public interface IArrowLabel : INamedComponent
    {
        /// <summary>
        /// Arrow
        /// </summary>
        ICategoryArrow Arrow
        {
            get;
            set;
        }

        /// <summary>
        /// Source
        /// </summary>
        IObjectLabel Source
        {
            get;
            set;
        }

        /// <summary>
        /// Target
        /// </summary>
        IObjectLabel Target
        {
            get;
            set;
        }

        /// <summary>
        /// Number of source
        /// </summary>
        object SourceNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Number of target
        /// </summary>
        object TargetNumber
        {
            get;
            set;
        }

    }
}
