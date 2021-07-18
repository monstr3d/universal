using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using Scada.Interfaces;


using Unity.Standard.Interfaces;
using Unity.Standard;





namespace Scripts.Level
{
    class Levelm1_Fuel : Levelm
    {
        public Levelm1_Fuel()
        {
            var ss = new string[] { Level0.Time, Level0.TimeOverTime, Level0.Rz, Level0.Vz, Level0.Fuel };
            ss.SetVisible();
            distShort.Event += () =>
            {
                KeyCode.RightControl.KeyDown();
            };
            startEv.Event +=  () =>
                {
                    KeyCode.RightShift.KeyDown();
                };
            distLong.Event += () =>
            {
                KeyCode.RightControl.KeyDown();
            };

        }

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Level1_Fuel.Collision(stop);
        }



        protected override void Update()
        {

        }


        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level1_Fuel.Set(monoBehaviour);
         //   SunMonobehavior.SetSemiDark();
        }

    }
}
