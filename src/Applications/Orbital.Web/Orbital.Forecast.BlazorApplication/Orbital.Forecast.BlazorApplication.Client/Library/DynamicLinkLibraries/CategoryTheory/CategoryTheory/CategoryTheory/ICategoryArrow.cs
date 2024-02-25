using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// The arrow of math category theory
    /// </summary>
    public interface ICategoryArrow : IAssociatedObject
    {
        /// <summary>
        /// The source of this arrow
        /// </summary>
        ICategoryObject Source
        {
            get;
            set;
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        ICategoryObject Target
        {
            get;
            set;
        }

    }
}
