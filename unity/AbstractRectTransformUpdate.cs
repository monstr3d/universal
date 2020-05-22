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
    public abstract class AbstractRectTransformUpdate : IUpdateRectTransform
    {

        #region Fields

    
        protected ReferenceFrame frame;

        protected EulerAngles angles;

        protected RectTransform transform;

        #endregion

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="frame">Frame</param>
        /// <param name="angles">Angles</param>
        /// <param name="transform">Transformation</param>
        public virtual void Set(ReferenceFrame frame, EulerAngles angles, RectTransform transform)
        {
            this.frame = frame;
            this.angles = angles;
            this.transform = transform;
        }

        /// <summary>
        /// Update action
        /// </summary>
        public abstract Action Update { get; }

    }
}
