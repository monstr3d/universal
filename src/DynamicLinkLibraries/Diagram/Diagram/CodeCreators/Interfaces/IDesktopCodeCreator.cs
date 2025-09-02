using CategoryTheory;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;

namespace Diagram.UI.CodeCreators.Interfaces
{
    /// <summary>
    /// Creates code for desktop
    /// </summary>
    public interface IDesktopCodeCreator
    {
        /// <summary>
        /// Creates code for desktop
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="namespacE">The namespace</param>
        /// <param name="className">Name of desktop class</param>
        /// <param name="staticClass">The "static class" sign</param>
        /// <returns>The code</returns>
        List<string> CreateCode(IComponentCollection collection, string namespacE,
            string className, bool staticClass = true);

        /// <summary>
        /// Collection
        /// </summary>
        IComponentCollection ComponentCollection { get; }

        /// <summary>
        /// Enumeration
        /// </summary>
        Tuple<Dictionary<ICategoryObject, int>, Dictionary<ICategoryArrow, int>> Enumeration { get; }

    }
}
