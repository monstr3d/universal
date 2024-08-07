﻿using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;
using UnityEngine;

namespace Scripts.Level
{
    public class Levelm8BAD : Levelm7
    {

        //      EulerAngles angles = new EulerAngles();


        public Levelm8BAD() : base(true)
        {
            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {
             //   Level0.LongXC,               Level0.YControl, 
                Level0.ZControl,
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Ox, Level0.Oy, Level0.Oz, Level0.Time, Level0.TimeOverTime};
            var l = new List<string>();
            ss.SetVisible();
            ev.Event += ZEvent;
        }

        const double al = 1 * Mathf.Deg2Rad;

        const double ol = 0.1 * Mathf.Deg2Rad;

        double disst = 0.002;
/*
        private void YZEvent()
        {
            double[] p = frame.Position;
            var v = velocity.Velocity;
            if (Math.Abs(p[1]) < disst & Math.Abs(p[0]) < disst)
            {
                ev.Event -= YZEvent;
                (Level0.RigidBodyStation + "." +
               Level0.OzControl1).EnableDisable(true);
                //     ay(0);
                ev.Event += YawEvent;
            }
        }

/*
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
                  Level0.ShortXC).EnableDisable(true);// 
            }

        }
*/




        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight = 499
            Level0.Collision(stop);
        }
        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level8.Set(monoBehaviour);
        }


        protected  void Update()
        {

        }
    }
}
