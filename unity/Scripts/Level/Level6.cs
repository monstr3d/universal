using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Vector3D;

using Unity.Standard;

using UnityEngine;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Level6 : Levelm
    {


        public Level6()
        {
            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {
                Level0.Rz, Level0.Vz, 
                Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx,
             Level0.Oz,  Level0.Time, Level0.TimeOverTime};
            ss.SetVisible();
        }


        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Levelm.Collision(stop);
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour, 6);
            if (!(monoBehaviour is ReferenceFrameBehavior))
            {
                var a = (monoBehaviour as OutputController).aliases;
                a[10] = "Calculations.d=260";
                return;
            }
            ReferenceFrameBehavior behavior = monoBehaviour as ReferenceFrameBehavior;
            var c = behavior.constants;
            if (c.Length > 11)
            {
                if (c[11].Contains("OMGz"))
                {
                    c[8] = "Station frame.Yaw=2.7";
                    c[2] = c[2].ToZero();
                }
            }
        }



        /*   OLD !!!    public static void Set(MonoBehaviour monoBehaviour)
               {
                   if (monoBehaviour is OutputController)
                   {
                       OutputController oc = monoBehaviour as OutputController;
                       var cc = oc.inputConstants;
                       cc[3] = 0;
                       cc[5] = 0;
                       return;
                   }
                   if (!(monoBehaviour is ReferenceFrameBehavior))
                   {
                       return;
                   }
                   ReferenceFrameBehavior behavior = monoBehaviour as ReferenceFrameBehavior;
                   var c = behavior.constants;
                   if (c.Length > 11)
                   {
                       if (c[11].Contains("OMGz"))
                       {
                           c[8] = "Station frame.Yaw=2.7";
                           c[2] = c[2].ToZero();
                       }
                   }
               }
        */


    }
}
