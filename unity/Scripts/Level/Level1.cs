using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard.Interfaces;

namespace Scripts.Level
{

    /// <summary>
    /// Жать газ до остатка топлива до середины расстояния. Затем назад.
    /// </summary>
    public class Level1 : Levelm
    {

        public Level1()
        {
            var ss = new string[] { Level0.Rz, Level0.Vz, Level0.Time, Level0.TimeOverTime };//, Level0.Fuel };
            ss.SetVisible();
        }



        protected override void Update()
        {
           
        }

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Level0.Collision(stop);
        }

        public static void Post()
        {
            SunMonobehavior.SetSun();
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level0.Set(monoBehaviour);
            if (monoBehaviour is OutputController)
            {
                OutputController oc = monoBehaviour as OutputController;
                var a = oc.aliases;
                a[0] = "Aim 1.Z=0.1";
                a[0] = "Aim 1.Z=-0.15"; // !!!
                                        // Time limit
                a[10] = "Calculations.d=50";
          //      a[10] = "Calculations.d=10";
                return;
            }
            if (monoBehaviour.name != Level0.Station)
            {
                return;
            }
            ReferenceFrameBehavior beh = monoBehaviour as ReferenceFrameBehavior;
            var c = beh.constants;
            c[0] = "Station frame.Z=1.3";
        }

    }
}
