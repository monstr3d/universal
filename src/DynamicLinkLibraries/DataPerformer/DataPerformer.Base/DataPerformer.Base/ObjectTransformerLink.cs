using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI;
using DataPerformer.Interfaces;

namespace DataPerformer
{
    /// <summary>
    /// Link to object transformer
    /// </summary>
    [Serializable()]
    public class ObjectTransformerLink : ISerializable, ICategoryArrow, IRemovableObject
    {
        IObjectTransformer target;

        IObjectTransformerConsumer source;

        object obj;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ObjectTransformerLink()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ObjectTransformerLink(SerializationInfo info, StreamingContext context)
        {
        }

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
                return source as ICategoryObject;
            }
            set
            {
                 source = value.GetSource<IObjectTransformerConsumer>();
            }
        }

        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                target = value.GetTarget<IObjectTransformer>(); 
                source.Add(target);
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
            source.Remove(target);
        }

        #endregion
    }
}
