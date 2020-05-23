using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;

namespace Assets
{
    public class SimpleTriggerAction : AbstractTriggerAction
    {
        public SimpleTriggerAction()
        {
        }

        public override Action<Collider> Action => Update;

        void Update(Collider collider)
        {

        }
    }
}
