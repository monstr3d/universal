using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;

namespace Assets
{
    public class UpdateResults : AbstractUpdateGameObject
    {

        Action update;

        public UpdateResults()
        {
            constants = new float[0];
            update = UpdateMouse;
        }
        public override Action Update => UpdateInternal;

        void UpdateMouse()
        {
           if (Input.GetMouseButton(0))
            {
                indicator.gameObject.SetActive(false);
                update = null;
            }
        }

        void UpdateInternal()
        {
            update?.Invoke();
        }
    }
}
