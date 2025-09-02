using System;
using System.Collections.Generic;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using NamedTree;

namespace Regression.Portable
{
    /// <summary>
    /// Consumer of iterator
    /// </summary>
    public class DataIteratorConsumer : IteratorConsumer, IDataConsumer
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        /// <summary>
        /// Measurements
        /// </summary>
        protected List<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// Consumer
        /// </summary>
        protected IDataConsumer consumer;
        
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected DataIteratorConsumer()
        {
            consumer = this;
        }

        #endregion

        #region IDataConsumer Members

        void IChildren<IMeasurements>.AddChild(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
            SetIterators();
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
            SetIterators();
        }

        void IDataConsumer.UpdateChildrenData()
        {
            foreach (IMeasurements m in measurements)
            {
                m.UpdateMeasurements();
            }
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurements[n]; }
        }

        void IDataConsumer.Reset()
        {
            this.FullReset();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }


        #endregion

        /// <summary>
        /// Sets all iterators
        /// </summary>
        protected void SetIterators()
        {
            iterators.Clear();
            this.GetIterators(iterators);
        }
    }
}
