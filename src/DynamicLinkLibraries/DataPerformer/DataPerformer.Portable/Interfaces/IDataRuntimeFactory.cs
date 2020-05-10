using System;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

namespace DataPerformer.Portable.Interfaces
{
    /// <summary>
    /// Strategy for data perfomer
    /// </summary>
    public interface IDataRuntimeFactory
    {
        /// <summary>
        /// Creates runtime from collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        /// <returns>The runtime</returns>
        IDataRuntime Create(IComponentCollection collection, 
            int priority, string reason = null);


        /// <summary>
        /// Creates runtime from data consumer
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        /// <returns>The runtime</returns>
        IDataRuntime Create(IDataConsumer consumer, int priority, string reason);


        /// <summary>
        /// Time provider
        /// </summary>
        ITimeMeasurementProvider TimeProvider
        {
            get;
        }

        /// <summary>
        /// Creates collection
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="reason">Reason</param>
        /// <param name="priority">Priority</param>
        /// <returns>Collection</returns>
        IComponentCollection CreateCollection(IDataConsumer consumer, 
            int priority, string reason);

        /// <summary>
        /// Priority
        /// </summary>
        int Priority
        {
            get;
            set;
        }

        /// <summary>
        /// Start action
        /// </summary>
        /// <param name="consumer">Start time</param>
        /// <returns>Start action</returns>
        Action<double> GetStart(IDataConsumer consumer);

        /// <summary>
        /// Update dependent action
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <returns>Update dependent objects action</returns>
        Action UpdateDependent(IDataConsumer consumer);

    }
}