using System.Collections.Generic;

using DataPerformer.Interfaces;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Consumer of iterator
    /// </summary>
    public class IteratorConsumer : IIteratorConsumer
    {

        #region Fields

        /// <summary>
        /// Children iterators
        /// </summary>
        protected List<IIterator> iterators = new List<IIterator>();

        #endregion

        #region IIteratorConsumer Members

        void IIteratorConsumer.Add(IIterator iterator)
        {
            iterators.Add(iterator);
        }

        void IIteratorConsumer.Remove(IIterator iterator)
        {
            iterators.Remove(iterator); ;
        }

        #endregion
    }
}
