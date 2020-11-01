using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Motion6D.Aggregates
{
    /// <summary>
    /// Rigid body aggregate
    /// </summary>
    [Serializable]
    public class RigidBody : Portable.Aggregates.RigidBody, ISerializable
    {

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public RigidBody()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private RigidBody(SerializationInfo info, StreamingContext context)
            : this()
        {
            momentOfInertia = info.GetValue("MomentOfInertia", typeof(double[,])) as double[,];
            connections = info.GetValue("Connections", typeof(double[][])) as double[][];
            aliasNames = info.GetValue("AliasNames", typeof(Dictionary<int, string>)) as Dictionary<int,string>;
            inerialAccelerationStr  = info.GetValue("InerialAccelerationStr", typeof(string[])) as string[];
            forcesStr = info.GetValue("ForcesStr", typeof(string[])) as string[];
            mass = info.GetDouble("Mass");
            initialState = info.GetValue("InitialState", typeof(double[])) as double[];
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// Gets object data
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MomentOfInertia", momentOfInertia, typeof(double[,]));
            info.AddValue("Connections", connections, typeof(double[][]));
            info.AddValue("AliasNames", aliasNames, typeof(Dictionary<int, string>));
            info.AddValue("InerialAccelerationStr", inerialAccelerationStr, typeof(string[]));
            info.AddValue("ForcesStr", forcesStr, typeof(string[]));
            info.AddValue("Mass", mass);
            info.AddValue("InitialState", initialState, typeof(double[]));
        }

        #endregion



    }
}
