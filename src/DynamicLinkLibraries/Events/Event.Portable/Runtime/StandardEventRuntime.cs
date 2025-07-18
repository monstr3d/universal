﻿using System;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using BaseTypes.Attributes;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;

using Event.Interfaces;
using Event.Portable.Interfaces;
using NamedTree;

namespace Event.Portable.Runtime
{
    /// <summary>
    /// Event runtime
    /// </summary>
    public class StandardEventRuntime : IRealtime, IDisposable
    {
        #region Fields

        IDisposable eventBackup;

        IDisposable timeBackup;

        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly StandardEventRuntime Singleton = new StandardEventRuntime();

        event Action<Exception> onError = (Exception exception) => { };

        private IComponentCollection collection;

        private ITimeMeasurementProvider timeProvider = null;

        private string reason;

        /// private Action<double> stepAction;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        protected StandardEventRuntime()
        {

        }

        #endregion

        #region IRealtime Members

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
        IRealtime IRealtime.Start(IComponentCollection collection,
            TimeType timeUnit, bool isAbsoluteTime, IAsynchronousCalculation stepAction,
            IDataConsumer dataConsumer, IEventLog log, string reason, 
            ITimeMeasurementProviderFactory timeMeasurementProviderFactory)
        {
            this.reason = reason;
            StaticExtensionEventPortable.StartRealtime(collection);
            StandardEventRuntime rt = new StandardEventRuntime();
            rt.collection = collection;
            ITimeMeasurementProviderFactory f = timeMeasurementProviderFactory;
            if (f == null)
            {
                f = DataPerformer.Portable.StaticExtensionDataPerformerPortable.TimeMeasureProviderFactory;
            }
            try
            {
                ITimeMeasurementProvider realTime  =  f.Create(isAbsoluteTime, timeUnit, reason);
                var tuple =
                    new Tuple<IDataConsumer, IComponentCollection, 
                    ITimeMeasurementProvider, IAsynchronousCalculation>
                    (dataConsumer, collection, realTime, stepAction);
                rt.timeProvider = realTime;
                rt.timeBackup =
                       new DataPerformer.Portable.TimeProviderBackup(dataConsumer, realTime, null,
                       reason, 0);
                IEvent[] events = (dataConsumer as IEventHandler).Children.EnumerableToArray();
                if (log != null)
                {
                    foreach (IEvent ev in events)
                    {
                        string name = (dataConsumer as 
                            IAssociatedObject).GetRelativeName(ev as IAssociatedObject);
                        ev.ConnectLog(log, name);
                    }
                    collection.ForEach((IEventReader reader) =>
                    {
                        string name = (dataConsumer as
                            IAssociatedObject).GetRelativeName(reader as IAssociatedObject);
                        reader.ConnectLog(log, name);

                    });
                }
                collection.ForEach((ICalculationReason cr) => { cr.CalculationReason = reason; });
                collection.ForEach((IRealTimeStartStop ss) =>
                {
                    ss.Start();
                });
                rt.eventBackup = new Performers.EventBackup(tuple, events, reason);
            }
            catch (Exception exception)
            {
                onError(exception);
                (rt as IRealtime).Stop();
                rt = null;
            }
            return rt;
        }

        double IRealtime.Time
        {
            get { return timeProvider.Time; }
        }

        void IRealtime.Stop()
        {
            StaticExtensionEventInterfaces.DisconnectLog();
            if (eventBackup != null)
            {
                eventBackup.Dispose();
            }
            if (timeBackup != null)
            {
                timeBackup.Dispose();
            }
            collection.ForEach((IRealTimeStartStop ss) =>
            {
                ss.Stop();
            });
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (eventBackup != null)
            {
                eventBackup.Dispose();
                eventBackup = null;
            }
            if (timeBackup != null)
            {
                timeBackup.Dispose();
                timeBackup = null;
            }
        }

        #endregion


        event Action<Exception> IRealtime.OnError
        {
            add { onError += value; }
            remove { onError -= value; }
        }
 
        /// <summary>
        /// Time provider
        /// </summary>
        ITimeMeasurementProvider IRealtime.TimeProvider
        {
            get { return timeProvider; }
        }

        #endregion

    }
}