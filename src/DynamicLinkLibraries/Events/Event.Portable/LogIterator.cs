using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI;

using BaseTypes.Attributes;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Interfaces.Attributes;

using NamedTree;

namespace Event.Portable
{
    /// <summary>
    /// Iterator of log
    /// </summary>
    [IteratorType(log: true)]
    public  class LogIterator : CategoryObject, IAddRemove,  IIterator, ICalculationReason
    {

        #region Fields

        IDataConsumer consumer;

        IEnumerator<object> enumerator;

        protected bool isDirectoryOriented = false;

        event Action<object> IChildren<object>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<object> IChildren<object>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region IAddRemove Members

        void IChildren<object>.AddChild(object obj)
        {
            if (consumer != null)
            {
                throw new ErrorHandler.OwnException("Object already exists");
            }
            if (!(obj is IDataConsumer))
            {
                throw new ErrorHandler.OwnException("Target shuold be a Data consumer");
            }
            consumer = obj as IDataConsumer;
        }

        void IChildren<object>.RemoveChild(object obj)
        {
            if (obj != consumer)
            {
                throw new ErrorHandler.OwnException("Illegal");
            }
            consumer = null;
        }

        Type IAddRemove.Type
        {
            get { return typeof(object); }
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
            var enu = Create(consumer);
            enumerator = enu.GetEnumerator();
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

        IEnumerable<object> IChildren<object>.Children => [consumer];

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
            desktop.ForEach((Diagram.UI.Portable.BelongsToCollection b) =>
            {
                ICategoryArrow a = b;
                var s = a.Source;
                var t = a.Target;
                if (s == consumer)
                {
                    if (t is LogHolder llh)
                    {
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
