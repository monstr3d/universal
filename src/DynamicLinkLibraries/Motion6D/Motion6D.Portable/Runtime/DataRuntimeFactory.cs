using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using Event.Interfaces;

using Motion6D.Interfaces;
using NamedTree;

namespace Motion6D.Portable.Runtime
{
    /// <summary>
    /// Strategy of moved objects
    /// </summary>
    public class DataRuntimeFactory : DataPerformer.Portable.Runtime.DataRuntimeFactory 
    {
        /// <summary>
        /// Singleton
        /// </summary>
        new static public readonly DataRuntimeFactory Singleton = new DataRuntimeFactory();

 
        /// <summary>
        /// Constructor
        /// </summary>
        protected DataRuntimeFactory()
        {
            DataPerformer.Portable.StaticExtensionDataPerformerPortable.MeasurementsComparer = 
                Comparation.MeasurementsComparer.Singleton;
        }

        #region Overriden Members

        #region Public Members



        #region IActionFactoryCreator Members

        /// <summary>
        /// Creates action from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The action</returns>
        public override IActionFactory this[object obj]
        {
            get
            {
                if (obj is Tuple<IComponentCollection, ITimeMeasurementProvider, IAsynchronousCalculation>)
                {
                    Tuple<IComponentCollection, ITimeMeasurementProvider, IAsynchronousCalculation> tuple = obj as
                                 Tuple<IComponentCollection, ITimeMeasurementProvider, IAsynchronousCalculation>;
                    return new DataRuntime(tuple.Item1, StaticExtensionEventInterfaces.Realtime,
                        0, null, tuple.Item3, tuple.Item2);
                }
                if (obj is Tuple<string, Tuple<IDataConsumer, IComponentCollection, ITimeMeasurementProvider,
             IAsynchronousCalculation>>)
                {
                    Tuple<string, Tuple<IDataConsumer, IComponentCollection, ITimeMeasurementProvider,
             IAsynchronousCalculation>> tuple = obj as
                                 Tuple<string, Tuple<IDataConsumer, IComponentCollection, ITimeMeasurementProvider,
             IAsynchronousCalculation>>;
                    
                        return new DataRuntime(tuple.Item2.Item2, tuple.Item1,
                        0, tuple.Item2.Item1, tuple.Item2.Item4, tuple.Item2.Item3);
                }
                return null;

            }
        }

        #endregion
 
        /// <summary>
        /// Creates runtime from collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="priority">Priority</param>
        /// <returns>The runtime</returns>
        public override IDataRuntime Create(IComponentCollection collection, int priority, 
            string reason = StaticExtensionDataPerformerInterfaces.Calculation)
        {
            return new DataRuntime(collection, reason, priority);
        }

        /// <summary>
        /// Creates collection
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        /// <returns>Collection</returns>
        public override IComponentCollection CreateCollection(IDataConsumer consumer, int priority, string reason)
        {
            //var collection = base.CreateCollection(consumer, priority, reason);
            Func<ICategoryObject, bool> cond = (ICategoryObject obj) =>
            {
                if (obj is IRuntimeUpdate runtime)
                {
                    return runtime.ShouldRuntimeUpdate;
                }
                return true;
            };
            Func<ICategoryArrow, bool> ac = (ICategoryArrow a) => { return true; };
            Func<ICategoryArrow, bool> acs = null;
            if (reason != null)
            {
                if (reason.Equals(StaticExtensionEventInterfaces.Realtime)  | reason.Equals(StaticExtensionEventInterfaces.RealtimeLogAnalysis))
                {

                    acs = (ICategoryArrow a) =>
                    {
                        return ((a is RelativeMeasurementsLink) | (a is Event.Portable.Arrows.EventLink));
                    };
                }
            }
            if (acs == null)
            {
                acs = (ICategoryArrow a) => { return (a is RelativeMeasurementsLink); };
            }
            List<ICategoryObject> comp = new ();
            (consumer as ICategoryObject).GetDependentObjects(cond, ac, acs, comp);
            List<object> l = new ();
            IEnumerable<ICategoryObject> ob = comp.ClearDoubleObjects();
            l.AddRange(ob);
            return new ComponentCollection(l, (consumer as ICategoryObject).GetRootDesktop());
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Creates runtime from data consumer
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        /// <returns>The runtime</returns>
        protected override IDataRuntime CreateRuntime(IDataConsumer consumer, int priority, string reason)
        {
            return new DataConsumerRuntime(this, consumer, reason, priority);
        }

        #endregion

        #endregion

        #region Specific Members

        private void Process(List<object> l, 
            List<RelativeMeasurements> rm, RelativeMeasurements m, int priority, string reason)
        {
            List<object> ladd = new List<object>();
            if (rm.Contains(m))
            {
                return;
            }
            rm.Add(m);
            Process(l, rm, m.Source, ladd, priority, reason);
            Process(l, rm, m.Target, ladd, priority, reason);
            foreach (object o in ladd)
            {
                if (!l.Contains(o))
                {
                    l.Add(o);
                }
            }
        }

        private void Process(List<object> l, List<RelativeMeasurements> rm, IPosition position, 
            List<object> ladd, int priority, string reason)
        {
            Action<object> act = (object obj) => { };
            if (position == null)
            {
                return;
            }
            IDataConsumer c = position.GetLabelObject<IDataConsumer>();
            if (c != null)
            {
                if (c is IAssociatedObject)
                {
                    IAssociatedObject ao = c as IAssociatedObject;
                    object o = ao.Object;
                    if (!ladd.Contains(o))
                    {
                        ladd.Add(o);
                    }
                }
                CreateDataConsumerCollection(c, ladd, act, priority, reason);
            }
            Process(l, rm, position.Parent, ladd, priority, reason);
        }


        #endregion


    }
}
