using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Standard;
using UnityEngine;


namespace Scripts.Level
{
    class Levelm1_Fuel : Levelm
    {
        public Levelm1_Fuel()
        {
            var ss = new string[] { Level0.Time, Level0.Rz, Level0.Vz, Level0.Fuel };
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
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
