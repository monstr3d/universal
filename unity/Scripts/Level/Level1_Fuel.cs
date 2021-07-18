using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using Scada.Interfaces;


using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    /// <summary>
    /// Жать газ до остатка топлива 49 %. Затем стоп. Далее на 31 метре снова включать газ назад.
    /// </summary>
    public class Level1_Fuel : Levelm
    {
        public Level1_Fuel()
        {
            var ss = new string[] { Level0.Time, Level0.TimeOverTime, Level0.Rz, Level0.Vz , Level0.Fuel };
            ss.SetVisible();
            // Time = 60
        }

        protected override void Update()
        {

        }


        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Level0.Collision(stop);
        }



        protected override void TimeOver()
        {
            base.TimeOver();
        }

        protected override void FuelEmpty()
        {
            ForcesMomentumsUpdate.FuelEmpty();
            Zero();
        }




        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour);
            if (monoBehaviour is OutputController)
            {
                OutputController oc = monoBehaviour as OutputController;
                var a = oc.aliases;
                a[0] = "Aim 1.Z=0.1";

                // Short distance
                a[8] = "Calculations.a=0.590";

                // Long distance
                a[9] = "Calculations.b=0.310";

                // Time limit
                a[10] = "Calculations.d=70";

                return;
            }
            if (monoBehaviour.name != Level0.Station)
            {
                return;
            }
            ReferenceFrameBehavior beh = monoBehaviour as ReferenceFrameBehavior;
            var c = beh.constants;
            c[0] = "Station frame.Z=1.7";
        }

        public static void Post()
        {
            SunMonobehavior.SetGood();
        }


    }
}
