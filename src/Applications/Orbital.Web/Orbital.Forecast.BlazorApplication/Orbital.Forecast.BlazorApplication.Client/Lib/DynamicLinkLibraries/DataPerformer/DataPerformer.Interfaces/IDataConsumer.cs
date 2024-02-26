using System;
using System.Collections.Generic;
using System.Text;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Consumer of data
    /// </summary>
    public interface IDataConsumer
    {
 
        /// <summary>
        /// Adds data provider 
        /// </summary>
        /// <param name="measurements">Provider to add</param>
        void Add(IMeasurements measurements);

        /// <summary>
        /// Removes data provider
        /// </summary>
        /// <param name="measurements">Provider to remove</param>
        void Remove(IMeasurements measurements);

        /// <summary>
        /// Updates data of data providers
        /// </summary>
        void UpdateChildrenData();

        /// <summary>
        /// Count of providers
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Access to n - th provider
        /// </summary>
        IMeasurements this[int number]
        {
            get;
        }

        /// <summary>
        /// Resets measurements
        /// </summary>
        void Reset();

        /// <summary>
        /// Change Input event
        /// </summary>
        event Action OnChangeInput;
    }
}
