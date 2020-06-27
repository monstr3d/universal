using Motion6D.Interfaces;
using Scada.Desktop;
using Scada.Interfaces;
using System;
using System.Collections.Generic;
using Unity.Standard;
using UnityEngine;

namespace Assets
{
    public class Levelm1 : AbstractLevelStringUpdate
    {

        Action update;

        ReferenceFrame frame;

        bool stropped = false;

        IVelocity v;

        public Levelm1()
        {
            // var ss = new string[] { Level0.Distance, Level0.Velocity,   Level0.VxLimiter,  Level0.Rz };
            var ss = new string[] { Level0.LongX };
            var l = new List<string>();
            foreach (var s in ss)
            {
               l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
            IScadaInterface scada = Level0.RigidBodyStation.ToExistedScada();
            scada["Force"].Event += Levelm1_Event;
            frame = scada.GetOutput("X-Frame.Frame")() as ReferenceFrame;
            v = frame as IVelocity;
            update = () =>
            {
                if (stropped)
                {
                    return;
                }
                double[] p = v.Velocity;
                if (Math.Abs(p[2]) > 0.01)
                {
                    stropped = true;
                    (Level0.RigidBodyStation + "." +
                        Level0.VxLimiter).EnableDisable(false);
       //             ForcesMomentumsUpdate.Finish();
                /*   (Level0.RigidBodyStation + "." +
                        Level0.ShortX).EnableDisable(true);// */
                    update = () => { };
                }

            };
  
        }

        private void Levelm1_Event()
        {
            update();
        }

        static Levelm1()
        {

        }

        static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction>  stop)
        {
            
        }
        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour);
        }


        protected override void Update()
        {
            
        }
    }
}
