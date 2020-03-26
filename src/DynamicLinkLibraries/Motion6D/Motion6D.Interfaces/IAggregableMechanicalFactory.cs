using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Factory of aggregable mechanical objects
    /// </summary>
    public interface IAggregableMechanicalFactory
    {
        /// <summary>
        /// Gets IAggregableMechanicalObject
        /// </summary>
        /// <param name="obj">Prototype</param>
        /// <returns>The object</returns>
        IAggregableMechanicalObject GetObject(object obj);
    }
}
