using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{

    /// <summary>
    /// Жать газ до остатка топлива до середины расстояния. Затем назад.
    /// </summary>
    public class Levelm1_Fuel_Timer : Levelm
    {

        public Levelm1_Fuel_Timer()
        {
            var ss = new string[] { Level0.Rz, Level0.Vz };//, Level0.Fuel };
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();//*/

        }

   

        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Level0.Collision(stop);
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

                return;
            }
            if (monoBehaviour.name != Level0.Station)
            {
                return;
            }
            ReferenceFrameBehavior beh = monoBehaviour as ReferenceFrameBehavior;
            var c = beh.constants;
            c[0] = "Station frame.Z=1.5";
            SunMonobehavior.SetSun();
        }

    }
}
