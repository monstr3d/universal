using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using SerializationInterface;

namespace Diagram.UI
{
    /// <summary>
    /// Wrapper of children object
    /// </summary>
    [Serializable()]
    public class ChildrenObjectWrapper : CategoryObject, ISerializable, IChildrenObject
    {
        #region Fields

        IChildrenObject wrappedObject;

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wrappedObject">Wrapped object</param>
        public ChildrenObjectWrapper(IChildrenObject wrappedObject)
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
            wrappedObject = info.Deserialize<IChildrenObject>("Object");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<IChildrenObject>("Object", wrappedObject);
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return wrappedObject.Children; }
        }

        #endregion
    }
}
