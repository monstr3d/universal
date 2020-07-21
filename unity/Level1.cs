using System;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard;


namespace Assets
{
    public class Level1 : AbstractLevelStringUpdate
    {
        public Level1()
        {
        }

        protected override void Update()
        {
           
        }

        static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Level0.Collision(stop);
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour);
        }

    }
}
