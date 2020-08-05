using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Vector3D;

using Unity.Standard;

using UnityEngine;

namespace Assets
{
    public class Levelm7 : Levelm
    {

        EulerAngles angles = new EulerAngles();

        protected Levelm7(bool b)
        {

        }

        public Levelm7()
        {
            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {
             //   Level0.LongXC,               Level0.YControl, 
                Level0.ZControl,
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Oz};
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
            ev.Event += ZEvent;
        }

        const double al = 1 * Mathf.Deg2Rad;

        const double ol = 0.5 * Mathf.Deg2Rad;

        double disst = 0.005;

        protected void ZEvent()
        {
            var p = frame.Position;
            var v = velocity.Velocity;
            if (Math.Abs(p[0]) < disst)
            {
                Debug.Log("ZEvent");
                ev.Event -= ZEvent;
                (Level0.RigidBodyStation + "." +
                Level0.YControl).EnableDisable(true);
                ev.Event += YEvent;
            }
        }

        void YEvent()
        {
            var p = frame.Position;
            if (Math.Abs(p[1]) < disst)
            {
                Debug.Log("YEvent");

                ev.Event -= YEvent;
                (Level0.RigidBodyStation + "." +
Level0.OzControl).EnableDisable(true);

//                (Level0.RigidBodyStation + "." +
//                Level0.LongXC).EnableDisable(true);
                ev.Event += YawEvent;
            }

        }

        void XEvent()
        {
            double[] p = frame.Position;
            if (Math.Abs(p[2]) < 0.01)
            {
                Debug.Log("XEvent");

                ev.Event -= XEvent;
                   (Level0.RigidBodyStation + "." +
                Level0.OzControl1).EnableDisable(true);
                ev.Event += YawEvent;
                // */
            }


        }

   

        private void YawEvent()
        {
            double[] p = frame.Position;
            angles.Set(frame.Quaternion);
            if (Math.Abs(angles.yaw) < al & Math.Abs(aVelocity.Omega[2]) < ol & 
               Math.Abs(p[1]) < 0.5 *  disst & Math.Abs(p[0]) < 0.5 * disst)
            {
                Debug.Log("YawEvent");
                ev.Event -= YawEvent;
                //       (Level0.RigidBodyStation + "." +
                //        Level0.LimitedXC).EnableDisable(true);
                //       (Level0.RigidBodyStation + "." +
                //      Level0.OzControl).EnableDisable(false);
                //    (Level0.RigidBodyStation + "." +
                //     Level0.YControl).EnableDisable(true);
                //  (Level0.RigidBodyStation + "." +
                //  Level0.ZControl).EnableDisable(true);
           //     (Level0.RigidBodyStation + "." +
          //      Level0.LongXC).EnableDisable(false);
                (Level0.RigidBodyStation + "." +
                Level0.ShortXC).EnableDisable(true);

            }
        }

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight = 532
            Level0.Collision(stop);
        }
        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level7.Set(monoBehaviour);
        }


        protected override void Update()
        {

        }
    }
}
