using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Link between visible object and its consumer
    /// </summary>
    [Serializable()]
    public class VisibleConsumerLink : ICategoryArrow, ISerializable, IRemovableObject, IPostSerialize
    {

        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        protected object obj;

        /// <summary>
        /// Consumer
        /// </summary>
        protected IVisibleConsumer source;
 

        /// <summary>
        /// Visible object
        /// </summary>
        protected IVisible target;

 

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VisibleConsumerLink()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected VisibleConsumerLink(SerializationInfo info, StreamingContext context)
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
                if (!(value is IPosition))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                IPosition p = value as IPosition;
                if (value is IVisibleConsumer)
                {
                    source = value as IVisibleConsumer;
                    return;
                }
                if (p.Parameters == null)
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                object o = p.Parameters;
                if (!(o is IVisibleConsumer))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                source = o as IVisibleConsumer;
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
                if (value is IPosition)
                {
                    IPosition p = value as IPosition;
                    if (p.Parameters == null)
                    {
                        CategoryException.ThrowIllegalSourceException();
                    }
                    object o = p.Parameters;
                    if (o is IVisible)
                    {
                        target = o as IVisible;
                        source.Add(target);
                    }
                }
                else
                {
                    CategoryException.ThrowIllegalTargetException();
                }
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

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region IRemovableObject Members

        /// <summary>
        /// Removing of VisibleConsumerLink
        /// </summary>
        void IRemovableObject.RemoveObject()
        {
                source.Remove(target);
        }

        #endregion

        #region IPostSerialize Members

        void IPostSerialize.PostSerialize()
        {
            source.Post(target);
        }

        #endregion


   /*!!!FICTION
        void Fiction()
        {
            IVisible visible = null;
            IVisibleConsumer consumer = null;
            ICategoryArrow link = new VisibleConsumerLink();
            link.Source = consumer as ICategoryObject;
            link.Target = visible as ICategoryObject;

            consumer.Add(visible);
            
        }
    */


    }
}
