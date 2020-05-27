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
    public abstract class AbstractUpdateGameObject : IUpdateGameObject
    {

        #region Fields


        protected Component indicator;

        protected object[] obj;

        protected IScadaInterface scada;

        protected float[] constants = new float[0];

        #endregion

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="obj">Measurement object</param>
        /// <param name="indicator">Indicator</param>
        /// <param name="scada">SCADA</param>
        public virtual void Set(object[] obj, Component indicator, IScadaInterface scada)
        {
            this.obj = obj;
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
