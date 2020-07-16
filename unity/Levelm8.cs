using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Vector3D;

using Unity.Standard;

using UnityEngine;

namespace Assets
{
    public class Levelm8 : Levelm
    {

        EulerAngles angles = new EulerAngles();


        public Levelm8()
        {
            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {
                Level0.LongXC,
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Ox,  Level0.Oy,  Level0.Oz};
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
            ev.Event += LongEvent;
        }

        const double al = 1 * Mathf.Deg2Rad;

        const double ol = 0.1 * Mathf.Deg2Rad;

        void LongEvent()
        {
            double[] p = frame.Position;
            double[] v = velocity.Velocity;
            if (Math.Abs(p[2]) < 0.1 & v[2] < 0)
            {
                ev.Event -= LongEvent;
                (Level0.RigidBodyStation + "." +
                   Level0.LongXC).EnableDisable(false);
                ax(0);
                ay(0);
                az(0);
                (Level0.RigidBodyStation + "." +
                Level0.OxControl).EnableDisable(true);
                (Level0.RigidBodyStation + "." +
                  Level0.OyControl).EnableDisable(true);
                (Level0.RigidBodyStation + "." +
                   Level0.OzControl).EnableDisable(true);
                ev.Event += OmEvent;
            }
        }

        double k = 3;

        void OmEvent()
        {
            if (Math.Abs(fx()) > double.Epsilon |
     Math.Abs(fy()) > double.Epsilon |
     Math.Abs(fz()) > double.Epsilon)
            {
                int i = 0;
            }
            ev.Event -= OmEvent;
            ax(0);
            ay(0);
            az(0);
            ev.Event += OmEvent;
            var av = aVelocity.Omega;
            var ov = orientation.Quaternion;
            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(ov[i + 1]) > al * 2 * k)
                {
                    return;
                }
                if (Math.Abs(av[i])  > ol  * k)
                {
                    return;
                }
            }
            (Level0.RigidBodyStation + "." +
               Level0.YControl).EnableDisable(true);
            (Level0.RigidBodyStation + "." +
               Level0.ZControl).EnableDisable(true);

            ev.Event -= OmEvent;

            ev.Event += YZEvent;
        }

        private void YZEvent()
        {
            var av = aVelocity.Omega;
            var ov = orientation.Quaternion;
            var v = velocity.Velocity;
            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(ov[i + 1]) > al * 2 * k)
                {
                    return;
                }
                if (Math.Abs(av[i]) > ol * k)
                {
                    return;
                }
                if (Math.Abs(v[i]) > 0.0005)
                {
                    return;
                }
            }

            double[] p = frame.Position;
            if (Math.Abs(p[1]) > 0.005 | Math.Abs(p[0]) > 0.005)
            {
                return;
            }
                        (Level0.RigidBodyStation + "." +
               Level0.ShortXC).EnableDisable(true);

        }


        private void YawEvent()
        {
            angles.Set(frame.Quaternion);
            if (Math.Abs(angles.yaw) < al & Math.Abs(aVelocity.Omega[2]) < ol)
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
            Level8.Set(monoBehaviour);
        }


        protected override void Update()
        {

        }
    }
}
