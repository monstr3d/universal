using System;
using System.Collections.Generic;

using UnityEngine;


using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Levelm3 : Levelm
    {


        public Levelm3()
        {
            ev.Event += Levelm3_Event;

            var ss = new string[] { Level0.ZControl, Level0.YControl, Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Time, Level0.TimeOverTime};
            ss.SetVisible();
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


        public static void Post()
        {
            Level3.Post();
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
            Level3.Set(monoBehaviour);
        }

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight 272.78 123
            Levelm.Collision(stop);
        }









     
    }
}

