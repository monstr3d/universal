﻿using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Levelm1 : Levelm
    {
        public Levelm1()
        {
            var ss = new string[] { Level0.LongXC, Level0.Rz, Level0.Vz, Level0.Time, Level0.TimeOverTime };
            ss.SetVisible();
            ev.Event += Levelm1_Event;
        }

        private void Levelm1_Event()
        {
            double[] p = frame.Position;
            if (Math.Abs(p[2]) < 0.3)
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
            // Time of flight = 115 s  48 s 36 c
            (Level0.RigidBodyStation + "." +
               Level0.ShortXC).EnableDisable(false);
            Level1.Collision(stop);
        }


        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level1.Set(monoBehaviour);
        }


        public static void Post()
        {
            Level1.Post();
        }


    }
}
