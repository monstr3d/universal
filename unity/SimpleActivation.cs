using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;

namespace Assets
{
    

    public class SimpleActivation : IActivation
    {
        static private int level;

        static string[][] stringConstants;

        static float kF = 0.001f;

        static float kM = 0.0001f;

        static private string[][] defalutStrings =
            new string[][]
            {
               new string[] {  "Station motion.z=3.5",
  "Station motion.a=0.00",
  "Station motion.q=0.00",
  "Station motion.r=0",
   "Station motion.s=-1",
  "Station motion.b=0.0",
  "Station motion.d=0.0",
  "Station motion.x=0.0",
  "Station motion.y=0.0" }
            };



        static private float[][] defaultfloatConstants = new float[][]
            {
                new float[6]
            };

        static private float[][] floatConstants;
        static public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                Init();
                SetValues();
            }
        }

        static SimpleActivation()
        {
            Level = 1;
        }

        public SimpleActivation()
        {

        }

        void IActivation.Activate(MonoBehaviour[] monoBehaviours)
        {
            foreach (var mono in monoBehaviours)
            {
                ReferenceFrameBehavior rf = null;
                OutputController oc = null;
                if (mono is ReferenceFrameBehavior)
                {
                    rf = mono as ReferenceFrameBehavior;
                }
                if (mono is OutputController)
                {
                    oc = mono as OutputController;
                }
                string name = mono.gameObject.name;
                if (oc != null)
                {
                    oc.inputConstants = floatConstants[0];
                }
                if (name == "Station")
                {
                    rf.constants = stringConstants[0];
                }
            }
        }

        private static void SetValues()
        {
            floatConstants[0][0] = kF;
            float[] f = floatConstants[0];
            f[0] = kF;
            if (level == 1)
            {
                return;
            }
            string[] sc = stringConstants[0];
            if (level >= 4)
            {
                sc[5] = "Station motion.b=1.57";
                f[4] = kM;
                if (level == 4)
                {
                    return;
                }
                sc[6] = "Station motion.d=0.1";
                f[5] = kM;
                if (level == 5)
                {
                    return;
                }
                sc[1] = "Station motion.a=0.01";
                f[3] = kM;
                return;
            }
            f[2] = kF;
            sc[8] = "Station motion.y=0.5";
            if (level == 2)
            {
                return;
            }
            stringConstants[0][7] = "Station motion.x=0.5";
            f[1] = kF;
            if (level == 100)
            {
                stringConstants[0][5] = "Station motion.b=1.57";
            }
        }

        static void Init()
        {
            stringConstants = new string[defalutStrings.Length][];
            for (int i = 0; i < defalutStrings.Length; i++)
            {
                string[] ds = defalutStrings[i];
                string[] ss = new string[ds.Length];
                Array.Copy(ds, ss, ss.Length);
                stringConstants[i] = ss;
            }
            floatConstants = new float[defaultfloatConstants.Length][];
            for (int i = 0; i < defaultfloatConstants.Length; i++)
            {
                float[] ds = defaultfloatConstants[i];
                float[] ss = new float[ds.Length];
                Array.Copy(ds, ss, ss.Length);
                floatConstants[i] = ss;
            }

        }
    }
}
