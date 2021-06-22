using System;
using System.Collections.Generic;

using UnityEngine;



using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Levelm2 : Levelm
    {


        protected double last;

        protected Levelm2(bool b)
        {

        }


        public Levelm2() : this(true)
        {
            ev.Event += Levelm2_Event;
            var ss = new string[] { Level0.LongXC, Level0.YControl, Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy };
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
        }

        private void Levelm2_Event()
        {
            double[] p = frame.Position;
            var l = fx();
            if (Math.Abs(p[2]) < 0.01 & last != l)
            {
                ev.Event -= Levelm2_Event;
                (Level0.RigidBodyStation + "." +
                    Level0.LongXC).EnableDisable(false);
                //             ForcesMomentumsUpdate.Finish();
 // */
                ev.Event += Ev_Event;
                Debug.Log(p[1] + "UU");

            }
            last = l;

        }

        private void Ev_Event()
        {
            double[] p = frame.Position;
            if (Math.Abs(p[1]) < 0.01)
            {
                (Level0.RigidBodyStation + "." +
                     Level0.ShortXC).EnableDisable(true);
                Debug.Log(p[1]);
            }
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level2.Set(monoBehaviour);
            // !!! DELETE AFTER
           /* //===
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
                    c[1] = "Station frame.Y=-0.5";
                    // c[8] = "Station frame.Yaw=2.7";
                    // c[2] = c[2].ToZero();
                }
            }
            //=== */
        }

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight 116 s  71 s.
            (Level0.RigidBodyStation + "." +
   Level0.ShortXC).EnableDisable(false);
            (Level0.RigidBodyStation + "." +
         Level0.YControl).EnableDisable(false);

            Level0.Collision(stop);
        }


        protected override void Update()
        {
            
        }

        
    }
}

