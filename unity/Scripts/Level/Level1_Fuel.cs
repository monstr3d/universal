using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;

namespace Scripts.Level
{
    public class Level1_Fuel : Levelm
    {
        public Level1_Fuel()
        {
            var ss = new string[] { Level0.Time, Level0.Rz, Level0.Vz , Level0.Fuel };
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();//*/
            // Time = 60
        }

        protected override void Update()
        {

        }


        protected override void TimeOver()
        {
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
            c[0] = "Station frame.Z=1.9";
        }

    }
}
