using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Vector3D;

using Unity.Standard;

using UnityEngine;

namespace Assets
{
    public class Levelm6 : Levelm
    {

        EulerAngles angles = new EulerAngles();


        public Levelm6()
        {
            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {  
                Level0.LongXC,
               Level0.YControl, 
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Oz};
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
            ev.Event += YZEvent;
       }

        const double  al = 1 * Mathf.Deg2Rad;

        const double ol =  0.1 * Mathf.Deg2Rad;

        private void YZEvent()
        {
            double[] p = frame.Position;
            if (Math.Abs(p[1]) < 0.01)
            {
                ev.Event -= YZEvent;
                (Level0.RigidBodyStation + "." +
               Level0.OzControl).EnableDisable(true);
                (Level0.RigidBodyStation + "." +
               Level0.ZControl).EnableDisable(true);
           //     ay(0);
                ev.Event += YawEvent;
            }
        }


        private void YawEvent()
        {
            angles.Set(frame.Quaternion);
            if (Math.Abs(angles.yaw) < al & Math.Abs(av.Omega[2]) < ol)
            {
                ev.Event -= YawEvent;
                //       (Level0.RigidBodyStation + "." +
                //        Level0.LimitedXC).EnableDisable(true);
                //       (Level0.RigidBodyStation + "." +
                //      Level0.OzControl).EnableDisable(false);
                //    (Level0.RigidBodyStation + "." +
                //     Level0.YControl).EnableDisable(true);
                //  (Level0.RigidBodyStation + "." +
                //  Level0.ZControl).EnableDisable(true);
                (Level0.RigidBodyStation + "." +
                Level0.LongXC).EnableDisable(false); 
                (Level0.RigidBodyStation + "." +
                Level0.ShortXC).EnableDisable(true);
    
            }
        }

      
        private void Ev_Event()
        {
            double[] p = frame.Position;
            if (Math.Abs(p[2]) < 0.01)
            {
                ev.Event -= Ev_Event;
                (Level0.RigidBodyStation + "." +
                    Level0.LongXC).EnableDisable(false);
                //             ForcesMomentumsUpdate.Finish();
                (Level0.RigidBodyStation + "." +
                  Level0.ShortXC).EnableDisable(true);// */
            }

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
