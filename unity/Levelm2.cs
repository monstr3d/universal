using Motion6D.Interfaces;
using Scada.Desktop;
using Scada.Interfaces;
using System;
using System.Collections.Generic;
using Unity.Standard;
using UnityEngine;

namespace Assets
{
    public class Levelm2 : AbstractLevelStringUpdate
    {

        #region Fields

        ReferenceFrame frame;

        IEvent ev;

        IScadaInterface scada;

        double last = 0;

        Func<double> func;

        #endregion

        public Levelm2()
        {
         Level0.Get(out scada, out ev, out frame);
            ev.Event += Levelm2_Event;
            func = scada.GetDoubleOutput("Force.Fz");
            var ss = new string[] { Level0.LongXC, Level0.YControl };
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();

        }

        private void Levelm2_Event()
        {
            double[] p = frame.Position;
            var l = func();
            if (Math.Abs(p[2]) < 0.01 & last != l)
            {
                ev.Event -= Levelm2_Event;
                (Level0.RigidBodyStation + "." +
                    Level0.LongXC).EnableDisable(false);
                //             ForcesMomentumsUpdate.Finish();
                (Level0.RigidBodyStation + "." +
                  Level0.ShortXC).EnableDisable(true);// */
            }
            last = l;


        }


        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour);
        }

        static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            // Time of flight 116 s
        }
  








        protected override void Update()
        {
            
        }

        
    }
}

