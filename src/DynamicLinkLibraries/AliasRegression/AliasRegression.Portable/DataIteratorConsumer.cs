using System;
using System.Collections.Generic;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

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

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
            SetIterators();
        }

        void IDataConsumer.Remove(IMeasurements measurements)
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
