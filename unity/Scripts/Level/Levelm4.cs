﻿using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Levelm4 : Levelm
    {




        public Levelm4()
        {
            // var ss = new string[] { Level0.Distance, Level0.Velocity,   Level0.VxLimiter,  Level0.Rz };
            var ss = new string[] { Level0.LongXC, Level0.OzControl, 
                Level0.Rz, Level0.Vz, Level0.Oz, Level0.Time, Level0.TimeOverTime };
            ss.SetVisible();
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


        public static void Post()
        {
            Level4.Post();
        }



        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight 108
            Levelm.Collision(stop);
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level4.Set(monoBehaviour);
        }

    }
}
