using Motion6D.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;

namespace Assets
{
    public class SimpleCollisionAction : AbstractCollisionAction
    {
        public SimpleCollisionAction()
        {

        }

        public override Action<Collision> Action => Update;

        void Update(Collision collision)
        {
            ReferenceFrame frame = scada.GetOutput("Relative to station.Frame")() as ReferenceFrame;
          //  scada.Outputs[]
        }
    }
}
