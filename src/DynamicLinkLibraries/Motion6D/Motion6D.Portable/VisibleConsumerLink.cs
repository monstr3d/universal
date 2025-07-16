using CategoryTheory;
using Diagram.UI.Interfaces;
using Motion6D.Interfaces;
using NamedTree;
using System;

namespace Motion6D.Portable
{
    /// <summary>
    /// Link between visible object and its consumer
    /// </summary>
    public class VisibleConsumerLink : ICategoryArrow, IDisposable, IPostSerialize, IAllowCodeCreation
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

        bool IAllowCodeCreation.AllowCodeCreation => false;

        #endregion

        #region IDisposale Members

        /// <summary>
        /// Removing of VisibleConsumerLink
        /// </summary>
        void IDisposable.Dispose()
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
