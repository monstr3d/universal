using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Unity.Standard;

using UnityEngine;

namespace Assets
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


        static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight = UNKNOWN
            (Level0.RigidBodyStation + "." +
               Level0.ShortXC).EnableDisable(false);
            Level0.Collision(stop);
        }
        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour, 6);
            if (monoBehaviour is OutputController)
            {
                OutputController oc = monoBehaviour as OutputController;
                var a = oc.aliases;
                a[0] = "Aim 1.Z = -0.5";
            }
            if (!(monoBehaviour is ReferenceFrameBehavior))
            {
                return;
            }
            ReferenceFrameBehavior behavior = 
                monoBehaviour as ReferenceFrameBehavior;
            var c = behavior.constants;
            if (c.Length > 11)
            {
                if (c[11].Contains("OMGz"))
                {
                    //                c[1] = "Station frame.Y=-0.039";
                    //                c[2] = "Station frame.Z=-0.018";
                    c[1] = "Station frame.Y=-0.398";
                    c[2] = "Station frame.X=-0.188";
                    c[6] = "Station frame.Roll=0.33";
                    c[7] = "Station frame.Pitch=-0.32";
                    c[8] = "Station frame.Yaw=0.3";
                }
            }

           
            
        }


        protected override void Update()
        {

        }
    }
}
