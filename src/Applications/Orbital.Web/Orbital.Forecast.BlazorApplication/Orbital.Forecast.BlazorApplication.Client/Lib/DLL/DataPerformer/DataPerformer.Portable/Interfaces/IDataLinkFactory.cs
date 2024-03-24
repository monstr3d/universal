using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable.Interfaces
{
    /// <summary>
    /// Factory of data link objects
    /// </summary>
    public interface IDataLinkFactory
    {
        /// <summary>
        /// Gets consumer
        /// </summary>
        /// <param name="source">Source object</param>
        /// <returns>The consumer</returns>
        IDataConsumer GetConsumer(ICategoryObject source);

        /// <summary>
        /// Gets measurements
        /// </summary>
        /// <param name="target">Target object</param>
        /// <returns>The measurements</returns>
        IMeasurements GetMeasurements(ICategoryObject target);
    }
}
