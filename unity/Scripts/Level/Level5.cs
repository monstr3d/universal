using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Level5 : Levelm
    {


        public Level5()
        {
            // var ss = new string[] { Level0.Distance, Level0.Velocity,   Level0.VxLimiter,  Level0.Rz };
            var ss = new string[] { 
                Level0.Rz, Level0.Vz, Level0.Oz,  Level0.Time, Level0.TimeOverTime };
            ss.SetVisible();
        }

        public static void Post()
        {
            SunMonobehavior.SetGood();
            // SunMonobehavior.SetDark();
        }


        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight UNKNOWN
            Levelm.Collision(stop);
        }
        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level4.Set(monoBehaviour);
            if (monoBehaviour is ReferenceFrameBehavior)
            {
                ReferenceFrameBehavior behavior = monoBehaviour as ReferenceFrameBehavior;
                var c = behavior.constants;
                if (c.Length > 11)
                {
                    if (c[11].Contains("OMGz"))
                    {
                        c[11] = "Station frame.OMGz=0.04";
                        c[8] = "Station frame.Yaw=2.7";
                    }
                }
            }
            if (monoBehaviour is OutputController)
            {
                var a = (monoBehaviour as OutputController).aliases;
                a[10] = "Calculations.d=120";
            }
        }
    }
}
