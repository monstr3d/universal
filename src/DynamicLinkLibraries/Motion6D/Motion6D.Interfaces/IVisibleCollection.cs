using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Visible collection
    /// </summary>
    public interface IVisibleCollection
    {
        /// <summary>
        /// Count of visible objects
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Position of collecton element
        /// </summary>
        /// <param name="number">Number of the element</param>
        /// <returns>The number -th position</returns>
        IPosition this[int number]
        {
            get;
        }

        /// <summary>
        /// Adds a position
        /// </summary>
        /// <param name="position">The position to add</param>
        void Add(IPosition position);

        /// <summary>
        /// Removes position
        /// </summary>
        /// <param name="position">The position to remove</param>
        void Remove(IPosition position);

    }
}
