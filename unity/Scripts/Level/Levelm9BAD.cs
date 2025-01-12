using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Vector3D;

using Unity.Standard;

using UnityEngine;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Levelm9 : Levelm
    {

 

        public Levelm9()
        {
            var ss = new string[] {
                 Level0.OzControl,
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Oz, Level0.Time, Level0.TimeOverTime};
            ss.SetVisible();
            
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
            var ob = new object[] { fx(), fy(), fz() };
            var x = rm.Convert<double>(ob);

            if (Math.Abs(x[0]) > double.Epsilon |
     Math.Abs(x[1]) > double.Epsilon |
     Math.Abs(x[2]) > double.Epsilon)
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
            vp.Set(angles, frame.Quaternion);
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
            if (!(monoBehaviour is ReferenceFrameBehavior))
            {
                var a = (monoBehaviour as OutputController).aliases;
                a[10] = "Calculations.d=800";
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
                        c[1] = "Station frame.Y=-0.002795";
                        c[2] = "Station frame.X=0.001534";
                        c[3] = "Station frame.Vx=0.0001097";
                        c[4] = "Station frame.Vy=0.0000882";
                        /*                  c[3] = "Station frame.Vx=0.001097";
                                          c[4] = "Station frame.Vy=0.000882";
                                          /*
                                           * 	[1]	"Station frame.Y=-0.002795"	string
                          [2]	"Station frame.X=0.001534"	string
                          [3]	"Station frame.Vx=0.001097"	string
                          [4]	"Station frame.Vy=0.000882"	string

                                          /*    c[9] = "Station frame.OMGx=0.001";
                                                                                                                                                                  c[10] = "Station frame.OMGy=-0.0015";//*/
                        // c[9] = "Station frame.OMGx=0.0005";
                        //     c[10] = "Station frame.OMGy=-0.0015";//*/
                        c[8] = "Station frame.Yaw=1.3";
                        c[11] = "Station frame.OMGz=0.04";
                    }
                }
            }
        }

     }
}
