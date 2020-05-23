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
    /// Abstract implementation of update rect transformation
    /// </summary>
    public abstract class AbstracUpdateGameObject : IUpdateGameObject
    {

        #region Fields


        protected GameObject gameObject;

        protected object[] obj;

        protected float[] constants = new float[0];

        #endregion

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="obj">Measurement object</param>
        /// <param name="gameObject">Game object</param>
        public virtual void Set(object[] obj, GameObject gameObject)
        {
            this.obj = obj;
            this.gameObject = gameObject;
        }

        /// <summary>
        /// Constants
        /// </summary>
        public float[] Constants
        {
            get
            {
                return constants;
            }
        }

        /// <summary>
        /// Sets constants
        /// </summary>
        /// <param name="Offset">Off set</param>
        /// <param name="constants"></param>
        /// <returns>Resul offset</returns>
        public virtual int SetConstants(int offset, float[] constants)
        {
            int l = this.constants.Length;
            if (constants.Length < offset + l)
            {
                return -1;
            }
            Array.Copy(constants, offset, this.constants, 0, l);
            int k = l + offset;
            return (k == constants.Length) ? -1 : k;
        }



        /// <summary>
        /// Update action
        /// </summary>
        public abstract Action Update { get; }

    }
}
