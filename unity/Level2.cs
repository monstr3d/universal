using System;
using System.Collections.Generic;

using UnityEngine;



using Scada.Interfaces;

using Unity.Standard;

namespace Assets
{
    public class Level2 : Levelm
    {


        protected double last;

        protected Level2(bool b)
        {
        }


        public Level2() : this(true)
        {
            var ss = new string[] {  Level0.Rz, Level0.Vz, Level0.Ry, Level0.Vy };
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
        }

        static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
             Level0.Collision(stop);
        }

        protected override void Update()
        {

        }

    }
}


