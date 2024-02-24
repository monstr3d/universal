using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI;

using BaseTypes.Attributes;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace Event.Portable
{
    /// <summary>
    /// Iterator of log
    /// </summary>
    public  class LogIterator : CategoryObject, IAddRemove,  IIterator, ICalculationReason
    {

        #region Fields

        IDataConsumer consumer;

        IEnumerator<object> enumerator;

        protected bool isDirectoryOriented = false;

        #endregion

        #region IAddRemove Members

        void IAddRemove.Add(object obj)
        {
            if (consumer != null)
            {
                throw new Exception("Object already exists");
            }
            if (!(obj is IDataConsumer))
            {
                throw new Exception("Target shuold be a Data consumer");
            }
            consumer = obj as IDataConsumer;
        }

        void IAddRemove.Remove(object obj)
        {
            if (obj != consumer)
            {
                throw new Exception("Illegal");
            }
            consumer = null;
        }

        Type IAddRemove.Type
        {
            get { return typeof(object); }
        }

        event Action<object> IAddRemove.AddAction
        {
            add { }
            remove { }
        }

        event Action<object> IAddRemove.RemoveAction
        {
            add { }
            remove { }
        }

        #endregion

        #region ICalculationReason Members

        string ICalculationReason.CalculationReason
        {
            get
            {
                return Event.Interfaces.StaticExtensionEventInterfaces.PureRealtimeLogAnalysis;
            }
            set
            {

            }
        }

        #endregion

        #region IIterator Members

        bool IIterator.Next()
        {
            return enumerator.MoveNext();
        }

        void IIterator.Reset()
        {
            enumerator = Create(consumer).GetEnumerator();
            enumerator.MoveNext();
        }

        #endregion


        #region Public Members

        /// <summary>
        /// Is directory oriented
        /// </summary>
        public bool IsDirectoryOriented
        {
            get
            {
                return isDirectoryOriented;
            }
            set
            {
                isDirectoryOriented = value;
            }
        }

        #endregion

        #region Virtual Members

        /// <summary>
        /// Creates enumerator
        /// </summary>
        /// <param name="consumer">The consumer</param>
        /// <returns>The enumerator</returns>
        protected virtual IEnumerable<object> Create(IDataConsumer consumer)
        {
            Func<object, bool> stop = (object o) => { return false; };
            IDesktop desktop = (consumer as IAssociatedObject).GetRootDesktop();
            object l = null;
            desktop.ForEach((BelongsToCollectionPortable b) =>
            {
                if (b.Source == consumer)
                {
                    object o = b.Target;
                    if (o is LogHolder)
                    {

                        LogHolder llh = o as LogHolder;
                        (llh as IAssociatedObject).Prepare(true);
                        l = llh.Reader;
                    }
                }
            });
            if (l != null)
            {
                string reason = Event.Interfaces.StaticExtensionEventInterfaces.PureRealtimeLogAnalysis;
                IComponentCollection collection = consumer.CreateCollection(reason);
                collection.ForEach((ICalculationReason r) => 
                {
                    r.CalculationReason = reason;
                });
                if (isDirectoryOriented)
                {
                    return consumer.RealtimeAnalysisEnumerableDirectory(l, stop, reason, TimeType.Second, false);
                }
                return consumer.RealtimeAnalysisEnumerable(l, stop,  reason, TimeType.Second, false);
            }
            return null;
        }

        #endregion

    }
}
