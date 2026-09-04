using DataPerformer.Interfaces;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;

namespace DataPerformer.Portable.Wrappers
{
    /// <summary>
    /// Wrapper of component collection
    /// </summary>
    public  class ComponentCollectionWrapper : CommonWrapper
    {
        /// <summary>
        /// The Component collection
        /// </summary>
        public IComponentCollection ComponentCollection { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="componentCollection">The component collection</param>
        public ComponentCollectionWrapper(IComponentCollection componentCollection)
        {
            ComponentCollection = componentCollection;
        }



        /// <summary>
        /// Performs action with fixed step
        /// </summary>
        /// <param name="start">Start</param>
        /// <param name="step">Step</param>
        /// <param name="count">Count of steps</param>
        /// <param name="provider">Provider of time measure</param>
        /// <param name="processor">Differential equation processor</param>
        /// <param name="priority">Priority</param>
        /// <param name="action">Additional action</param>
        /// <param name="reason">Reason</param>
        public void PerformFixed(double start, double step, int count, ITimeMeasurementProvider provider,
        IDifferentialEquationProcessor processor, int priority, Action action, string reason)
        {
            using (var backup = new
                TimeProviderBackup(ComponentCollection, provider, processor, priority, reason))
            {
                List<IMeasurements> measurements = backup.Measurements;
                IDataRuntime runtime = backup.Runtime;
                ITimeMeasurementProvider old = processor.TimeProvider;
                processor.TimeProvider = provider;
                Action<double, double, long> act = runtime.Step(processor,
                    (double time) => { provider.Time = time; }, reason);
                double last = start;
                double t = start;
                for (int i = 0; i < count; i++)
                {
                    t = start + i * step;
                    act(last, t, (long)i);
                    last = t;
                    action();
                }
                processor.TimeProvider = old;
            }
        }

    }
}
