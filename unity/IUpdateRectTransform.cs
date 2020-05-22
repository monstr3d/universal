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
    public interface IUpdateRectTransform
    {
        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="frame">Frame</param>
        /// <param name="angles">Angles</param>
        /// <param name="transform">Transformation</param>
        void Set(ReferenceFrame frame, EulerAngles angles, RectTransform transform);

        /// <summary>
        /// Update action
        /// </summary>
        Action Update { get; }
    }
}
