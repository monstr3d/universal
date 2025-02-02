using System;
using System.Runtime.Serialization;


namespace Motion6D
{
    /// <summary>
    /// Basic camera
    /// </summary>
    [Serializable()]
    public abstract class Camera : Portable.Camera, ISerializable
    {
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Camera()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Camera(SerializationInfo info, StreamingContext context)
        {

        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }

        #endregion

        #region Absrtract Members

        /// <summary>
        /// Dynamically adds visible
        /// </summary>
        /// <param name="position">Position of visible to add</param>
        public abstract void DynamicalAdd(SerializablePosition position);


        /// <summary>
        /// Dynamically removes visible
        /// </summary>
        /// <param name="position">Position of visible to add</param>
        public abstract void DynamicalRemove(SerializablePosition position);


        #endregion

    }
}
