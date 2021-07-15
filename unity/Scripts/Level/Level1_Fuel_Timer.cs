using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;

namespace Scripts.Level
{
    // 0 вперед 29 стоп 38 назад
    public class Level1_Fuel_Timer : Levelm
    {
        public Level1_Fuel_Timer()
        {
            var ss = new string[] { Level0.Time };// , Level0.Vz };
            var l = new List<string>();
            foreach (var s in ss)
            {
                l.Add(Level0.RigidBodyStation + "." + s);
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
         }




        protected override void Update()
        {

        }


        public static void Set(MonoBehaviour monoBehaviour)
        {
            Level1_Fuel.Set(monoBehaviour);
        }


        public static void Post()
        {
            SunMonobehavior.SetSemiDark();
        }

    }
}
