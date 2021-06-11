using System;
using System.Collections.Generic;

using UnityEngine;

using Scada.Interfaces;

using Unity.Standard;

namespace Scripts
{
    public class Level1 : Levelm
    {

        public Level1(bool b) : this()
        {

        }
        public Level1()
        {
 /* !!! DELETE AFTER           var ss = new string[] {  Level0.Rz, Level0.Vz };
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
 */
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
            fuelEv.Event += FuelEv_Event;
        }

        private void FuelEv_Event()
        {

        }


        protected override void Update()
        {
           
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
                a[0] = "Aim 1.Z=-0.3";
                a[0] = "Aim 1.Z=-0.01";
                a[0] = "Aim 1.Z=0.1";
                return;
            }
             if (monoBehaviour.name != Level0.Station)
            {
                return;
            }
            ReferenceFrameBehavior beh = monoBehaviour as ReferenceFrameBehavior;
            var c = beh.constants;
            c[0] = "Station frame.Z=1.5";
          //  c[0] = "Station frame.Z=1";/// !!! DELERE AFTER

        }

    }
}
