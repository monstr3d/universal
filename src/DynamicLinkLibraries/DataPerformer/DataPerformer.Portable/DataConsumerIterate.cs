using System;

using DataPerformer.Interfaces;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Data consumer and iterator
    /// </summary>
    public class DataConsumerIterate : DataConsumer, IIteratorConsumer
    {
        #region Classes

        IIterator iterator;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of consumer</param>
        public DataConsumerIterate(int type) : base(type)
        {
        }

        #endregion

        #region IIteratorConsumer Members

        void IIteratorConsumer.Add(IIterator iterator)
        {
            if (iterator == null) throw new ArgumentNullException();
            if (this.iterator != null) throw new ArgumentException();
            this.iterator = iterator;
        }

        void IIteratorConsumer.Remove(IIterator iterator)
        {
            this.iterator = iterator;
        }

        #endregion

        #region Public Members

        public IIterator Iterator 
        {  get => iterator; } 

        #endregion
    }
}
