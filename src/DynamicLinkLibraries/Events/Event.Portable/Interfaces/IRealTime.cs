using System;

using BaseTypes.Attributes;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;

using Event.Interfaces;

namespace Event.Portable.Interfaces
{
    /// <summary>
    /// Real time
    /// </summary>
    public interface IRealtime
    {

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="collection">Components</param>
        /// <param name="timeUnit">Time unit</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="stepAction">Step Action</param>
        /// <param name="dataConsumer">Data Consumer</param>
        /// <param name="log">log</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeMeasurementProviderFactory">Factory of time measurements</param>
        /// <returns>Start runtime</returns>
        IRealtime Start(IComponentCollection collection,
            TimeType timeUnit, bool isAbsoluteTime, IAsynchronousCalculation stepAction, 
            IDataConsumer dataConsumer, IEventLog log, string reason, 
            ITimeMeasurementProviderFactory timeMeasurementProviderFactory);

        /// <summary>
        /// Current time
        /// </summary>
        double Time
        {
            get;
        }

        /// <summary>
        /// Stop
        /// </summary>
        void Stop();

        /// <summary>
        /// Error Event
        /// </summary>
        event Action<Exception> OnError;

        /// <summary>
        /// Time provider
        /// </summary>
        ITimeMeasurementProvider TimeProvider
        {
            get;
        }
    }
}
