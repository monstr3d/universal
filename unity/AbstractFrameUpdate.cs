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
    public abstract class AbstractFrameUpdate : AbstracUpdateGameObject
    {
        protected ReferenceFrame frame;

        protected EulerAngles angles;

        public AbstractFrameUpdate()
        {

        }

        public override void Set(object[] obj, GameObject gameObject)
        {
            base.Set(obj, gameObject);
            frame = obj[0] as ReferenceFrame;
            if (obj.Length > 1)
            {
                angles = obj[1] as EulerAngles;
            }
         }
    }
}
