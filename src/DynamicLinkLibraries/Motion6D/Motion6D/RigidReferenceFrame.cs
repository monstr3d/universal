using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;

using Motion6D.Interfaces;

using Vector3D;
using Motion6D.Portable;

namespace Motion6D
{
    /// <summary>
    /// Rigid reference frame
    /// </summary>
    [Serializable()]
    public class RigidReferenceFrame : Portable.RigidReferenceFrame,  
        ISerializable, IPostSerialize
    {

 
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RigidReferenceFrame()
        {
            
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected RigidReferenceFrame(SerializationInfo info, StreamingContext context) :
            base(null)
        {
            relativePosition = info.GetValue("Position", typeof(double[])) as double[];
            relativeQuaternion = info.GetValue("Quaternion", typeof(double[])) as double[];
            IsSerialized = true;
            Init();
        }


        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Position", relativePosition, typeof(double[]));
            info.AddValue("Quaternion", relativeQuaternion, typeof(double[]));
        }

        #endregion

        #region IPostSerialize Members

        void IPostSerialize.PostSerialize()
        {
            IsSerialized = false;
        }

        #endregion


    }
}
