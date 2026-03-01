using System;
using System.Collections.Generic;

using Scada.Interfaces;

using Vector3D;

using Unity.Standard;

using UnityEngine;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Levelm6 : Levelm
    {

  

        public Levelm6()
        {
            /// Level0.ZControl, Level0.YControl,
            var ss = new string[] {  
                Level0.LongXC,
               Level0.YControl, 
                Level0.Rz, Level0.Vz, 
                Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx,
             Level0.Oz, Level0.Time, Level0.TimeOverTime};
            ss.SetVisible();
            ev.Event += YZEvent;
       }

        const double  al = 1 * Mathf.Deg2Rad;

        const double ol =  0.1 * Mathf.Deg2Rad;

 
       

        private void YZEvent()
        {
            double[] p = frame.Position;
            if (Math.Abs(p[1]) < 0.005)
            {
                ev.Event -= YZEvent;
                (Level0.RigidBodyStation + "." +
               Level0.OzControl).EnableDisable(true);
                (Level0.RigidBodyStation + "." +
               Level0.ZControl).EnableDisable(true);
                ev.Event += YawEvent;
                Debug.Log("YZEvent");
            }
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
           //     ev.Event += Ev_Event;
                Debug.Log("YawEvent");
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
                Debug.Log("Ev_Event");
            }

        }


        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time 259
            Levelm.Collision(stop);
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level6.Set(monoBehaviour);
        }


     }
}
