using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard;

namespace Scripts.Level
{
    public class Levelm5 : Levelm
    {


        public Levelm5()
        {
            // var ss = new string[] { Level0.Distance, Level0.Velocity,   Level0.VxLimiter,  Level0.Rz };
            var ss = new string[] { Level0.LongXC, 
                Level0.OzControl1, 
                Level0.Rz, Level0.Vz, Level0.Oz };
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
                (Level0.RigidBodyStation + "." +
                  Level0.ShortXC).EnableDisable(true);// */
            }
        }



        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight 114.15;
            Levelm.Collision(stop);
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level5.Set(monoBehaviour);
        }


        protected override void Update()
        {

        }
    }
}
