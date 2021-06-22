using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;
using UnityEngine;

namespace Scripts.Level
{
    public class Level8 : Levelm
    {


        public Level8()
        {

            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Ox,  Level0.Oy,  Level0.Oz};
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
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


        protected override void Update()
        {

        }
    }
}
