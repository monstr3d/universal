using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Helpers;

using Event.Interfaces;

namespace DataPerformer.Portable.Runtime
{
    /// <summary>
    /// Simplest runtime fatory
    /// </summary>
    public class DataRuntimeFactory : IDataRuntimeFactory, IActionFactoryCreator
    {
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected DataRuntimeFactory()
        {

        }

        #endregion

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly DataRuntimeFactory Singleton = new DataRuntimeFactory();

        private ITimeMeasurementProvider provider = new TimeMeasurementProvider();

        /// <summary>
        /// Check level
        /// </summary>
        protected int priority = 0;

        #endregion

        #region IDataPerformerRuntimeFactory Members

        /// <summary>
        /// Creates runtime from collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        /// <returns>The runtime</returns>
        public virtual IDataRuntime Create(IComponentCollection collection, int priority, string reason)
        {
            return new DataRuntime(collection, reason, priority);
        }

        IDataRuntime IDataRuntimeFactory.Create(IDataConsumer consumer, int priority, string reason)
        {
            return CreateRuntime(consumer, priority, reason);
        }

        /// <summary>
        /// Time provider
        /// </summary>
        ITimeMeasurementProvider IDataRuntimeFactory.TimeProvider
        {
            get { return provider; }
        }

        /// <summary>
        /// Creates collection
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        /// <returns>Collection</returns>
        public virtual IComponentCollection CreateCollection(IDataConsumer consumer, int priority, string reason)
        {
            Func<ICategoryObject, bool> cond = (ICategoryObject obj) =>
            {
                if (obj is IRuntimeUpdate)
                {
                    if (!(obj as IRuntimeUpdate).ShouldRuntimeUpdate)
                    {
                        return false;
                    }
                }
                return true;
            };
            Func<ICategoryArrow, bool> ac = (ICategoryArrow a) => { return true; };
            Func<ICategoryArrow, bool> acs = null;
            if (reason != null)
            {
                if (reason.Equals(StaticExtensionEventInterfaces.Realtime))
                {

                    acs = (ICategoryArrow a) =>
                    {
                        string s = a.GetType() + "";
                        return s.Contains("Event.Basic.Arrows.EventLink");
                    };
                }
            }
            if (acs == null)
            {
                //acs = (ICategoryArrow a) => { return (a is RelativeMeasurementsLink); };
            }

            List<ICategoryObject> comp = new List<ICategoryObject>();
            (consumer as ICategoryObject).GetDependentObjects(cond, ac, acs, comp);
            List<object> l = new List<object>();
            IEnumerable<ICategoryObject> ob = comp.ClearDoubleObjects();
            l.AddRange(ob);
            return new ComponentCollection(l, (consumer as ICategoryObject).GetRootDesktop());
        }

        /// <summary>
        /// Level of check
        /// </summary>
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }


        Action<double> IDataRuntimeFactory.GetStart(IDataConsumer consumer)
        {
            return UpdateStatredAction(consumer);
        }

        Action IDataRuntimeFactory.UpdateDependent(IDataConsumer consumer)
        {
            return UpdateDependentAction(consumer); 
        }

        #endregion

        #region IActionFactoryCreator Members

        /// <summary>
        /// Creates action from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The action</returns>
        public virtual IActionFactory this[object obj]
        {
            get
            {
                if (obj is Tuple<IComponentCollection, ITimeMeasurementProvider>)
                {
                    Tuple<IComponentCollection, ITimeMeasurementProvider> tuple = obj as
                                 Tuple<IComponentCollection, ITimeMeasurementProvider>;
                    return new Runtime.DataRuntime(tuple.Item1, StaticExtensionEventInterfaces.Realtime,
                        0);
                }
                Tuple<string, Tuple<IDataConsumer, IComponentCollection, ITimeMeasurementProvider, IAsynchronousCalculation>> t = obj as
                    Tuple<string, Tuple<IDataConsumer, IComponentCollection, ITimeMeasurementProvider, IAsynchronousCalculation>>;
                Tuple < IDataConsumer, IComponentCollection, ITimeMeasurementProvider, IAsynchronousCalculation > tt = t.Item2;
                return new DataRuntime(tt.Item2, t.Item1, 0, tt.Item1, tt.Item4, tt.Item3);
            }
        }

        #endregion
 
        #region Specific Members


        #region Public Members
        
        /// <summary>
        /// Gets differential equation solver from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The solver</returns>
        public virtual IDifferentialEquationSolver GetDifferentialEquationSolver(object obj)
        {
            return null;
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Updates started action
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <returns>Action</returns>
        protected virtual Action<double> UpdateStatredAction(IDataConsumer consumer)
        {
            List<IMeasurements> lm = new List<IMeasurements>();
            List<object> l = new List<object>();
            consumer.GetDependent(l, lm);
         List<IStarted> ls = new List<IStarted>();
         foreach (object o in l)
         {
             if (o is IStarted)
             {
                 ls.Add(o as IStarted);
             }
         }
             return (double t) =>
                 {
                     foreach (IStarted s in ls)
                     {
                         s.Start(t);
                     }
                 };
         }

        /// <summary>
        /// Updates dependent action
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <returns>Action</returns>
        protected virtual Action UpdateDependentAction(IDataConsumer consumer)
        {
            List<object> l = new List<object>();
            List<IMeasurements> lm = new List<IMeasurements>();
            consumer.GetDependent(l, lm);
            return () =>
            {
                foreach (IMeasurements m in lm)
                {
                    m.IsUpdated = false;
                    m.UpdateMeasurements();
                }
            };
        }


        /// <summary>
        /// Creates component collection
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="list">List of objects</param>
        /// <param name="action">Action</param>
        /// <param name="priority">Priorty</param>
        /// <param name="reason">Reason</param>
        /// <returns>Component collection</returns>
        protected IComponentCollection CreateCollection(IDataConsumer consumer, List<object> list, 
            Action<object> action, int priority, string reason)
        {
            CreateDataConsumerCollection(consumer, list, action, priority, reason);
            IDesktop desktop = (consumer as IAssociatedObject).GetDesktop();
            return new ComponentCollection(list, desktop);
       }

        /// <summary>
        /// Creates collection of components
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="list">List of objects</param>
        /// <param name="action">Additional acton</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        /// <returns>Collection of components</returns>
        protected void CreateDataConsumerCollection(IDataConsumer consumer, List<object> list, 
            Action<object> action, int priority, string reason)
        {
            IList<object> ll = consumer.GetDependentObjects();
            foreach (object o in ll)
            {
                if (o is INamedComponent)
                {
                    action(o);
                    if (!list.Contains(o))
                    {
                        list.Add(o);
                    }
                    continue;
                }
                if (o is IAssociatedObject)
                {
                    IAssociatedObject ao = o as IAssociatedObject;
                    object ob = ao.Object;
                    action(ob);
                    if (ob is INamedComponent)
                    {
                        if (!list.Contains(ob))
                        {
                           list.Add(ob);
                        }
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Creates runtime from data consumer
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="priority">Priority</param>
        /// <param name="reason">Reason</param>
        /// <returns>The runtime</returns>
        protected virtual IDataRuntime CreateRuntime(IDataConsumer consumer, int priority, string reason)
        {
            return new DataConsumerRuntime(this, consumer, reason);
        }
        
        #endregion

        #endregion


   }
}
