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


        #region Fields

        ReferenceFrame frame;

        IEvent ev;

        IScadaInterface scada;

        #endregion


        public Levelm1()
        {
            // var ss = new string[] { Level0.Distance, Level0.Velocity,   Level0.VxLimiter,  Level0.Rz };
            var ss = new string[] { Level0.LongXC };
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
            Level0.Get(out scada, out ev, out frame);
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

        static Levelm1()
        {

        }

        static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction>  stop)
        {
            // Time of flight = 115 s
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
