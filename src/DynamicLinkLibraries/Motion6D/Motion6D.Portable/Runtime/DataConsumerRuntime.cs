using System;
using System.Collections.Generic;

using CategoryTheory;

using BaseTypes;

using Diagram.UI;
using Diagram.UI.Interfaces;

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

        protected Performer p = new Performer();

        /// <summary>
        /// Frames
        /// </summary>
        private List<IPosition> Frames
        {
            get;
        }  
            = new List<IPosition>();

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

        #region Overriden


        #endregion

        #region Protected

        /// <summary>
        /// Prepares itself
        /// </summary>
        protected override void Prepare()
        {
            ClearAll();
            var cc = factory.CreateCollection(consumer, 0, null);
            List<Action> actions = new List<Action>();
            IEnumerable<object> en = cc.AllComponents;
            foreach (object o in en)
            {
                var sta = o.GetLabelObject<IStarted>();
                if (sta != null)
                {
                    if (!started.Contains(sta))
                    {
                        started.Add(sta);
                    }
                }
                if (o is IRuntimeUpdate rud)
                {
                    runtimeUpdate.Add(rud);
                }
                if (o is IDataConsumer dc)
                {
                    for (int i = 0; i < dc.Count; i++)
                    {
                        IMeasurements mm = dc[i];
                        if (mm is RelativeMeasurements rm)
                        {
                            AddFrameDependent(rm.Source);
                            AddFrameDependent(rm.Target);
                        }
                        if (mm is IRuntimeUpdate st)
                        {
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
                if (o is IPosition pos)
                {
                    Frames.Add(pos);
                }
                if (o is IMeasurements m)
                {
                    if (!measurements.Contains(m))
                    {
                        measurements.Add(m);
                    }
                }
                if (o is IStep step)
                {
                    steps.Add(step);
                }
                if (o is IUpdatableObject up)
                {
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
                        actions.Add(up.Update);
                    }
                }
            }
            foreach (object obj in en)
            {
                if (obj is IDynamical dyn)
                {
                    if (dyn == null)
                    {
                        continue;
                    }
                    dynamical.Add(dyn);
                }
            }
            measurements.SortMeasurements();
            p.SortPositions(Frames);
            actions.Add(UpdateMeasurements);
            if (Frames != null)
            {
                if (Frames.Count > 0)
                {
                    actions.Add(() =>  p.UpdateFrames(Frames));
                }
            }
            started.SortOrder();
            updateAll = actions.ToSingleAction();
        }

        /// <summary>
        /// Starts all components
        /// </summary>
        /// <param name="time">Start time</param>
        protected override void StartAll(double time)
        {
            Provider.Time = time;
            foreach (var sta in started) 
            { 
                sta.Start(time);
            }
            IStep st = this;
            st.Step = -1;
            IDifferentialEquationProcessor pr = 
                DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor.New;
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
                    if (!started.Contains(s))
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
            Frames.Clear();
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
