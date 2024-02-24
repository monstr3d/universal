using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Factory of measure objects
    /// </summary>
    public interface IMeasurementObjectFactory
    {
        /// <summary>
        /// Creates the measure object
        /// </summary>
        /// <param name="measure">The measure</param>
        /// <returns>The object</returns>
        object this[IMeasurement measure]
        { get; }

        /// <summary>
        /// Creates the measure object
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="measure">The measure</param>
        /// <returns>The object</returns>
        object this[string name, IMeasurement measure]
        { get; }
   
    }
}
