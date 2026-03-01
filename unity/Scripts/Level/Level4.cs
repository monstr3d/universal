using System;
using System.Collections.Generic;

using UnityEngine;



using Scada.Interfaces;

using Unity.Standard;
using Unity.Standard.Interfaces;

namespace Scripts.Level
{
    public class Level4 : Levelm
    {

        public Level4()
        {
            var ss = new string[] {  Level0.Rz, Level0.Vz, Level0.Oz, Level0.Time, Level0.TimeOverTime };
            ss.SetVisible();
        }

        public static void Post()
        {
            SunMonobehavior.SetGood();
           // SunMonobehavior.SetDark();
        }


        new static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            Levelm.Collision(stop);
        }

        public static void Set(MonoBehaviour monoBehaviour)
        {
            ReferenceFrameBehavior rf = null;
            OutputController oc = null;
            if (monoBehaviour is ReferenceFrameBehavior)
            {
                rf = monoBehaviour as ReferenceFrameBehavior;
            }
            if (monoBehaviour is OutputController)
            {
                oc = monoBehaviour as OutputController;
                Set(oc as OutputController);
                return;

            }
            if (rf == null)
            {
                return;
            }
            if (rf.desktop != Level0.RigidBodyStation)
            {
                return;
            }
            string name = monoBehaviour.gameObject.name;
            if (name == Level0.Station)
            {
                SetStation(rf);
                return;
            }
            SetCamera(rf);
        }

        static void SetCamera(ReferenceFrameBehavior behavior)
        {

        }

        static internal void Set(OutputController behavior)
        {
            var c = behavior.inputConstants;
            var p = new int[] { 1, 2, 3, 5 };
            foreach (var i in p)
            {
                c[i] = 0;
            }
            var a = behavior.aliases;
            a[10] = "Calculations.d=125";

        }

        static void SetStation(ReferenceFrameBehavior behavior)
        {
            var c = behavior.constants;
            c[0] = "Station frame.Z=3.3";
            for (int i = 1; i < c.Length; i++)
            {
                c[i] = c[i].ToZero();
            }
            c[8] = "Station frame.Yaw=2.7";
        }


    }
}
