using Motion6D.Interfaces;
using Scada.Interfaces;
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

        IScadaInterface scada;

        protected float[] constants = new float[0];

        #endregion

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="obj">Measurement object</param>
        /// <param name="gameObject">Game object</param>
        /// <param name="scada">SCADA</param>
        public virtual void Set(object[] obj, GameObject gameObject, IScadaInterface scada)
        {
            this.obj = obj;
            this.gameObject = gameObject;
            this.scada = scada;
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
            return constants.SetConstants(offset, this.constants);
        }

        /// <summary>
        /// Update action
        /// </summary>
        public abstract Action Update { get; }

    }
}
