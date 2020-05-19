using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;

namespace Assets
{
    public class TestUpdate : AbstractUpdate
    {
        public TestUpdate()
        {

        }

        public override void Start()
        {
           
        }

        public override void Update()
        {
            var v = mono.gameObject;
            var rb = v.GetComponent<UnityEngine.Rigidbody>();
            if (rb != null)
            {
                var av = rb.angularVelocity;
            }
        }
    }
}
