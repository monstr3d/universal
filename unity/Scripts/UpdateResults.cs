﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;

namespace Scripts
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
            indicator.gameObject.SetActive(true);
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