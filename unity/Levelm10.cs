using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard;


namespace Assets
{
    public class Levelm10 : Levelm
    {
        public Levelm10()
        {
            // var ss = new string[] { Level0.Distance, Level0.Velocity,   Level0.VxLimiter,  Level0.Rz };
            var ss = new string[] { Level0.LongXC, Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rx, Level0.Vx, Level0.Ox,  Level0.Oy,  Level0.Oz };
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
            ev.Event += Levelm1_Event;
        }

        private void Levelm1_Event()
        {
            double[] p = frame.Position;
            if (Math.Abs(p[2]) < 0.01)
            {
                ev.Event -= Levelm1_Event;
                (Level0.RigidBodyStation + "." +
                    Level0.LongXC).EnableDisable(false);
                //             ForcesMomentumsUpdate.Finish();
                (Level0.RigidBodyStation + "." +
                  Level0.ShortXC).EnableDisable(true);// */
            }

        }

        static Levelm10()
        {

        }

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight = 115 s
            (Level0.RigidBodyStation + "." +
               Level0.ShortXC).EnableDisable(false);
            Level1.Collision(stop);
        }


        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour);
            if (monoBehaviour.name != Level0.Station)
            {
                return;
            }
            ReferenceFrameBehavior beh = monoBehaviour as ReferenceFrameBehavior;
            var c = beh.constants;
            c[0] = "Station frame.Z=1.3";
            c[1] = "Station frame.Y=0.1";
            c[2] = "Station frame.X=0";
            c[4] = "Station frame.Vy=0.0001";
            c[5] = "Station frame.Vz=-0.015";

            /*
        [0]	"Station frame.Z=3.5"	string
		[1]	"Station frame.Y=0.5"	string
		[2]	"Station frame.X=1"	string
		[3]	"Station frame.Vx=0"	string
		[4]	"Station frame.Vy=0"	string
		[5]	"Station frame.Vz=0.0"	string
		[6]	"Station frame.Roll=0.0"	string
		[7]	"Station frame.Pitch=0.0"	string
		[8]	"Station frame.Yaw=0.0"	string
		[9]	"Station frame.OMGx=0.0"	string
		[10]	"Station frame.OMGy=0"	string
		[11]	"Station frame.OMGz=0"	string
            */

        }


        protected override void Update()
        {

        }

    }
}
