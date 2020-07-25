using System;
using System.Collections.Generic;

using UnityEngine;



using Scada.Interfaces;

using Unity.Standard;

namespace Assets
{
    public class Level3 : Levelm
    {

        public Level3() 
        {
            var ss = new string[] { Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy,
             Level0.Rz, Level0.Vz};
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
        }


        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour);
            return;
            /*
            ReferenceFrameBehavior rf = null;
            OutputController oc = null;
            if (monoBehaviour is ReferenceFrameBehavior)
            {
                rf = monoBehaviour as ReferenceFrameBehavior;
            }
            if (monoBehaviour is OutputController)
            {
                oc = monoBehaviour as OutputController;
                Set(oc);
                return;

            }
            if (rf == null)
            {
                return;
            }
            if (rf.desktop != Level0.RigidBodyStation)
            {
                return;
            }
            string name = monoBehaviour.gameObject.name;
            if (name == Level0.Station)
            {
                Level0.SetStation(rf, StaticExtensionUnity.Activation.level);
                return;
            }
            Level0.SetCamera(rf);
            */
        }

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Levelm.Collision(stop);
        }

        protected override void Update()
        {

        }

    }
}


