using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard;

namespace Assets
{
    public class Levelm1 : Levelm
    {
        public Levelm1()
        {
            // var ss = new string[] { Level0.Distance, Level0.Velocity,   Level0.VxLimiter,  Level0.Rz };
            var ss = new string[] { Level0.LongXC, Level0.Rz, Level0.Vz };
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
            ev.Event += Levelm1_Event;
        }

        private void Levelm1_Event()
        {
            double[] p = frame.Position;
            if (Math.Abs(p[2]) < 0.01)
            {
                ev.Event -= Levelm1_Event;
                (Level0.RigidBodyStation + "." +
                    Level0.LongXC).EnableDisable(false);
                //             ForcesMomentumsUpdate.Finish();
                (Level0.RigidBodyStation + "." +
                  Level0.ShortXC).EnableDisable(true);// */
            }

        }

        static Levelm1()
        {

        }

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction>  stop)
        {
            // Time of flight = 115 s
            (Level0.RigidBodyStation + "." +
               Level0.ShortXC).EnableDisable(false);
            Level1.Collision(stop);
        }


        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level1.Set(monoBehaviour);
        }


        protected override void Update()
        {
            
        }

    }
}
