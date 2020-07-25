using System;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard;


namespace Assets
{
    public class Level1 : Levelm
    {
        public Level1()
        {

        }

        protected override void Update()
        {
           
        }

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Levelm.Collision(stop);
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour);
        }

    }
}
