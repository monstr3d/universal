using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using SerializationInterface;
using NamedTree;

namespace Diagram.UI
{
    /// <summary>
    /// Wrapper of children object
    /// </summary>
    [Serializable()]
    public class ChildrenObjectWrapper : CategoryObject, ISerializable, IChildren<IAssociatedObject>
    {
        #region Fields

        IChildren<IAssociatedObject> wrappedObject;

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wrappedObject">Wrapped object</param>
        public ChildrenObjectWrapper(IChildren<IAssociatedObject> wrappedObject)
        {
            this.wrappedObject = wrappedObject;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ChildrenObjectWrapper(SerializationInfo info, StreamingContext context)
        {
            wrappedObject = info.Deserialize<IChildren<IAssociatedObject>>("Object");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<IChildren<IAssociatedObject>>("Object", wrappedObject);
        }

        #endregion

        #region IChildrenObject Members

    
        public IEnumerable<IAssociatedObject> Children => wrappedObject.Children;

        #endregion
    }
}
