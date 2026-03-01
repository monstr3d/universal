using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard.Abstract;
using UnityEngine;

namespace Unity.Standard
{
    /// <summary>
    /// Standard collision
    /// </summary>
    public class StandardCollisionAction : AbstractCollisionAction
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public StandardCollisionAction()
        {

        }

        /// <summary>
        /// Collider action
        /// </summary>
        public override Action<Collision> Action => Update;

        /// <summary>
        /// Sets constants
        /// </summary>
        /// <param name="offset">Offset</param>
        /// <param name="constants">Constants</param>
        /// <returns>New offset </returns>

        public override int SetConstants(int offset, float[] constants)
        {
            this.constants = new float[constants.Length];
            Array.Copy(constants, this.constants, constants.Length);
            ResultIndicator.Scada = scada;
            ResultIndicator.Constants = this.constants;
            return -1;
        }

        void Update(Collision collision)
        {
            this.CollisionEvent(gameObject, collisionIndicator, scada);
        }
    }
}
