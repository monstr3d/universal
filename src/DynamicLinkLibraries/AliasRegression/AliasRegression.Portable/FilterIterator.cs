using DataPerformer.Interfaces;

namespace Regression.Portable
{
    /// <summary>
    /// Iterator with filter
    /// </summary>
    public abstract class FilterIterator : DataIteratorConsumer, IIterator
    {
        
        #region IIterator Members

        void IIterator.Reset()
        {
            foreach (IIterator iterator in iterators)
            {
                iterator.Reset();
            }
        }

        bool IIterator.Next()
        {
            if (iterators.Count == 0)
            {
                return false;
            }
            while (true)
            {
                foreach (IIterator iterator in iterators)
                {
                    bool b = iterator.Next();
                    if (!b)
                    {
                        return false;
                    }
                }
                consumer.Reset();
                consumer.UpdateChildrenData();
                bool? n = AllowNext;
                if (n != null)
                {
                    if ((bool)n)
                    {
                        break;
                    }
                }
            }
            return true;
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// The "allow next" sign
        /// </summary>
        protected abstract bool? AllowNext
        {
            get;
        }

        #endregion
    }
}
