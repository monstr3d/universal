using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;
using UnityEngine;

namespace Scripts.Level
{
    public class Level8BAD : Levelm
    {


        public Level8BAD()
        {

            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Ox,  Level0.Oy,  Level0.Oz, Level0.Time, Level0.TimeOverTime};
            ss.SetVisible();
        }


        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight = 461
            Level0.Collision(stop);
        }
        public static void Set(MonoBehaviour monoBehaviour)
        {
            if (!(monoBehaviour is ReferenceFrameBehavior))
            {
                var a = (monoBehaviour as OutputController).aliases;
                a[10] =  "Calculations.d=800";
                return;
            }
            ReferenceFrameBehavior behavior = 
                monoBehaviour as ReferenceFrameBehavior;
            var c = behavior.constants;
            if (c.Length > 11)
            {
                if (c.Length > 11)
                {
                    if (c[11].Contains("OMGz"))
                    {
                                  /*    c[9] = "Station frame.OMGx=0.001";
                                       c[10] = "Station frame.OMGy=-0.0015";//*/
                                     c[9] = "Station frame.OMGx=0.0005";
                                       c[10] = "Station frame.OMGy=-0.0015";//*/
                        c[11] = "Station frame.OMGz=0.04";
                        c[8] = "Station frame.Yaw=1.3";
                    }
                }
            }
        }

    }
}
