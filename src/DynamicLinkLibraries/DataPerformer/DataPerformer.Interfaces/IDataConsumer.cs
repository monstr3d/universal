using System;
using NamedTree;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Consumer of data
    /// </summary>
    public interface IDataConsumer : IChildren<IMeasurements>
    {
 
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
