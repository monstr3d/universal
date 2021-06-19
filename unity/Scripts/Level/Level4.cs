using System;
using System.Collections.Generic;

using UnityEngine;



using Scada.Interfaces;

using Unity.Standard;

namespace Scripts.Level
{
    public class Level4 : Levelm
    {

        public Level4()
        {
            var ss = new string[] {  Level0.Rz, Level0.Vz, Level0.Oz};
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
        }

        static void SetStation(ReferenceFrameBehavior behavior)
        {
            var c = behavior.constants;
            c[0] = "Station frame.Z=3.5";
            for (int i = 1; i < c.Length; i++)
            {
                c[i] = c[i].ToZero();
            }
            c[8] = "Station frame.Yaw=2.7";
        }


    }
}
