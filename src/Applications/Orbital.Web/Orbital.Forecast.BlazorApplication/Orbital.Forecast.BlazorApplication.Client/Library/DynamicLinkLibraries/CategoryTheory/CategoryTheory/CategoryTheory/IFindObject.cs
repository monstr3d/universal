using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryTheory
{
    /// <summary>
    /// Finds object
    /// </summary>
    public interface IFindObject
    {
        /// <summary>
        /// Finds object
        /// </summary>
        /// <param name="type">Object type</param>
        /// <param name="obj">Base object</param>
        /// <returns>The object</returns>
        object this[Type type, object obj]
        {
            get;
        }
    }
}
