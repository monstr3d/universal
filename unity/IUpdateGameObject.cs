using Motion6D.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Vector3D;

namespace Unity.Standard
{

    /// <summary>
    /// Updates Rect transformation
    /// </summary>
    public interface IUpdateGameObject
    {
        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="obj">Measurement object</param>
        /// <param name="gameObject">Game object</param>
        void Set(object[] obj, GameObject gameObject);

        /// <summary>
        /// Update action
        /// </summary>
        Action Update { get; }

        /// <summary>
        /// Constants
        /// </summary>
        float[] Constants
        {
            get;
        }

        /// <summary>
        /// Sets constants
        /// </summary>
        /// <param name="Offset">Off set</param>
        /// <param name="constants"></param>
        /// <returns>Resul offset</returns>
        int SetConstants(int offset, float[] constants);

    }
}
