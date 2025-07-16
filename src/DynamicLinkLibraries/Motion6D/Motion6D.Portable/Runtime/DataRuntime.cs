using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using Motion6D.Interfaces;
using NamedTree;

namespace Motion6D.Portable.Runtime
{
    /// <summary>
    /// Runtime for 6D motion
    /// </summary>
    public class DataRuntime : DataPerformer.Portable.Runtime.DataRuntime
    {
        #region Fields

        protected Performer p = new Performer();

        /// <summary>
        /// Frames
        /// </summary>
        private List<IPosition> Frames
        {
            get;
            set;
        } = new List<IPosition>();

        /// <summary>
        /// Collection of additional solvers
        /// </summary>
        private ICollection<IDifferentialEquationSolver> coll = null;


        private Dictionary<AggregableWrapper, MechanicalAggregateEquation> mechanicalEquationsOld
            = new ();

        private Dictionary<AggregableWrapper, MechanicalAggregateEquation> mechanicalEquationsNew
            = new ();

        private Action updateInternal;

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
             : base(collection, reason, priority, dataConsumer, realtimeStep, realtime)
        {
            updateInternal = base.UpdateAll;
            foreach (IPosition p in collection.GetObjectsAndArrows<IPosition>())
            {
                updateInternal = UpdateWithFrames;
                break;
            }
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Creates processor
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <returns>Processor</returns>
        protected override IDifferentialEquationProcessor CreateProcessor(IComponentCollection collection)
        {
            IDifferentialEquationProcessor pr = base.CreateProcessor(collection);
            IDifferentialEquationProcessor p = pr;
            if (p == null)
            {
                p = DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor.New;
                p.Set(collection);
            }
            if (realtime != null & p != null)
            {
                p.TimeProvider = realtime;
            }
            mechanicalEquationsNew = new Dictionary<AggregableWrapper, MechanicalAggregateEquation>();
            List<IDifferentialEquationSolver> lds = new List<IDifferentialEquationSolver>();
            IEnumerable<object> oll = collection.AllComponents;
            if (p != null)
            {
                MechanicalAggregateEquation.GetSolvers(mechanicalEquationsNew, oll);
                List<IDifferentialEquationSolver> ss =
                    new List<IDifferentialEquationSolver>();
                foreach (MechanicalAggregateEquation wr in mechanicalEquationsNew.Values)
                {
                    ss.Add(wr);
                }
                lds.AddRange(ss);
            }
            foreach (MechanicalAggregateEquation eq in lds)
            {
                eq.Reset();
            }
            if (p != null)
            {
                p.AddRange(lds);
            }
            mechanicalEquationsOld = mechanicalEquationsNew;
            p.UpdateDimension();
            if (pr == null & lds.Count == 0)
            {
                return null;
            }
            return p;
        }


        /// <summary>
        /// Prepares itself
        /// </summary>
        protected override void Prepare()
        {
            base.Prepare();
            IDesktop d = collection.Desktop;
            Frames = ReferenceFrameArrow.Prepare(d);
            if (Frames.Count == 0)
            {
                updateInternal = base.UpdateAll;
            }
            else
            {
                updateInternal = UpdateWithFrames;
            }
        }

        /// <summary>
        /// Clears all components
        /// </summary>
        protected override void ClearAll()
        {
            Frames.Clear();
            if (coll != null)
            {
                coll.Clear();
            }

            mechanicalEquationsOld.Clear();
            mechanicalEquationsNew.Clear();
            base.ClearAll();
        }

        /// <summary>
        /// Starts all components
        /// </summary>
        /// <param name="time">Start time</param>
        public override void StartAll(double time)
        {
            base.StartAll(time);
            if (coll != null)
            {
                foreach (IDifferentialEquationSolver so in coll)
                {
                    if (so is IStarted)
                    {
                        IStarted s = so as IStarted;
                        s.Start(time);
                    }
                }
            }
            p.UpdateFrames(Frames);
            if (Frames.Count == 0)
            {
                updateInternal = base.UpdateAll;
            }
            else
            {
                updateInternal = UpdateWithFrames;
            }
        }

        /// <summary>
        /// Updates all components
        /// </summary>
        public override void UpdateAll()
        {
            updateInternal();
        }

        /// <summary>
        /// Checks data consumer. Throws exceptions in case of fail
        /// </summary>
        /// <param name="dataConsumer">The data consumer</param>
        public override void Check(IDataConsumer dataConsumer)
        {
            base.Check(dataConsumer);
        }

        /// <summary>
        /// Gets Differential Equation Solver from object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override IDifferentialEquationSolver GetDifferentialEquationSolver(object obj)
        {
            var s = obj.ToDifferentialEquationSolver();
            if (s != null)
            {
                return s;
            }
            if (obj is IAssociatedObject)
            {
                IAssociatedObject ao = obj as IAssociatedObject;
                AggregableWrapper agg =
                    ao.GetObject<AggregableWrapper>();
                if (agg != null)
                {
                    if (agg.Aggregate.Parent == null)
                    {
                        return GetEquation(agg);
                    }
                }
            }
            if (obj is MeasurementsWrapper)
            {
                MeasurementsWrapper m = obj as DataPerformer.Portable.MeasurementsWrapper;
                for (int i = 0; i < m.Count; i++)
                {
                    if (m[i] is AggregableWrapper)
                    {
                        AggregableWrapper agg =
                             m[i] as AggregableWrapper;
                        if (agg.Aggregate.Parent == null)
                        {
                            return GetEquation(agg);
                        }
                    }
                }
            }
            return null;

        }


        /// <summary>
        /// Copy itself to collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <returns>Copy</returns>
        protected override IDataRuntime Copy(IComponentCollection collection)
        {
            if (collection == this.collection)
            {
                return this;
            }
            return new DataRuntime(collection, reason, priority + 1, null, realtimeStep);
        }
  
        #endregion

        #region Private Members

        void UpdateWithFrames()
        {
            base.UpdateAll();
            p.UpdateFrames(Frames);
           // base.UpdateAll();
        }

        private MechanicalAggregateEquation GetEquation(AggregableWrapper agg)
        {
            if (mechanicalEquationsNew.ContainsKey(agg))
            {
                MechanicalAggregateEquation equ = mechanicalEquationsNew[agg];
                return equ;
            }
            if (mechanicalEquationsOld.ContainsKey(agg))
            {
                MechanicalAggregateEquation equ = mechanicalEquationsOld[agg];
                mechanicalEquationsNew[agg] = equ;
                return equ;
            }
            MechanicalAggregateEquation eq = MechanicalAggregateEquation.CreateAggregateEquation(agg);
            mechanicalEquationsNew[agg] = eq;
            return eq;
        }

        #endregion
    }
}
