using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataPerformer.Interfaces;
using DataPerformer.Helpers;
using DataPerformer.Portable;

using Event.Interfaces;
using DataPerformer.Portable.DifferentialEquationProcessors;

namespace DataPerformer.Runtime
{

    /// <summary>
    /// Simplest runtime
    /// </summary>
    public class DataRuntime : IDataRuntime, IStep, IActionFactory, IDisposable
    {
        #region Fields

        /// <summary>
        /// Objects
        /// </summary>
        protected List<ICategoryObject> objects = new List<ICategoryObject>();

        /// <summary>
        /// Arrows
        /// </summary>
        protected List<ICategoryArrow> arrows = new List<ICategoryArrow>();

        /// <summary>
        /// Updatable objects
        /// </summary>
        protected List<Action> updatable = new List<Action>();


        /// <summary>
        /// Dynamical objects
        /// </summary>
        protected List<IDynamical> dynamical = new List<IDynamical>();

        /// <summary>
        /// Measurements
        /// </summary>
        protected List<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// Steps
        /// </summary>
        protected List<IStep> steps = new List<IStep>();


        /// <summary>
        /// Components
        /// </summary>
        protected List<object> components = new List<object>();

        /// <summary>
        /// Step
        /// </summary>
        protected double dstep;

        /// <summary>
        /// Collection of objects
        /// </summary>
        protected IComponentCollection collection;

        /// <summary>
        /// Collections
        /// </summary>
        protected List<IComponentCollection> collections;

        private Dictionary<string, object> logDictionary = new Dictionary<string, object>();

        /// <summary>
        /// Dictionary of collections
        /// </summary>
        protected Dictionary<object, IComponentCollection> dCollection;

        /// <summary>
        /// Dictionary of processors
        /// </summary>
        protected Dictionary<IComponentCollection, Tuple<double[], IDifferentialEquationProcessor>> cProcessors =
            new Dictionary<IComponentCollection, Tuple<double[], IDifferentialEquationProcessor>>();

        /// <summary>
        /// Dictionary of processors
        /// </summary>
        protected Dictionary<object, Tuple<double[], IDifferentialEquationProcessor>> processors =
            new Dictionary<object, Tuple<double[], IDifferentialEquationProcessor>>();



        /// <summary>
        /// Step
        /// </summary>
        protected long step;

        /// <summary>
        /// Update action
        /// </summary>
        private Action updateAll;

        /// <summary>
        /// Time provider
        /// </summary>
        ITimeMeasurementProvider provider = new TimeMeasurementProvider();

        /// <summary>
        /// State
        /// </summary>
        protected double[] state;

        /// <summary>
        /// Check level
        /// </summary>
        protected int priority = 0;

        /// <summary>
        /// Realtime
        /// </summary>
        protected ITimeMeasurementProvider realtime;

        /// <summary>
        /// Realtime data
        /// </summary>
        protected Dictionary<IComponentCollection,
            Tuple<IDataRuntime, double[], IDifferentialEquationProcessor, Action>> realTimeData;


        /// <summary>
        /// Start time
        /// </summary>
        protected double startRuntime;

        /// <summary>
        /// Reason
        /// </summary>
        protected string reason;

        /// <summary>
        /// Realtime step
        /// </summary>
        protected IAsynchronousCalculation realtimeStep;


        static object locker = new object();



        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">Collection of components</param>
        /// <param name="reason">Reason</param>
        /// <param name="priority">Priority</param>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="realtimeStep">Realtime step</param>
        /// <param name="realtime">Realtime provider</param>
        public DataRuntime(IComponentCollection collection, string reason, int priority,
            IDataConsumer dataConsumer = null,
            IAsynchronousCalculation realtimeStep = null,
            ITimeMeasurementProvider realtime = null)
        {
            this.collection = collection;
            this.priority = priority;
            this.reason = reason;
            this.realtimeStep = realtimeStep;
            Prepare();
            if (realtime != null & priority == 0)
            {
                if (reason == StaticExtensionEventInterfaces.Realtime |
                    reason.IsRealtimeAnalysis())
                {
                    List<IRealtimeUpdate> lr = new List<IRealtimeUpdate>();
                    realTimeData =
                        new Dictionary<IComponentCollection, Tuple<IDataRuntime, double[],
                            IDifferentialEquationProcessor, Action>>();
                    this.realtime = realtime as ITimeMeasurementProvider;
                    provider = realtime;
                    dCollection = new Dictionary<object, IComponentCollection>();
                    /*!!!! * DECOMPOSITION THINK AFTER
                     collections = collection.Decompose(dCollection);
                     */
                    //========== REPLACED========
                    collections = new List<IComponentCollection>() { collection };
                    collection.ForEach((IEvent ev) => { dCollection[ev] = collection; });
                    //===========================
                    IEventLog log = null;
                    if (reason.Equals(StaticExtensionEventInterfaces.Realtime))
                    {
                        log = StaticExtensionEventInterfaces.NewLog;
                    }
                    Action logupd = null;
                    if (log != null)
                    {
                        Dictionary<IMeasurement, string> namem = new Dictionary<IMeasurement, string>();
                        List<IMeasurement> lim = new List<IMeasurement>();
                        collection.ForEach((IMeasurements mm) =>
                        {
                            string name = (dataConsumer).GetMeasurementsName(mm) + ".";
                            for (int i = 0; i < mm.Count; i++)
                            {
                                IMeasurement mea = mm[i];
                                if (mea is IReplacedMeasurementParameter)
                                {
                                    lim.Add(mea);
                                    namem[mea] = name + mea.Name;
                                }
                            }

                        });
                        if (lim.Count > 0)
                        {
                            if (reason == "Realtime")
                            {
                                logupd = () =>
                                {
                                    logDictionary = new Dictionary<string, object>();
                                    foreach (IMeasurement mea in namem.Keys)
                                    {
                                        string n = namem[mea];
                                        logDictionary[n] = mea.Parameter();
                                    }
                                    log.Write(logDictionary, DateTime.Now);
                                };
                            }
                        }
                    }

                    if (collections.Count == 1)
                    {
                        IDifferentialEquationProcessor pr = CreateProcessor(collection);
                        double[] dt = new double[1];
                        bool find = (reason.Equals(StaticExtensionEventInterfaces.Realtime) |
                            reason.Equals(StaticExtensionEventInterfaces.RealtimeLogAnalysis));
                        collection.ForEach((IRealtimeUpdate ru) => { lr.Add(ru); }, find);
                        collection.ForEach((IEvent ev) =>
                            {
                                IComponentCollection cc = CreateCollection(ev);
                                if (!realTimeData.ContainsKey(cc))
                                {
                                    List<IRealtimeUpdate> lru = new List<IRealtimeUpdate>();
                                    cc.ForEach((IRealtimeUpdate rud) => { lru.Add(rud); }, find);
                                    IDataRuntime drc = Copy(cc);
                                    double[] dtt = new double[1];
                                    Action actp = CreateAction(drc, dtt, pr, logupd, lru.ToArray());
                                    realTimeData[cc] =
                                        new Tuple<IDataRuntime, double[], IDifferentialEquationProcessor, Action>
                                        (drc, dtt, pr, actp);
                                }
                            });
                    }
                    else
                    {
                        foreach (IComponentCollection coll in collections)
                        {
                            List<IRealtimeUpdate> lu = new List<IRealtimeUpdate>();
                            foreach (object o in coll.AllComponents)
                            {
                                if (o is IObjectLabel)
                                {
                                    IRealtimeUpdate ru = (o as IObjectLabel).Object.GetObject<IRealtimeUpdate>();
                                    if (ru != null)
                                    {
                                        lu.Add(ru);
                                    }
                                }
                            }
                            IDataRuntime rt = Copy(coll);
                            IDifferentialEquationProcessor pr = CreateProcessor(collection);
                            double[] dt = new double[1];
                            Action act = CreateAction(rt, dt, pr, null, lr.ToArray());
                            realTimeData[coll] = new Tuple<IDataRuntime, double[], IDifferentialEquationProcessor, Action>
                                (rt, dt, pr, act);
                        }
                    }
                    if (realtime is IRealtimeUpdate)
                    {
                        (realtime as IRealtimeUpdate).Update();
                    }
                    startRuntime = provider.Time;
                    foreach (Tuple<IDataRuntime, double[], IDifferentialEquationProcessor, Action> t in realTimeData.Values)
                    {
                        t.Item2[0] = startRuntime;
                    }
                    collection.ForEach<IStarted>((IStarted st) => { st.Start(startRuntime); });
                }
            }
        }

        #endregion

        #region IDataPerformerRuntime Members

        /// <summary>
        /// Refreshes itself
        /// </summary>
        void IDataRuntime.Refresh()
        {
            Prepare();
        }

        /// <summary>
        /// Starts all components
        /// </summary>
        /// <param name="time">Start time</param>
        public virtual void StartAll(double time)
        {
            provider.Time = time;
            List<IStarted> ls = new List<IStarted>();
            collection.ForEach<IStarted>((IStarted s) => { ls.Add(s); s.Start(time); });
            IStep st = this;
            st.Step = -1;
            IDifferentialEquationProcessor pr = DifferentialEquationProcessor.Processor;
            if (pr == null)
            {
                return;
            }
            ICollection<IDifferentialEquationSolver> de = pr.Equations;
            foreach (IDifferentialEquationSolver deq in de)
            {
                if (deq is IStarted)
                {
                    IStarted s = deq as IStarted;
                    if (!ls.Contains(s))
                    {
                        s.Start(time);
                    }
                }
            }
            dynamical.ForEach((IDynamical dyn) => { dyn.Time = time; });
        }


        /// <summary>
        /// Updates all components
        /// </summary>
        public virtual void UpdateAll()
        {
            updateAll();
        }

        /// <summary>
        /// Checks data consumer. Throws exceptions in case of fail
        /// </summary>
        /// <param name="dataConsumer">The data consumer</param>
        public virtual void Check(IDataConsumer dataConsumer)
        {

        }

        /// <summary>
        /// Gets differential solver from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The solver</returns>
        public virtual IDifferentialEquationSolver GetDifferentialEquationSolver(object obj)
        {
            return null;
        }

        double IDataRuntime.Time
        {
            get
            {
                return provider.Time;
            }
            set
            {
                provider.Time = value;
                dynamical.ForEach((IDynamical dyn) => { dyn.Time = value; });
            }
        }

        ITimeMeasurementProvider IDataRuntime.TimeProvider
        {
            get { return provider; }
            set { provider = value; }
        }

        IEnumerable<object> IDataRuntime.AllComponents
        {
            get { return collection.AllComponents; }
        }

        #endregion

        #region IStep Members

        long IStep.Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
                steps.ForEach((IStep s) => { s.Step = value; });
            }
        }

        #endregion

        #region IActionFactory Members

        Action IActionFactory.this[IEvent ev]
        {
            get { return GetAction(ev); }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            ClearAll();
        }

        #endregion

        #region Members

        /// <summary>
        /// Prepares itself
        /// </summary>
        protected virtual void Prepare()
        {
            ClearAll();
            prepareAll(collection);
            IEnumerable<object> comp = collection.AllComponents;
            foreach (object o in comp)
            {
                IUpdatableObject up = o.GetLabelObject<IUpdatableObject>();
                if (up == null)
                {
                    continue;
                }
                if (up is IDynamical)
                {
                    continue;
                }
                if (up.ShouldUpdate)
                {
                    if (up.SatisfiesReason(reason))
                    {
                        if (up.Update != null)
                        {
                            updatable.Add(up.Update);
                        }
                    }
                }
            }
            foreach (object obj in comp)
            {
                IDynamical dyn = obj.GetLabelObject<IDynamical>();
                if (dyn == null)
                {
                    continue;
                }
                dynamical.Add(dyn);
            }
            collection.ForEach<IMeasurements>(

                (IMeasurements m) => { measurements.Add(m); }
                );
            collection.ForEach<IStep>((IStep s) => { steps.Add(s); });
            if (updatable.Count == 0)
            {
                updateAll = UpdateMeasurements;
            }
            else
            {
                updateAll = () =>
                {
                    UpdateMeasurements();
                    foreach (Action up in updatable)
                    {
                        up();
                    }
                    UpdateMeasurements();
                };
            }
            measurements.SortMeasurements();
        }

        /// <summary>
        /// Clears all components
        /// </summary>
        protected virtual void ClearAll()
        {
            if (components != null)
            {
                components.Clear();
            }
            if (objects != null)
            {
                objects.Clear();
            }
            if (arrows != null)
            {
                arrows.Clear();
            }
            updatable.Clear();
            dynamical.Clear();
            measurements.Clear();
            steps.Clear();
            GC.Collect();
        }

        /// <summary>
        /// Updates measurements
        /// </summary>
        protected void UpdateMeasurements()
        {
            foreach (IMeasurements m in measurements)
            {
                m.IsUpdated = false;
                m.UpdateMeasurements();
            }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Creates action
        /// </summary>
        /// <param name="ev">Event</param>
        /// <returns>Action</returns>
        protected virtual Action GetAction(IEvent ev)
        {
            IComponentCollection cc = dCollection[ev];
            return realTimeData[cc].Item4;
        }

        /// <summary>
        /// Copy itself to collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <returns>Copy</returns>
        protected virtual IDataRuntime Copy(IComponentCollection collection)
        {
            if (collection == this.collection)
            {
                return this;
            }
            return new DataRuntime(collection, reason, priority + 1, null, realtimeStep);
        }

        /// <summary>
        /// Creates processor
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        protected virtual IDifferentialEquationProcessor CreateProcessor(IComponentCollection collection)
        {
            IDifferentialEquationProcessor pr = null;
            collection.ForEach((IDifferentialEquationSolver s) =>
                {
                    if (pr == null)
                    {
                        pr = DifferentialEquationProcessor.Processor.New;
                        pr.Set(collection);
                    }
                });
            if (realtime != null & pr != null)
            {
                pr.TimeProvider = realtime;
            }
            return pr;
        }

        /// <summary>
        /// Creates action
        /// </summary>
        /// <param name="runtime">Runtime</param>
        /// <param name="time">Time</param>
        /// <param name="processor">processor</param>
        /// <param name="action">Action</param>
        /// <param name="update">Update objects</param>
        /// <returns>Action</returns>
        protected virtual Action CreateAction(IDataRuntime runtime, double[] time,
            IDifferentialEquationProcessor processor, Action action, IRealtimeUpdate[] update)
        {
            ITimeMeasurementProvider rt = realtime;
            double[] t = new double[1];
            Action<double> setTime = (double a) => { };
            Action<double, double, long> act = runtime.Step(processor, setTime,
                StaticExtensionEventInterfaces.Realtime, null);
            long[] st = new long[] { 0 };

            Action updList = null;
            foreach (IRealtimeUpdate upd in update)
            {
                Action actp = upd.Update;
                if (actp == null)
                {
                    continue;
                }
                if (act != null)
                {
                    if (updList == null)
                    {
                        updList = actp;
                        continue;
                    }
                    updList = updList + actp;
                }
            }
            if (action != null)
            {
                updList = updList + action;
            }
            if (updList == null)
            {
                updList = action;
            }
            if (updList == null)
            {
                updList = () => { };
            }

            //  Action[] updateActions = updlist.ToArray();
            object loc = new object();
            Action updatel = null;
            if (realtime is IRealtimeUpdate)
            {
                updatel = (realtime as IRealtimeUpdate).Update;
            }
            if (realtimeStep == null)
            {

                Action acttt = () =>
                     {
                         // !!! REPLACED WITH GLOBAL LOCKER  lock(locker)
                         // {

                         t[0] = rt.Time;
                         if (time[0] == t[0])
                         {
                             return;
                         }
                         act(time[0], t[0], st[0]);
                         time[0] = t[0];
                         st[0] += 1;
                         updList();
                         //}
                     };
                return (updatel == null) ? acttt : updatel + acttt;
            }
            else
            {
                Action<double> acti;

                acti = (double arg) =>
                {
                    realtimeStep.Start(arg);
                    acti = realtimeStep.Step;
                };

                Action actt = () =>
                {
                    t[0] = rt.Time;
                    act(time[0], t[0], st[0]);
                    time[0] = t[0];
                    st[0] += 1;
                    updList();
                    acti(t[0]);

                };
                if (updatel != null)
                {
                    actt = updatel + actt;
                }

                return () =>
                {
                  lock (realtime)
                  {
                      actt();
                  }
                };

            }
        }

        #endregion

        #region Private Members

        IComponentCollection CreateCollection(IEvent ev)
        {
            IComponentCollection cc = dCollection[ev];
            List<IEventBlock> bl = new List<IEventBlock>();
            cc.ForEach<IEventBlock>((IEventBlock block) =>
                {
                    if (block[ev])
                    {
                        bl.Add(block);
                    }
                });
            if (bl.Count == 0)
            {
                return cc;
            }
            IDesktop d = cc.Desktop;
            List<object> l = new List<object>();
            foreach (object o in bl)
            {
                if (!l.Contains(bl))
                {
                    l.Add((o as IAssociatedObject).Object);
                }
                Func<ICategoryObject, bool> fca = (ICategoryObject cao) => { return true; };
                Func<ICategoryArrow, bool> fcar = (ICategoryArrow car) => { return true; };
                List<ICategoryObject> cl = (o as ICategoryObject).GetSourceObjects(fca, fcar, fcar);
                foreach (ICategoryObject co in cl)
                {
                    object ob = co.Object;
                    if (!l.Contains(ob))
                    {
                        l.Add(ob);
                    }
                }
            }
            IEnumerable<object> en = cc.AllComponents;
            List<object> ls = new List<object>();
            foreach (object oo in en)
            {
                if (oo is IArrowLabel)
                {
                    IArrowLabel al = oo as IArrowLabel;
                    if (l.Contains(al.Source) | l.Contains(al.Target))
                    {
                        continue;
                    }
                }
                if (!l.Contains(oo))
                {
                    ls.Add(oo);
                }
                else
                {
                }
            }
            ComponentCollection ccl = new ComponentCollection(ls, d);
            dCollection[ev] = ccl;
            return ccl;
        }

        /// <summary>
        /// Preparation
        /// </summary>
        /// <param name="collection">Desktop</param>
        private void prepareAll(IComponentCollection collection)
        {
            components.Clear();
            components.AddRange(collection.AllComponents);
            collection.ForEach<ICategoryObject>((ICategoryObject l) => { objects.Add(l); });
            arrows.Clear();
            collection.ForEach<ICategoryArrow>((ICategoryArrow l) => { arrows.Add(l); });
            IDifferentialEquationProcessor processor = DifferentialEquationProcessor.Processor;
        }

        #endregion

    }
}
