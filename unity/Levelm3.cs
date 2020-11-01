using System;
using System.Collections.Generic;

using UnityEngine;


using Scada.Interfaces;

using Unity.Standard;

namespace Assets
{
    public class Levelm3 : Levelm
    {


        public Levelm3()
        {
            ev.Event += Levelm3_Event;

            var ss = new string[] { Level0.ZControl, Level0.YControl, Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx};
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();

        }

        private void Levelm3_Event()
        {
            double[] p = frame.Position;
            if (Math.Abs(p[0]) < 0.1)
            {
                ev.Event -= Levelm3_Event;
                ev.Event += Ev_Event;
                (Level0.RigidBodyStation + "." +
                Level0.LongXC).EnableDisable(true);

            }
        }

        private void Ev_Event()
        {
            double[] p = frame.Position;
            if (Math.Abs(p[2]) < 0.01)
            {
                ev.Event -= Ev_Event;
                (Level0.RigidBodyStation + "." +
                    Level0.LongXC).EnableDisable(false);
                //             ForcesMomentumsUpdate.Finish();
                (Level0.RigidBodyStation + "." +
                  Level0.ShortXC).EnableDisable(true);// */
            }

        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour);
        }

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight 272.78
            Levelm.Collision(stop);
        }









        protected override void Update()
        {

        }


    }
}

