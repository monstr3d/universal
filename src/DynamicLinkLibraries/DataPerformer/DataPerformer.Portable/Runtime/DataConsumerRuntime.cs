using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Helpers;
using DataPerformer.Portable;
using DataPerformer.Portable.Interfaces;
using DataPerformer.Portable.DifferentialEquationProcessors;

namespace DataPerformer.Portable.Runtime
{
    /// <summary>
    /// Runtime of data consumer
    /// </summary>
    public class DataConsumerRuntime : IDataRuntime, IStep
    {
        #region Fields

        /// <summary>
        /// Factory
        /// </summary>
        protected IDataRuntimeFactory factory;

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
        /// Step
        /// </summary>
        protected long step;

        /// <summary>
        /// Update action
        /// </summary>
        protected Action updateAll;

        /// <summary>
        /// State
        /// </summary>
        protected double[] state;

        /// <summary>
        /// Check level
        /// </summary>
        protected int priority = 0;

        /// <summary>
        /// Runtime factory
        /// </summary>
        protected IDataRuntimeFactory fartory;

        /// <summary>
        /// Time provider
        /// </summary>
        protected ITimeMeasurementProvider provider = new TimeMeasurementProvider();

        /// <summary>
        /// Data consumer
        /// </summary>
        protected IDataConsumer consumer;

        /// <summary>
        /// Collection of components
        /// </summary>
        IComponentCollection collection;

        /// <summary>
        /// Reason
        /// </summary>
        string reason;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory">Factory</param>
        /// <param name="consumer">Data consumer</param>
        /// <param name="reason">reason</param>
        /// <param name="priority">priority</param>
        public DataConsumerRuntime(IDataRuntimeFactory factory, IDataConsumer consumer, string reason,
            int priority = 0)
        {
            this.reason = reason;
            this.factory = factory;
            this.consumer = consumer;
            this.priority = priority;
            Prepare();
        }

        #endregion

        #region IDataRuntime Members

        void IDataRuntime.Refresh()
        {
            Prepare();
        }

        void IDataRuntime.StartAll(double time)
        {
            StartAll(time);
        }

        void IDataRuntime.UpdateAll()
        {
            updateAll();
        }

        void IDataRuntime.Check(IDataConsumer dataConsumer)
        {
        }

        IDifferentialEquationSolver IDataRuntime.GetDifferentialEquationSolver(object obj)
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
            get { return components; }
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

        #region Protected

        /// <summary>
        /// Adds update all action
        /// </summary>
        /// <param name="act"></param>
        protected void AddUpdateAll(Action act)
        {
            if (act == null)
            {
                return;
            }
            if (updateAll == null)
            {
                updateAll = act;
            }
            else
            {
                updateAll += act;
            }
        }



        /// <summary>
        /// Adds dependent objects
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        protected void AddDependent(IDataConsumer consumer)
        {
            if (consumer == this.consumer)
            {
                return;
            }
            DataConsumerRuntime rt = consumer.CreateRuntime(reason) as DataConsumerRuntime;
            List<IMeasurements> l = rt.measurements;
            for (int i = l.Count - 1; i >= 0; i--)
            {
                IMeasurements m = l[i];
                if (!measurements.Contains(m))
                {
                    measurements.Insert(0, m);
                }
            }
         }


        /// <summary>
        /// Starts all components
        /// </summary>
        /// <param name="time">Start time</param>
        protected virtual void StartAll(double time)
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
        /// Prepares itself
        /// </summary>
        protected virtual void Prepare()
        {
            ClearAll();
            collection = factory.CreateCollection(consumer, priority, null);
            prepareAll(collection);
            IEnumerable<object> comp = collection.AllComponents;
            GetMeasurements();
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
                    if (up.Update != null)
                    {
                        updatable.Add(up.Update);
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
            collection.ForEach<IStep>((IStep s) => { steps.Add(s); });
            AddUpdateAll(UpdateMeasurements);
            if (updatable.Count >= 0)
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

        #region Private Members

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
            IDifferentialEquationProcessor processor = 
                DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor;
        }

        private void GetMeasurements()
        {
            GetMeasurements(consumer);
            measurements.SortMeasurements();
        }

        /// <summary>
        /// Gets measurements of data consumer
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        protected virtual void GetMeasurements(IDataConsumer consumer)
        {
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                if (m is IRuntimeUpdate)
                {
                    if (!(m as IRuntimeUpdate).ShouldRuntimeUpdate)
                    {
                        continue;
                    }
                }
                if (measurements.Contains(m))
                {
                    continue;
                }
                measurements.Add(m);
                if (m is IDataConsumer)
                {
                    GetMeasurements(m as IDataConsumer);
                }
 
            }
        }

        #endregion

    }
}
