using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Aggregable Mechanical Object
    /// </summary>
    public interface IAggregableMechanicalObject
    {
        /// <summary>
        /// Number of degrees of freedom
        /// </summary>
        int Dimension
        {
            get;
        }


        /// <summary>
        /// Number of connections
        /// </summary>
        int NumberOfConnections
        {
            get;
        }

        /// <summary>
        /// State of object
        /// </summary>
        double[] State
        {
            get;
        }

        /// <summary>
        /// Internal acceleration
        /// </summary>
        double[] InternalAcceleration
        {
            get;
        }

        /// <summary>
        /// State of connection 
        /// x[0] - position, x[1] - quaternion, 
        /// x[2] - linear velocity, x[3] - angular velocity 
        /// </summary>
        /// <param name="numOfConnection">Number of connection</param>
        /// <returns>State of connection</returns>
        double[] this[int numOfConnection]
        {
            get;
            set;
        }

        /// <summary>
        /// Calculates transformation matrix from genrealized coordinates to
        /// acceleration of connection
        /// </summary>
        /// <param name="numOfConnection">Number of connection</param>
        /// <returns>The transformation matrix</returns>
        double[,] GetAccelerationMatrix(int numOfConnection);


        /// <summary>
        /// Gets matrix of forces
        /// </summary>
        /// <param name="numOfConnection">Number of connection</param>
        /// <returns>The matrix of forces</returns>
        double[,] GetForcesMatrix(int numOfConnection);

        /// <summary>
        /// Gets internal acceleration
        /// </summary>
        /// <param name="numOfConnection">Number of connection</param>
        /// <returns>Internal accceleration</returns>
        double[] GetInternalAcceleration(int numOfConnection);


        /// <summary>
        /// Gets connection force
        /// </summary>
        /// <param name="numOfConnection">Number of connection</param>
        /// <returns>Connection force</returns>
        double[] GetConnectionForce(int numOfConnection);


        /// <summary>
        /// Children objects
        /// </summary>
        Dictionary<IAggregableMechanicalObject, int[]> Children
        {
            get;
        }

        /// <summary>
        /// The is constant sign
        /// </summary>
        bool IsConstant
        {
            get;
        }

        /// <summary>
        /// Parent object
        /// </summary>
        IAggregableMechanicalObject Parent
        {
            get;
            set;
        }

    }
}