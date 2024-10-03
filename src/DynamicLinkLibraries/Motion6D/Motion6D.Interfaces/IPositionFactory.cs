using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Factory of position
    /// </summary>
    public interface IPositionFactory
    {
        /// <summary>
        /// Creates position from object array
        /// </summary>
        /// <param name="obArray">The object array</param>
        /// <returns>The position</returns>
        IPosition Create(object[] obArray);

        /// <summary>
        /// Accees to factory by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IPositionFactory this[string name]
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

        /// <summary>
        /// Factory name
        /// </summary>
        string Name
        {
            get;
        }


    }
}
