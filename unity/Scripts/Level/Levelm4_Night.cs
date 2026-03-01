using System;
using System.Collections.Generic;

using UnityEngine;



using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Levelm4_Night : Levelm4
    {
        public Levelm4_Night()
        {

        }


        new public static void Post()
        {
            Level4_Night.Post();
        }


        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Level4.Collision(stop);
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level4.Set(monoBehaviour);
        }


    }
}
