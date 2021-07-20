using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Vector3D;

using Unity.Standard;

using UnityEngine;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Levelm7 : Levelm
    {


        protected  Levelm7(bool b)
        {

        }


        public Levelm7()
        {
            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {
                Level0.ZControl,
                Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Oz, Level0.Time, Level0.TimeOverTime};
            ss.SetVisible();
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
                Level0.YControl.EnableLevel(true);
                ev.Event += YEvent;
            }
        }

        void YEvent()
        {
            var p = frame.Position;
            if ((Math.Abs(fx()) < double.Epsilon) & (Math.Abs(fy()) < double.Epsilon) 
                & (Math.Abs(fz()) < double.Epsilon))
            {
                Debug.Log("YEvent");
                ev.Event -= YEvent;
                Level0.OzControl.EnableLevel(true);
                Level0.YControl.EnableLevel(false);
                Level0.ZControl.EnableLevel(false);
                ax(0);
                ay(0);
                az(0);
                ev.Event += YawEvent;
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
                ax(0);
                ay(0);
                az(0);
                //     Level0.OzControl.EnableLevel(true);
                Level0.YControl.EnableLevel(true);
                ev.Event += ZZEvent;

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
                ev.Event += FinishEvent;

            }
        }

        private void FinishEvent()
        {
            //  if  (Math.Abs(angles.yaw) < al & Math.Abs(aVelocity.Omega[2]) < ol)
            //   {
            if ((Math.Abs(fx()) < double.Epsilon) & (Math.Abs(fy()) < double.Epsilon)
            & (Math.Abs(fz()) < double.Epsilon))
            {
                Level0.ShortXC.EnableLevel(true);
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
