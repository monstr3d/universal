using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Vector3D;

using Unity.Standard;

using UnityEngine;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Levelm8 : Levelm
    {


        protected Levelm8(bool b)
        {

        }


        public Levelm8()
        {
            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {Level0.LongXC,
                Level0.ZControl, Level0.YControl,
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Ox,  Level0.Oy, Level0.Oz, Level0.Time, Level0.TimeOverTime};
            ss.SetVisible();
            ev.Event += PreEvent;
            update = UpdateExport;
        }

        const double al = 1 * Mathf.Deg2Rad;

        const double ol = 0.5 * Mathf.Deg2Rad;

        double disst = 0.005;

        protected void PreEvent()
        {
            double[] p = frame.Position;
            if (PositionLimit(0.01) & Math.Abs(p[2]) < 0.01)
            {
                Debug.Log("PreEvent");
                ev.Event -= PreEvent;
                updateInternal = Update;
                //  ev.Event += YawEvent;
            }
        }

        protected void ZEvent()
        {
            var p = frame.Position;
            var v = velocity.Velocity;
            if (VelocityLimit(0.0008) & PositionLimit(0.006))
            {
                Debug.Log("ZEvent");
                ev.Event -= ZEvent;
                Level0.OzControl.EnableLevel(true);
                Level0.YControl.EnableLevel(false);
                Level0.ZControl.EnableLevel(false);
                ax(0);
                ay(0);
                az(0);
                ev.Event += YawEvent;
            }
        }



        void YEvent()
        {
            var p = frame.Position;
            var v = velocity.Velocity;
            //        if ((Math.Abs(fx()) < double.Epsilon) & (Math.Abs(fy()) < double.Epsilon)
            //             & (Math.Abs(fz()) < double.Epsilon))
            //         {
            if (VelocityLimit(0.0001))
            {

                Debug.Log("YEvent");
                ev.Event -= YEvent;
                //Level0.OzControl.EnableLevel(true);
                // Level0.YControl.EnableLevel(false);
                //  Level0.ZControl.EnableLevel(false);
                ax(0);
                ay(0);
                az(0);
                ev.Event += YawEvent;
                //  }
            }
        }


        private void YawEvent()
        {
            double[] p = frame.Position;
            angles.Set(frame.Quaternion);
            if (Math.Abs(angles.yaw) < al & Math.Abs(aVelocity.Omega[2]) < ol)
            //& 
            //Math.Abs(p[1]) < 0.5 *  disst & Math.Abs(p[0]) < 0.5 * disst)
            {
                Debug.Log("YawEvent");
                ev.Event -= YawEvent;
                Level0.LongXC.EnableLevel(false);
                ax(0);
                ay(0);
                az(0);

                //      Level0.YControl.EnableLevel(true);
                //      Level0.ZControl.EnableLevel(true);
                Level0.ShortXC.EnableLevel(true);
                // ev.Event += ZZEvent;

            }
        }


        private void ZZEvent()
        {
            if ((Math.Abs(fx()) < double.Epsilon) & (Math.Abs(fy()) < double.Epsilon)
                & (Math.Abs(fz()) < double.Epsilon))
            //& 
            //Math.Abs(p[1]) < 0.5 *  disst & Math.Abs(p[0]) < 0.5 * disst)
            {
                Debug.Log("ZZEvent");
                ev.Event -= ZZEvent;
                //     Level0.OzControl.EnableLevel(true);
                Level0.ZControl.EnableLevel(true);
                Level0.YControl.EnableLevel(true);
                ev.Event += FinishEvent;

            }
        }

        private void FinishEvent()
        {
            //  if  (Math.Abs(angles.yaw) < al & Math.Abs(aVelocity.Omega[2]) < ol)
            //   {
            if (PositionLimit(0.005))
            {
                Debug.Log("FinishEvent");
                Level0.ShortXC.EnableLevel(true);
            }
        }

        public static void Post()
        {
            Level8.Post();
        }


        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight = 532
            Level0.Collision(stop);
        }
        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level8.Set(monoBehaviour);
        }


        void UpdateExport()
        {
            updateInternal?.Invoke();
        }


        protected void Update()
        {
            //  Debug.Log("Update");
            double[] p = frame.Position;
            angles.Set(frame.Quaternion);
            if (Math.Abs(angles.yaw) < 10 * al)// & Math.Abs(aVelocity.Omega[2]) < ol)
                                               //& 
                                               //Math.Abs(p[1]) < 0.5 *  disst & Math.Abs(p[0]) < 0.5 * disst)
            {
                updateInternal = null;
                Debug.Log("Update");
                //    ev.Event += YawEvent;
                /*      ax(0);
                      ay(0);
                      az(0);

                        Level0.YControl.EnableLevel(false);
                        Level0.ZControl.EnableLevel(false);*/
                Level0.OzControl.EnableLevel(true);
                ev.Event += YawEvent;
                //   ev.Event += ZZEvent;

            }
        }
    }
}