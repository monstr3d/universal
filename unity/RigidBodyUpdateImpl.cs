using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class RigidBodyUpdateImpl : AbstractUpdate
    {
        public override void Start()
        {

        }

        public override void Update()
        {
            Debug.Log(dOut[0]() + " " + dOut[1]() + " " + dOut[2]());
            return;
            if (Input.GetKey(KeyCode.A))
            {
                dInp[0](0.1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                dInp[0](-0.1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                dInp[1](0.01);
            }
            if (Input.GetKey(KeyCode.F))
            {
                dInp[1](-0.01);
            }
         }
    }
}
