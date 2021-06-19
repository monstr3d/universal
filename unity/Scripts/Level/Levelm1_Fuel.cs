using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Standard;
using UnityEngine;


namespace Scripts.Level
{
    class Levelm1_Fuel : Level1_Fuel
    {
        public Levelm1_Fuel()
        {
            
            distShort.Event += () =>
            {

            };
        }


        protected override void Update()
        {

        }


        public static void Set(MonoBehaviour monoBehaviour)
        {
            Levelm1_Fuel.Set(monoBehaviour);
        }


    }
}
