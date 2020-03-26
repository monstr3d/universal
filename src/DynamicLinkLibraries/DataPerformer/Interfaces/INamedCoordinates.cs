using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Inteface for mamed cootrdinates
    /// </summary>
    public interface INamedCoordinates
    {
        /// <summary>
        /// Gets names of all possible identifiers of coordinates
        /// </summary>
        /// <param name="coordinateName">Name of coordinate</param>
        /// <returns>All possible identifiers of coordinates</returns>
        IList<string> GetNames(string coordinateName);

        /// <summary>
        /// Identifier of x
        /// </summary>
        string X
        {
            get;
        }

        /// <summary>
        /// Identifier of y;
        /// </summary>
        string Y
        {
            get;
        }

        /// <summary>
        /// Sets idetifiers for coordinates
        /// </summary>
        /// <param name="x">The identifier of x - coordinate</param>
        /// <param name="y">The identifier of y - coordinate</param>
        void Set(string x, string y);

        /// <summary>
        /// Updates itself
        /// </summary>
        void Update();
    }
}
