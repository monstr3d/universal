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
            constants = new float[7];
        }

        public override Action<Collision> Action => Update;

        void Update(Collision collision)
        {
            scada.IsEnabled = false;
            ReferenceFrame frame = scada.GetOutput("Relative to station.Frame")() as ReferenceFrame;
            double time = (double)scada.GetOutput("Station motion.Formula_13")();
        }
    }
}
