﻿using System;

using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;
using UnityEngine;

namespace Scripts.Level
{
    public class Level7 : Levelm
    {

        public Level7()
        {
            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {
     //           Level0.LongXC,               Level0.YControl, Level0.ZControl,
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Oz, Level0.Time, Level0.TimeOverTime};
            ss.SetVisible();
        }
        /*
                const double al = 1 * Mathf.Deg2Rad;

                const double ol = 0.1 * Mathf.Deg2Rad;
        */


        public static void Post()
        {
            SunMonobehavior.SetSun();
        }




        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight = UNKNOWN
            (Level0.RigidBodyStation + "." +
               Level0.ShortXC).EnableDisable(false);
            Level0.Collision(stop);
        }

        static void Set(OutputController controller)
        {
            var c = controller.inputConstants;
            c[3] = 0;
            c[5] = 0;
            controller.aliases[10] = "Calculations.d=310"; //289
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            if (!(monoBehaviour is ReferenceFrameBehavior))
            {
                OutputController oc = monoBehaviour as OutputController;
                oc.aliases[0] = "Aim 1.Z=-0.3"; // !!! -0.3
                Set(monoBehaviour as OutputController);
                return;
            }
            ReferenceFrameBehavior behavior = monoBehaviour as ReferenceFrameBehavior;
            var c = behavior.constants;
            if (c.Length > 11)
            {
                if (c[11].Contains("OMGz"))
                {
                                   c[11] = "Station frame.OMGz=0.04"; ///!!! OLD
                    //  c[11] = "Station frame.OMGz=0.02";
                   // c[11] = "Station frame.OMGz=0.01";
                    c[8] = "Station frame.Yaw=1.3";
                }
            }
            else if (c.Length > 0)
            {
                if (c[0].Contains("Motion"))
                {
                    /*            [0]	"Motion.a=60"   string
                [1] "Motion.p=0.00025"  string
                [2] "Motion.b=1.5"  string
                [3] "Motion.c=1.9"  string
                [4] "Motion.q=0.0025"   string*/
                    c[1] = "Motion.p=0.000025";

                    c[4] = "Motion.q=0.00025";

                }
            }
        }

    }
}

