using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using DataPerformer.Interfaces;

namespace DataPerformer
{
    /// <summary>
    /// Link to iterator consumer
    /// </summary>
    [Serializable()]
    public class IteratorConsumerLink : ISerializable, ICategoryArrow, IRemovableObject
    {
        #region Fields

        private object obj;

        IIterator iterator;

        IIteratorConsumer consumer;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public IteratorConsumerLink()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private IteratorConsumerLink(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
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

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            consumer.Remove(iterator);
        }

        #endregion
    }
}
