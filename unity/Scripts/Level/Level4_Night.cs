using System;
using System.Collections.Generic;

using UnityEngine;



using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Level4_Night : Level4
    {
        public Level4_Night()
        {

        }

 
        new public static void Post()
        {
          //  SunMonobehavior.SetGood();
           SunMonobehavior.SetDark();
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
