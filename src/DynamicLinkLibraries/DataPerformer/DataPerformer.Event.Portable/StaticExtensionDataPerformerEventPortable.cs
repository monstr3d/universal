﻿using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Time;
using Diagram.UI;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.Event.Portable
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionDataPerformerEventPortable
    {

        /// <summary>
        /// Performs an iterator
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="iterator">Iterator</param>
        /// <param name="timeProvider">Time provider</param>
        /// <param name="reason">Reason</param>
        /// <param name="stop">Stop function</param>
        /// <returns>True is success</returns>
        public static bool PerformIterator(this IDataConsumer consumer, IIterator iterator,
    ITimeMeasurementProvider timeProvider, string reason, Func<bool> stop)
        {
            try
            {
                using (var backup = 
                    new DataPerformer.Portable.TimeProviderBackup(consumer, timeProvider, null, reason, 0))
                {
                    IDataRuntime runtime = backup.Runtime;
                    IStep st = null;
                    IMeasurement time = timeProvider.TimeMeasurement;
                    if (runtime is IStep)
                    {
                        st = runtime as IStep;
                        st.Step = 0;
                    }
                    iterator.Reset();
                    double t = (double)time.Parameter();
                    double last = t;
                    Action<double, double, long> act = runtime.Step(null,
                        (double timer) => { }, reason, null);
                    int i = 0;
                    IEnumerable<object> enu = runtime.AllComponents;

                    while (iterator.Next())
                    {
                        t = (double)time.Parameter();
                        act(last, t, i);
                        ++i;
                        if (st != null)
                        {
                            st.Step = i;
                        }
                        last = t;
                        if (stop())
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            return true;
        }

        /// <summary>
        /// Performs iterator enumerable 
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="iterator">Iterator</param>
        /// <param name="timeProvider">Time provider</param>
        /// <param name="reason">Reason</param>
        /// <param name="stop">Stop function</param>
        /// <returns>The enumerable</returns>
        public static IEnumerable<object> PerformIteratorEnumerable(this IDataConsumer consumer, IIterator  iterator, 
            ITimeMeasurementProvider timeProvider, string reason, Func<bool> stop)
        {
            try
            {
                using (var backup = 
                    new DataPerformer.Portable.TimeProviderBackup(consumer, timeProvider, null, reason, 0))
                {
                    IDataRuntime runtime = backup.Runtime;
                    IStep st = null;
                    IMeasurement time = timeProvider.TimeMeasurement;
                    if (runtime is IStep)
                    {
                        st = runtime as IStep;
                        st.Step = 0;
                    }
                    iterator.Reset();
                    double t = (double)time.Parameter();
                    double last = t;
                    Action<double, double, long> act = runtime.Step(null,
                        (double timer) => { }, reason, null);
                    IEnumerable<object> enu = runtime.AllComponents;
                    while (iterator.Next())
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }

            yield return null;
        }


    }
}
