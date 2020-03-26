using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Runtime;
using DataPerformer.Interfaces;

using Event.Interfaces;

using Event.Basic;
using Event.Basic.Arrows;
using Event.Portable.Interfaces;
using Event.Portable;

namespace Event.Basic.Performers
{
    /// <summary>
    /// Backup of events
    /// </summary>
    public class EventBackup : IDisposable
    {
        #region Fields

        Dictionary<IEvent, Action> actions = new Dictionary<IEvent, Action>();

        IComponentCollection collection;

        Dictionary<IAlias, Dictionary<string, object[]>> dictionary;

        IEvent[] events;

        IEventReader[] readers;

        INativeEvent[] nativeEvents;

        List<object> lno = new List<object>();

        #endregion

        #region Ctor

        /// <summary>
        /// Event backup
        /// </summary>
        /// <param name="tuple">Tuple</param>
        /// <param name="events">Events</param>
        /// <param name="reason">Reason</param>
        public EventBackup(Tuple<IDataConsumer, IComponentCollection, ITimeMeasureProvider, 
            IAsynchronousCalculation> tuple,
            IEvent[] events, string reason)
        {
            this.events = events;
            collection = tuple.Item2;
            IDesktop desktop = collection.Desktop.Root;
            IList<ICategoryObject> l = collection.GetAll<ICategoryObject>();
            IRealtimeStart rst = null;
            desktop.ForEach((BelongsToCollection arrow) =>
                {
                    if (!l.Contains(arrow.Target))
                    {
                        return;
                    }
                    ICategoryObject s = arrow.Source;
                    if (s is IRealtimeStart)
                    {
                        IRealtimeStart rs = s as IRealtimeStart;
                        if (rs.IsEnabled)
                        {
                            if (rst != null)
                            {
                                throw new Exception("Start already exists");
                            }
                            rst = rs;
                        }
                    }
                });
            if (rst != null)
            {
                dictionary = rst.StartAlias;
                dictionary.Get();
            }
            Tuple<string, Tuple<IDataConsumer, IComponentCollection, ITimeMeasureProvider,
                IAsynchronousCalculation>> tt = new Tuple<string, Tuple<IDataConsumer, IComponentCollection, 
                ITimeMeasureProvider, IAsynchronousCalculation>>
                (reason, tuple);
            IActionFactory f = StaticExtensionEventPortable.ActionFactoryCreator[tt];
            List<INativeEvent> lnative = new List<INativeEvent>();
            List<INativeReader> lnativeR = new List<INativeReader>();
            if (events != null)
            {
                foreach (IEvent ev in events)
                {
                    Action a = f[ev];
                    actions[ev] = a;
                    ev.Event += a;
                }
            }
            else
            {
              collection.ForEach(
                     (IEvent ev) =>
                     {
                         Action a = f[ev];
                         actions[ev] = a;
                         ev.Event += a;
                     });
            }
            if (reason.IsRealtimeAnalysis())
            {
                    collection.ForEach((INativeEvent ne) => {
                    lnative.Add(ne);
                    lno.Add(ne);
                    if (ne is ICalculationReason)
                    {
                        (ne as ICalculationReason).CalculationReason = reason;
                    }
                    if (ne is IEvent)
                    {
                        (ne as IEvent).IsEnabled = true;
                    }
                });
                collection.ForEach(
                    (INativeReader re) => 
                    {
                        lnativeR.Add(re);
                        lno.Add(re);
                        if (re is ICalculationReason)
                        {
                            (re as ICalculationReason).CalculationReason = reason;
                        }
                        if (re is IEventReader)
                        {
                            (re as IEventReader).IsEnabled = true;
                        }
                    });
            }
             
            collection.ForEach(
            (IEvent ev) =>
           {
                   ev.IsEnabled = true;
            });
            List<IEventReader> ler = new List<IEventReader>();
            collection.ForEach((IEventReader r) => {
                ler.Add(r);

                     r.IsEnabled = true;
            });
            readers = ler.ToArray();
            nativeEvents = lnative.ToArray();
        }


        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (dictionary != null)
            {
                dictionary.Set();
            }
            if (events != null)
            {
                foreach (IEvent ev in events)
                {
                    ev.IsEnabled = false;
                    ev.Event -= actions[ev];
                }
                foreach (IEvent ev in events)
                {
                    if (ev.IsEnabled)
                    {
                        ev.IsEnabled = false;
                    }
                }
            }
            foreach (IEventReader r in readers)
            {
                if (r.IsEnabled)
                {
                    r.IsEnabled = false;
                }
            }
            return;
            collection.ForEach<IEvent>((IEvent ev) => { ev.IsEnabled = false; });
            foreach (IEvent ev in actions.Keys)
            {
                if (!lno.Contains(ev))
                {
                    ev.IsEnabled = false;
                }
                ev.Event -= actions[ev];
            }
        }

        #endregion
    }
}
