
using CategoryTheory;
using DataPerformer.Interfaces;
using NamedTree;
using System;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Link to iterator consumer
    /// </summary>
    public class IteratorConsumerLink : ICategoryArrow, IDisposable
    {
        #region Fields

        protected object obj;

        protected IIterator iterator;

        protected IIteratorConsumer consumer;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public IteratorConsumerLink()
        {
        }


        #endregion



        #region ICategoryArrow Members

        ICategoryObject ICategoryArrow.Source
        {
            get
            {
                return consumer as ICategoryObject;
                
            }
            set
            {
               consumer = value.GetSource<IIteratorConsumer>();
            }
        }

        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                return iterator as ICategoryObject;
            }
            set
            {
                iterator =  value.GetTarget<IIterator>();
                consumer.Add(iterator);
            }
        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                return obj;
            }
            set
            {
               obj = value;
            }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            consumer.Remove(iterator);
        }

        #endregion
    }
}
