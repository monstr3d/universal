using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Interfaces;


using Motion6D.Interfaces;

namespace Motion6D.Portable.Runtime
{
    /// <summary>
    /// Runtime of data consumer
    /// </summary>
    public class DataConsumerRuntime : DataPerformer.Portable.Runtime.DataConsumerRuntime
    {
        #region Fields

        /// <summary>
        /// Frames
        /// </summary>
        private List<IPosition> frames = new List<IPosition>();

        /// <summary>
        /// Started objects
        /// </summary>
        private List<IRuntimeUpdate> runtimeUpdate = new List<IRuntimeUpdate>();

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory">Factory</param>
        /// <param name="consumer">Data consumer</param>
        /// <param name="reason">Rerason</param>
        /// <param name="priority">Priority</param>
        public DataConsumerRuntime(IDataRuntimeFactory factory, IDataConsumer consumer, string reason,
            int priority) : base(factory, consumer, reason, priority)

        {

        }

        #endregion

        #region Protected

        /// <summary>
        /// Prepares itself
        /// </summary>
        protected override void Prepare()
        {
            ClearAll();
            IComponentCollection cc = factory.CreateCollection(consumer, 0, null);
            IEnumerable<object> en = cc.AllComponents;
            foreach (object o in en)
            {
                if (o is IRuntimeUpdate)
                {
                    runtimeUpdate.Add(o as IRuntimeUpdate);
                }
                if (o is IDataConsumer)
                {
                    IDataConsumer dc = o as IDataConsumer;
                    for (int i = 0; i < dc.Count; i++)
                    {
                        IMeasurements m = dc[i];
                        if (m is RelativeMeasurements)
                        {
                            RelativeMeasurements rm = m as RelativeMeasurements;
                            AddFrameDependent(rm.Source);
                            AddFrameDependent(rm.Target);
                        }
                        if (m is IRuntimeUpdate)
                        {
                            IRuntimeUpdate st = m as IRuntimeUpdate;
                            if (!st.ShouldRuntimeUpdate)
                            {
                                if (!runtimeUpdate.Contains(st))
                                {
                                    runtimeUpdate.Add(st);
                                }
                            }
                        }
                    }
                }
                if (o is IPosition)
                {
                   frames.Add(o as IPosition);
                }
                if (o is IMeasurements)
                {
                    IMeasurements m = o as IMeasurements;
                    if (!measurements.Contains(m))
                    {
                        measurements.Add(m);
                    }
                }
                if (o is IStep)
                {
                    steps.Add(o as IStep);
                }
                if (o is IUpdatableObject)
                {
                    IUpdatableObject up = o as IUpdatableObject;
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
            }
            foreach (object obj in en)
            {
                if (obj is IDynamical)
                {
                    IDynamical dyn = obj as IDynamical;
                    if (dyn == null)
                    {
                        continue;
                    }
                    dynamical.Add(dyn);
                }
            }
            measurements.SortMeasurements();
            updateAll = null;
            Action um = UpdateMeasurements;
            Action uu = () =>
            {
                foreach (Action up in updatable)
                {
                    up();
                }
    
            };
            Action upd = null;
            if (updatable.Count > 0)
            {    
                upd = () =>
                {
                    foreach (Action up in updatable)
                    {
                        up();
                    }
                };
                
            }
            frames.SortPositions();
            Action uf = null;
            if (frames != null)
            {
                if (frames.Count > 0)
                {
                    uf = () =>
                        {
                            frames.UpdateFrames();
                        };
                }
            }
            if (uf == null & upd == null)
            {
                updateAll = UpdateMeasurements;
            }
            else if (upd == null)
            {
                updateAll = UpdateMeasurements + uf;
            }
            else if (uf == null)
            {
                updateAll = UpdateMeasurements + upd + UpdateMeasurements;
            }
            else
            {
                updateAll = UpdateMeasurements + upd + uf + UpdateMeasurements + upd;
            }
        }

        /// <summary>
        /// Starts all components
        /// </summary>
        /// <param name="time">Start time</param>
        protected override void StartAll(double time)
        {
            provider.Time = time;
            List<IStarted> ls = new List<IStarted>();
            runtimeUpdate.ForEach((IStarted s) => { ls.Add(s); s.Start(time); });
            IStep st = this;
            st.Step = -1;
            IDifferentialEquationProcessor pr = 
                DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor;
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
        /// Clears all components
        /// </summary>
        protected override void ClearAll()
        {
            base.ClearAll();
            frames.Clear();
        }

        #endregion

        #region Private Members

        private void AddFrameDependent(IPosition p)
        {
            if (p is IDataConsumer)
            {
                AddDependent(p as IDataConsumer);
            }
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
            IDifferentialEquationProcessor processor = DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor;
        }

        private void GetMeasurements()
        {
            GetMeasurements(consumer);
            measurements.SortMeasurements();
        }

     
        #endregion
    }
}
