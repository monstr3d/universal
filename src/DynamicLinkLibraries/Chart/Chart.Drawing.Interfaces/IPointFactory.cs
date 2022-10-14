using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Factory of points
    /// </summary>
    public interface IPointFactory
    {
        /// <summary>
        /// Gets factory by name
        /// </summary>
        /// <param name="name">Factory name</param>
        /// <returns>The factory</returns>
        IPointFactory this[string name]
        {
            get;
        }

        /// <summary>
        /// Creates point
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        IPoint CreatePoint(object[] obj);

        /// <summary>
        /// Types of objects
        /// </summary>
        object[] Types
        {
            get;
        }

        /// <summary>
        /// Names of factories
        /// </summary>
        string[] Names
        {
            get;
        }

 
    }
}
