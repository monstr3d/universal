using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI.Interfaces;

using Motion6D.Interfaces;
using NamedTree;
using WpfInterface.Interfaces;

namespace WpfInterface.Objects3D
{
    /// <summary>
    /// WPF Visible collection
    /// </summary>
    [Serializable()]
    public class WpfVisibleCollectionObject : WpfVisibleCollection, ISerializable, ICategoryObject, IVisibleConsumer
    {

        #region Fields

        CategoryTheory.Performer performer = new();


        object obj;

        #region Add Remove Events

        /// <summary>
        /// Add event
        /// </summary>
        event Action<IVisible> onAdd = (IVisible v) => { };

        /// <summary>
        /// Remove event
        /// </summary>
        event Action<IVisible> onRemove = (IVisible v) => { };

        /// <summary>
        /// Post event
        /// </summary>
        event Action<IVisible> onPost = (IVisible v) => { };

        #endregion

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WpfVisibleCollectionObject()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected WpfVisibleCollectionObject(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
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

        string INamed.Name { get => performer.GetAssociatedName(this); set =>new  ErrorHandler.WriteProhibitedException(); }

        #endregion

        #region IVisibleConsumer Members

        void IVisibleConsumer.Add(IVisible visible)
        {
            collection.Add(visible.Position);
            onAdd(visible);
        }

        void IVisibleConsumer.Remove(IVisible visible)
        {
            collection.Remove(visible.Position);
            onRemove(visible);
        }

        void IVisibleConsumer.Post(IVisible visible)
        {
             onPost(visible);
        }

        event Action<IVisible> IVisibleConsumer.OnAdd
        {
            add { onAdd += value; }
            remove { onAdd -= value; }
        }

        event Action<IVisible> IVisibleConsumer.OnRemove
        {
            add { onRemove += value; }
            remove { onRemove -= value; }
        }

        event Action<IVisible> IVisibleConsumer.OnPost
        {
            add { onPost += value; }
            remove { onPost -= value; }
        }

        #endregion
    }
}
