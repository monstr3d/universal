using Motion6D.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using Unity.Standard.Abstract;
using UnityEngine;

namespace Scripts
{
    public class SimpleTriggerAction : AbstractTriggerAction
    {
        public SimpleTriggerAction()
        {

        }

        public override Action<Collider> Action => Update;

        void Update(Collider collider)
        {
            ReferenceFrame frame = scada.GetOutput("Relative to station.Frame")() as ReferenceFrame;
          //  scada.Outputs[]
        }
    }
}
