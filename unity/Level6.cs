using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Vector3D;

using Unity.Standard;

using UnityEngine;

namespace Assets
{
    public class Level6 : Levelm
    {


        public Level6()
        {
            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Oz};
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
        }

        const double al = 1 * Mathf.Deg2Rad;

        const double ol = 0.1 * Mathf.Deg2Rad;




        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Levelm.Collision(stop);
        }
        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour, 6);
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


        protected override void Update()
        {

        }
    }
}
