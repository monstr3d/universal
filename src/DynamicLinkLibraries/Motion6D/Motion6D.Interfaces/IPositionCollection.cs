using System.Collections.Generic;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Collecion of positions
    /// </summary>
    public interface IPositionCollection
    {
        /// <summary>
        /// The collection
        /// </summary>
        ICollection<IPosition> Positions
        {
            get;
        }
    }
}
