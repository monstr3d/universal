using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Parent arrow
    /// </summary>
    public interface IParentArrow
    {
        /// <summary>
        /// Parent arrow
        /// </summary>
        ICategoryArrow Parent
        {
            get;
            set;
        }
    }
}
